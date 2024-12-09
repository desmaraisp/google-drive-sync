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

using KeePass.DataExchange;
using KeePass.Plugins;
using KeePassLib;
using KeePassLib.Collections;
using KeePassLib.Interfaces;
using KeePassLib.Security;
using KeePassLib.Serialization;
using System.IO;
using System.Windows.Forms;

namespace KPSyncForDrive
{
    internal class PluginEntryFactory : FileFormatProvider
    {
        public static PluginEntryFactory CreateDefault(string title)
        {
            PluginConfig appConfig = PluginConfig.Default;
            return Create(title,
                appConfig.Folder,
                appConfig.DontSaveAuthToken);
        }

        private static PluginEntryFactory Create(string title,
            string folder, bool dontSaveAuthToken)
        {
            PwEntry entry = new PwEntry(true, true);
            ProtectedStringDictionary strings = entry.Strings;
            strings.Set(PwDefs.TitleField,
                new ProtectedString(false, title));
            strings.Set(PwDefs.NotesField,
                new ProtectedString(false,
                    Resources.GetFormat("Msg_NewEntryNotesFmt",
                                        GdsDefs.ProductName)));
            strings.Set(PwDefs.UrlField,
                new ProtectedString(false, GdsDefs.AccountSearchString));

            StringDictionaryEx data = entry.CustomData;
            data.Set(SyncConfiguration.EntryActiveAppFolderKey, folder);
            data.Set(SyncConfiguration.EntryActiveAccountKey,
                        SyncConfiguration.EntryActiveAccountTrueKey);
            data.Set(SyncConfiguration.EntryDontCacheAuthTokenKey,
                dontSaveAuthToken ?
                GdsDefs.ConfigTrue : GdsDefs.ConfigFalse);
            data.Set(SyncConfiguration.EntryVersionKey,
                SyncConfiguration.CurrentVersion.ToString(2));

            entry.IconId = PwIcon.WorldComputer;
            return new PluginEntryFactory(entry);
        }

        public static PwEntry Import(IPluginHost host,
            PwDatabase database,
            PluginEntryFactory creator)
        {
            Form fParent = host.MainWindow;
            IUIOperations uiOps = host.MainWindow;
            IOConnectionInfo[] vCx = new IOConnectionInfo[] { };
            bool? success = ImportUtil.Import(database, creator,
                vCx, false, uiOps, false, fParent);
            if (success.HasValue && success.Value &&
                host.MainWindow.GetSelectedGroup()
                    == database.RootGroup)
            {
                host.MainWindow.UpdateUI(false, null, false, null,
                    true, database.RootGroup, true);
            }
            return creator.Entry;
        }

        PluginEntryFactory(PwEntry entry)
        {
            Entry = entry;
        }

        public PwEntry Entry { get; private set; }

        public override void Import(PwDatabase pwStorage,
            Stream sInput, IStatusLogger slLogger)
        {
            pwStorage.RootGroup.AddEntry(Entry, true);
        }

        public override bool ImportAppendsToRootGroupOnly
        {
            get
            {
                return true;
            }
        }

        public override bool SupportsImport
        {
            get
            {
                return true;
            }
        }

        public override bool SupportsExport
        {
            get
            {
                return false;
            }
        }

        public override string FormatName
        {
            get
            {
                return GetType().FullName + '-' +
                    SyncConfiguration.CurrentVersion.ToString(2);
            }
        }
    }
}
