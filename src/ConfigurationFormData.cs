/**
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

using KeePassLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using FilePicker;
using Microsoft.CodeAnalysis;

namespace KPSyncForDrive
{
    class ConfigurationFormData : IDisposable, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public delegate Task<IEnumerable<Color>> ColorProvider(
            EntryConfiguration ec, DatabaseContext dbCtx);

        public delegate Task<Optional<FilePick>> FilePickerDelegate(EntryConfiguration ec);

        IEnumerable<Color> m_colors;
        readonly ColorProvider m_colorProvider;
        readonly FilePickerDelegate _mPickerDelegate;
        readonly PwDatabase m_db;
        PluginConfig m_config;

        public ConfigurationFormData(IList<EntryConfiguration> entries,
            ColorProvider colorProvider, FilePickerDelegate pickerDelegate, PwDatabase db)
        {
            Entries = entries;
            EntryBindingSource = new BindingSource
            {
                DataSource = Entries
            };

            m_colors = null;
            m_colorProvider = colorProvider;
            _mPickerDelegate = pickerDelegate;
            m_db = db;
            m_config = PluginConfig.GetCopyOfDefault();
        }

        protected void Dispose(bool bIsDisposing)
        {
            if (bIsDisposing)
            {
                EntryBindingSource.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }

        public PluginConfig PluginConfig
        {
            get
            {
                return m_config;
            }
        }

        public EntryConfiguration SelectedAccountShadow
        {
            get
            {
                return EntryBindingSource.IsBindingSuspended ?
                    null : EntryBindingSource.Current as EntryConfiguration;
            }
        }

        public BindingSource EntryBindingSource { get; private set; }

        public IList<EntryConfiguration> Entries { get; private set; }

        public bool CmdSyncEnabled
        {
            get
            {
                return m_config.IsCmdEnabled(SyncCommands.SYNC);
            }
            set
            {
                if (m_config.IsCmdEnabled(SyncCommands.SYNC) != value)
                {
                    m_config.EnableCmd(SyncCommands.SYNC, value);
                    RaisePropertyChanged("CmdSyncEnabled");
                }
            }
        }

        public bool CmdUploadEnabled
        {
            get
            {
                return m_config.IsCmdEnabled(SyncCommands.UPLOAD);
            }
            set
            {
                if (m_config.IsCmdEnabled(SyncCommands.UPLOAD) != value)
                {
                    m_config.EnableCmd(SyncCommands.UPLOAD, value);
                    RaisePropertyChanged("CmdUploadEnabled");
                }
            }
        }

        public bool CmdDownloadEnabled
        {
            get
            {
                return m_config.IsCmdEnabled(SyncCommands.DOWNLOAD);
            }
            set
            {
                if (m_config.IsCmdEnabled(SyncCommands.DOWNLOAD) != value)
                {
                    m_config.EnableCmd(SyncCommands.DOWNLOAD, value);
                    RaisePropertyChanged("CmdDownloadEnabled");
                }
            }
        }

        public bool SyncOnOpen 
        {
            get
            {
                return m_config.IsAutoSync(AutoSyncMode.OPEN);
            }
            set
            {
                if (m_config.IsAutoSync(AutoSyncMode.OPEN) != value)
                {
                    m_config.EnableAutoSync(AutoSyncMode.OPEN, value);
                    RaisePropertyChanged("SyncOnOpen");
                }
            }
        }

        public bool SyncOnSave 
        {
            get
            {
                return m_config.IsAutoSync(AutoSyncMode.SAVE);
            }
            set
            {
                if (m_config.IsAutoSync(AutoSyncMode.SAVE) != value)
                {
                    m_config.EnableAutoSync(AutoSyncMode.SAVE, value);
                    RaisePropertyChanged("SyncOnSave");
                    if (!value)
                    {
                        AutoResumeSaveSync = false;
                    }
                }
            }
        }

        public string DefaultAppFolder 
        {
            get
            {
                return m_config.Folder.Trim();
            }
            set
            {
                if (!string.Equals(DefaultAppFolder, value,
                    StringComparison.InvariantCultureIgnoreCase))
                {
                    m_config.Folder = value ?? string.Empty;
                    RaisePropertyChanged("DefaultAppFolder");
                }
            }
        }

        public GoogleColor DefaultAppFolderColor
        {
            get
            {
                return m_config.FolderColor;
            }
            set
            {
                m_config.FolderColor = value;
                RaisePropertyChanged("DefaultAppFolderColor");
            }
        }

        public bool DefaultDontSaveAuthToken
        {
            get
            {
                return m_config.DontSaveAuthToken;
            }
            set
            {
                if (m_config.DontSaveAuthToken != value)
                {
                    m_config.DontSaveAuthToken = value;
                    RaisePropertyChanged("DefaultDontSaveAuthToken");
                }
            }
        }

        public bool WarnOnSavedAuthToken
        {
            get
            {
                return m_config.WarnOnSavedAuthToken;
            }
            set
            {
                if (m_config.WarnOnSavedAuthToken != value)
                {
                    m_config.WarnOnSavedAuthToken = value;
                    RaisePropertyChanged("WarnOnSavedAuthToken");
                }
            }
        }

        public bool AutoResumeSaveSync
        {
            get
            {
                return SyncOnSave && m_config.AutoResumeSaveSync;
            }
            set
            {
                if (m_config.AutoResumeSaveSync != value)
                {
                    m_config.AutoResumeSaveSync = value;
                    RaisePropertyChanged("AutoResumeSaveSync");
                }
            }
        }

        public async Task<IEnumerable<Color>> GetColors()
        {
            if (m_colors == null)
            {
                EntryConfiguration current;
                current = EntryBindingSource.Current as EntryConfiguration;
                IEnumerable<Color> result
                    = await m_colorProvider(current, new DatabaseContext(m_db));
                if (!result.Any())
                {
                    return result;
                }
                m_colors = result;
            }
            return m_colors;
        }

        void RaisePropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

        public async Task PickFile()
        {
            await _mPickerDelegate(EntryBindingSource.Current as EntryConfiguration);
        }
    }
}
