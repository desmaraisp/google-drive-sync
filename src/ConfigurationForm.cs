﻿/**
 * Google Sync Plugin for KeePass Password Safe
 * Copyright © 2012-2016  DesignsInnovate
 * Copyright © 2014-2016  Paul Voegler
 * 
 * KPSync for Google Drive
 * Copyright © 2020-2021 Walter Goodwin
 *
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.
**/

using KeePass.UI;
using KeePassLib.Security;
using KPSyncForDrive.WindowsControls;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KPSyncForDrive
{
    partial class ConfigurationForm : Form
    {
        const string GSigninTabIcoKey = "gsignin";
        const string GeneralTabIcoKey = "general";
        const string AboutIcoKey = "about";

        readonly ConfigurationFormData m_data;
        readonly GoogleColor m_nullColor;
        bool m_bColorsQueried;

        public ConfigurationForm(ConfigurationFormData data)
        {
            InitializeComponent();
            

            Text = GdsDefs.ProductName;
            DatabaseFilePath = string.Empty;

            // Localize the form
            Control[] textCx = new Control[]
            {
                m_lnkGoogle,
                m_lnkHelp,
                m_lnkGoogle2,
                m_lnkHelp2,
                m_tabGSignIn,
                m_tabOptions,
                m_grpEntry,
                m_grpDriveAuth,
                m_lblAccount,
                m_grpDriveOptions,
                m_lblHintFolder,
                m_lblFolder,
                m_btnCancel,
                m_btnOK,
                m_btnAbout,
                m_grpCmdEnabled,
                m_chkSyncEnabled,
                m_chkUploadEnabled,
                m_chkDownloadEnabled,
                m_grpAutoSync,
                m_chkSyncOnOpen,
                m_chkSyncOnSave,
                m_grpFolderDefaults,
                m_lblHintDefaultFolder,
                m_lblDefaultFolderLabel,
                m_lblDefFolderColor,
                m_btnGetColors,
                m_grpAuthTokenSecurityDefaults,
                m_chkDontSaveAuthDefault,
                m_chkWarnAuthToken,
                m_lnkAuthTokenDefaultsHelp,
                m_grpAuthTokenSecurity,
                m_chkDontSaveAuthToken,
                m_lnkAuthTokenHelp,
                m_chkSyncOnReopen,
                AuthorizeFiles_btn,
                AuthorizeFiles_label
            };
            foreach (Control c in textCx)
            {
                c.Text = Resources.GetString(c.Text);
            }

            m_grpDriveAuth.Text = Strings.AuthorizeFiles_sectionHeader;
            AuthorizeFiles_tooltip.SetToolTip(AuthorizeFiles_btn, Strings.AuthorizeFiles_tooltip);

            m_data = data;

            // Wire events and such for the folder color picker. 
            m_nullColor = new GoogleColor(m_cbColors.BackColor,
                GoogleColor.Default.Name);
            m_cbColors.DrawMode = DrawMode.OwnerDrawVariable;
            m_cbColors.DrawItem += HandleColorsDrawItem;
            m_btnGetColors.Click += HandleColorsComboLazyLoad;
            m_cbColors.SelectedIndexChanged += HandleColorsSelectedIndexChanged;
            if (m_data.DefaultAppFolderColor == null ||
                m_data.DefaultAppFolderColor == GoogleColor.Default)
            {
                m_cbColors.Items.Add(m_nullColor);
                m_cbColors.SelectedIndex = 0;
                m_cbColors.Enabled = false;
            }
            else
            {
                GoogleColor[] userColors = new[]
                {
                    m_nullColor,
                    new GoogleColor(m_data.DefaultAppFolderColor.Color,
                                m_data.DefaultAppFolderColor.Name)
                };
                m_cbColors.Items.Clear();
                m_cbColors.Items.AddRange(userColors);
                m_cbColors.SelectedItem = userColors[1];
                m_cbColors.Enabled = string.IsNullOrWhiteSpace(m_txtFolderDefault.Text);
            }
            m_btnGetColors.Enabled = string.IsNullOrWhiteSpace(m_txtFolderDefault.Text);
            m_bColorsQueried = false;
        }

        // Do most event and binding stitching here because KeePass likes to
        // dispose forms quickly.  Also, the presentation object can change
        // before the form is shown.
        protected override void OnLoad(EventArgs args)
        {
            // Do the "data bindings" with the presentation object.
            BindingSource bindingSource = m_data.EntryBindingSource;
            bindingSource.DataSource = m_data.Entries;
            m_cbAccount.DataSource = bindingSource;
            m_cbAccount.DisplayMember = "Title";
            m_cbAccount.ValueMember = "Entry";

            // Entry sync config controls.
            Debug.Assert(m_txtFolder is TextBox);
            var binding = new Binding("Text",
                bindingSource,
                "ActiveFolder");
            m_txtFolder.DataBindings.Add(binding);
            Debug.Assert(m_chkDontSaveAuthToken is CheckBox);
            binding = new Binding("Checked", bindingSource,
                "DontSaveAuthToken");
            binding.DataSourceUpdateMode = DataSourceUpdateMode.OnValidation;
            m_chkDontSaveAuthToken.DataBindings.Add(binding);

            // Global default auth controls.
            Debug.Assert(m_txtFolderDefault is TextBox);
            binding = new Binding("Text",
                m_data, "DefaultAppFolder");
            m_txtFolderDefault.DataBindings.Add(binding);

            // Enabled command controls.
            Debug.Assert(m_chkSyncEnabled is CheckBox);
            binding = new Binding("Checked",
                m_data, "CmdSyncEnabled");
            binding.DataSourceUpdateMode =
                DataSourceUpdateMode.OnPropertyChanged;
            m_chkSyncEnabled.DataBindings.Add(binding);
            Debug.Assert(m_chkDownloadEnabled is CheckBox);
            binding = new Binding("Checked",
                m_data, "CmdDownloadEnabled");
            m_chkDownloadEnabled.DataBindings.Add(binding);
            Debug.Assert(m_chkUploadEnabled is CheckBox);
            binding = new Binding("Checked",
                m_data, "CmdUploadEnabled");
            m_chkUploadEnabled.DataBindings.Add(binding);

            // Auto-sync controls.
            Debug.Assert(m_chkSyncOnOpen is CheckBox);
            binding = new Binding("Checked",
                m_data, "SyncOnOpen");
            m_chkSyncOnOpen.DataBindings.Add(binding);
            binding = new Binding("Enabled",
                m_data, "CmdSyncEnabled");
            m_chkSyncOnOpen.DataBindings.Add(binding);
            Debug.Assert(m_chkSyncOnSave is CheckBox);
            binding = new Binding("Checked",
                m_data, "SyncOnSave");
            binding.ControlUpdateMode = ControlUpdateMode.OnPropertyChanged;
            binding.DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged;
            m_chkSyncOnSave.DataBindings.Add(binding);
            binding = new Binding("Enabled",
                m_data, "CmdSyncEnabled");
            m_chkSyncOnSave.DataBindings.Add(binding);
            Debug.Assert(m_chkDontSaveAuthDefault is CheckBox);
            binding = new Binding("Checked", m_data,
                "DefaultDontSaveAuthToken");
            m_chkDontSaveAuthDefault.DataBindings.Add(binding);
            Debug.Assert(m_chkWarnAuthToken is CheckBox);
            binding = new Binding("Checked", m_data,
                "WarnOnSavedAuthToken");
            m_chkWarnAuthToken.DataBindings.Add(binding);
            Debug.Assert(m_chkSyncOnReopen is CheckBox);
            binding = new Binding("Checked", m_data,
                "AutoResumeSaveSync");
            m_chkSyncOnReopen.DataBindings.Add(binding);
            binding = new Binding("Enabled", m_data,
                "SyncOnSave");
            binding.ControlUpdateMode = ControlUpdateMode.OnPropertyChanged;
            binding.DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged;
            m_chkSyncOnReopen.DataBindings.Add(binding);

            // Select first "active" entry in the accounts combo.
            IEnumerable<EntryConfiguration> actives = m_data.Entries
                .Where(e => e.ActiveAccount.HasValue &&
                            e.ActiveAccount.Value);
            if (actives.Any())
            {
                m_cbAccount.SelectedItem = actives.First();
                bindingSource.ResetBindings(false);
            }

            // Initialize link handlers.
            m_lnkGoogle.LinkClicked += (o, e) => Process.Start(GdsDefs.UrlGoogleDev);
            m_lnkHelp.LinkClicked += (o, e) => Process.Start(GdsDefs.UrlHelp);
            m_lnkGoogle2.LinkClicked += (o, e) => Process.Start(GdsDefs.UrlGoogleDev);
            m_lnkHelp2.LinkClicked += (o, e) => Process.Start(GdsDefs.UrlHelp);
            m_lnkAuthTokenDefaultsHelp.LinkClicked += (o, e) => Process.Start(GdsDefs.UrlSharedFileHelp);
            m_lnkAuthTokenHelp.LinkClicked += (o, e) => Process.Start(GdsDefs.UrlSharedFileHelp);

            // Manage tab changes to prevent invalid data entry.
            m_tabMain.Deselecting += HandleTabChangeValidation;

            // Don't disable all commands.
            m_chkSyncEnabled.CheckedChanged += HandleCommandDisabled;
            m_chkDownloadEnabled.CheckedChanged += HandleCommandDisabled;
            m_chkUploadEnabled.CheckedChanged += HandleCommandDisabled;

            // More oddball color picker UI handling.
            m_txtFolderDefault.Validated += HandleDefaultFolderValidated;

            // OK button handler
            m_btnOK.Click += HandleOkClicked;

            // Initialize KeePass dialog banner.
            string filePath = DatabaseFilePath;
            if (filePath.Length > 60)
            {
                m_toolTipper.SetToolTip(m_bannerImage, DatabaseFilePath);
                string fileName = System.IO.Path.GetFileName(filePath);
                if (fileName.Length > 50)
                {
                    DatabaseFilePath = "...\\" + fileName;
                }
                else
                {
                    DatabaseFilePath = filePath.Substring(0, 50-fileName.Length) + "...\\" + fileName;
                }
            }
            BannerFactory.CreateBannerEx(this, m_bannerImage,
                Resources.GetBitmap("round_settings_black_48dp"),
                Resources.GetString("Title_ConfigDialog"),
                Resources.GetFormat("Lbl_CurrentDbFmt", DatabaseFilePath));

            // Initialize tab images.
            ScaleImages(Forms.ScalingFactor);
            m_tabGSignIn.ImageKey = GSigninTabIcoKey;
            m_tabOptions.ImageKey = GeneralTabIcoKey;
            m_btnAbout.ImageKey = AboutIcoKey;

            // About button handler
            m_btnAbout.Click += HandleAboutClicked;
            base.OnLoad(args);
        }

        void ScaleImages(SizeF factor)
        {
            const int DesignSquare = 16;
            m_imgList.Images.Clear();
            string dpSize;
            if (factor.Width > 2)
            {
                dpSize = "48";
            }
            else if (factor.Width > 1)
            {
                dpSize = "36";
            }
            else
            {
                dpSize = "18";
            }
            m_imgList.ImageSize = new Size
            {
                Width = (int)(factor.Width * DesignSquare),
                Height = (int)(factor.Height * DesignSquare)
            };
            m_imgList.Images.Add(GSigninTabIcoKey,
                Resources.GetBitmap(
                    string.Format("outline_security_black_{0}dp", dpSize)));
            m_imgList.Images.Add(GeneralTabIcoKey,
                Resources.GetBitmap(
                    string.Format("outline_settings_black_{0}dp", dpSize)));
            m_imgList.Images.Add(AboutIcoKey,
                Resources.GetBitmap(
                    string.Format("round_help_outline_black_{0}dp", dpSize)));
        }

        private void HandleAboutClicked(object sender, EventArgs e)
        {
            Form f = Forms.GetNewAboutForm(new AboutData(), Images.GdsyncIcon);
            f.ShowDialog(this);
        }

        // Don't allow the last enabled command to be disabled.
        private void HandleCommandDisabled(object sender, EventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            Debug.Assert(cb != null, "invalid sender");
            if (!cb.Checked)
            {
                cb.Checked = !m_chkDownloadEnabled.Checked &&
                    !m_chkUploadEnabled.Checked &&
                    !m_chkSyncEnabled.Checked;
            }
        }

        private void HandleProtectedStringParsing(object sender, ConvertEventArgs e)
        {
            Debug.Assert(e.DesiredType == typeof(ProtectedString));
            Debug.Assert(e.Value == null || e.Value.GetType() == typeof(string));
            string strVal = e.Value as string;
            e.Value = string.IsNullOrEmpty(strVal) ? null :
                new ProtectedString(true, strVal);
        }

        private void HandleProtectedStringFormatting(object sender, ConvertEventArgs e)
        {
            Debug.Assert(e.DesiredType == typeof(string));
            Debug.Assert(e.Value == null || e.Value.GetType() == typeof(ProtectedString));
            e.Value = e.Value == null ? string.Empty :
                ((ProtectedString)e.Value).ReadString();
        }

        private void HandleDefaultFolderValidated(object sender, EventArgs e)
        {
            bool bDefaultFolderSpecified = 
                !string.IsNullOrWhiteSpace(m_txtFolderDefault.Text);
            m_btnGetColors.Enabled = !m_bColorsQueried && bDefaultFolderSpecified;
            m_cbColors.Enabled = !(m_cbColors.Items.Count == 1 &&
                                    m_cbColors.SelectedItem == m_nullColor) &&
                                    bDefaultFolderSpecified;
        }

        private void HandleTabChangeValidation(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPage == m_tabGSignIn)
            {
                e.Cancel = !EntryClientIdStateIsValid();
            }
            else if (e.TabPage == m_tabOptions)
            {
                e.Cancel = !DefaultClientIdStateIsValid();
            }
            if (e.Cancel)
            {
                MessageBox.Show(Resources.GetFormat("Msg_OauthCredsInvalidFmt",
                                                    GdsDefs.ProductName),
                                GdsDefs.ProductName,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void HandleBoolNegation(object sender,
                                                ConvertEventArgs e)
        {
            e.Value = !((bool)e.Value);
        }

        private void HandleColorsSelectedIndexChanged(object sender,
                                                        EventArgs e)
        {
            GoogleColor item = m_cbColors.Items
                                    .Cast<GoogleColor>()
                                    .ElementAt(m_cbColors.SelectedIndex);
            m_cbColors.BackColor = item.Color;
            m_data.DefaultAppFolderColor = item == m_nullColor ? null : item;
        }

        private async void HandleColorsComboLazyLoad(object sender,
                                                        EventArgs args)
        {
            if (m_bColorsQueried)
            {
                return;
            }

            Cursor current = Cursor;
            Cursor = Cursors.WaitCursor;
            try
            {
                m_cbColors.Items.Clear();
                m_cbColors.Items.Add(m_nullColor);
                IEnumerable<Color> colors = await m_data.GetColors();
                m_cbColors.Items.AddRange(new GoogleColorCollection(colors)
                                                .Cast<object>()
                                                .ToArray());
                m_cbColors.Enabled = true;
                m_cbColors.Focus();
                m_cbColors.DroppedDown = true;

                // If the query succeeds there should be the default item and
                // the returned colors.
                m_bColorsQueried = m_cbColors.Items.Count > 1;
                m_btnGetColors.Enabled = !m_bColorsQueried;
            }
            catch (Exception e)
            {
                Debug.Fail(e.ToString());
            }
            finally
            {
                Cursor = current;
            }
        }

        private void HandleColorsDrawItem(object sender, DrawItemEventArgs e)
        {
            Debug.Assert(ReferenceEquals(sender, m_cbColors));

            ComboBox cb = ((ComboBox)sender);
            if (0 > e.Index || e.Index > cb.Items.Count)
            {
                return;
            }

            // Draw a combo box item using the color as a background.
            Graphics g = e.Graphics;
            Rectangle rect = e.Bounds;

            // Get the color proxy object.
            GoogleColor item = (GoogleColor)cb.Items[e.Index];

            // Background fill color painting.
            Brush brush = new SolidBrush(item.Color);
            g.FillRectangle(brush, rect.X, rect.Y, rect.Width, rect.Height);

            // Foreground is the color name in black.
            g.DrawString(item.ToString(), cb.Font,
                        Brushes.Black, rect.X, rect.Top);
        }

        private void HandleOkClicked(object sender, EventArgs e)
        {
            if (DialogResult != DialogResult.OK)
            {
                return;
            }

            // Validate state of dialog before closing it.
            if (m_tabMain.SelectedTab == m_tabGSignIn &&
                !EntryClientIdStateIsValid())
            {
                DialogResult = DialogResult.None;
            }
            else if (m_tabMain.SelectedTab == m_tabOptions &&
                !DefaultClientIdStateIsValid())
            {
                DialogResult = DialogResult.None;
            }
            if (DialogResult == DialogResult.None)
            {
                MessageBox.Show(
                    Resources.GetFormat("Msg_OauthCredsInvalidFmt",
                                        GdsDefs.ProductName),
                    GdsDefs.ProductName,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            // In the case of changing OAuth creds with a refresh token
            // present, confirm the user's intention.
            if  (DialogResult == DialogResult.OK &&
                m_data.SelectedAccountShadow.IsStaleRefreshToken)
            {
                DialogResult = MessageBox.Show(this,
                    Resources.GetString("Msg_ChangedCredsDeletesToken"),
                    GdsDefs.ProductName,
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button2);
                if (DialogResult != DialogResult.OK)
                {
                    DialogResult = DialogResult.None;
                }
            }
        }

        bool EntryClientIdStateIsValid()
        {
            // Deprecated, always returns valid because the underlying item no longer exists
            return true;
        }

        bool DefaultClientIdStateIsValid()
        {
            // Deprecated, always returns valid because the underlying item no longer exists
            return true;
        }

        public string DatabaseFilePath { get; set; }

        private async void HandleAuthorizeFilesAction(object sender, EventArgs e)
        {
            await m_data.PickFile();
        }
    }
}
