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
using KeePassLib.Collections;
using KeePassLib.Security;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace KPSyncForDrive
{
    public abstract class SyncConfiguration
    {
        // Ver0
        //    clientID/secret present => custom client id
        //    clientID/secret missing => legacy client id
        //
        // Ver1.0
        //    if Use legacy flag missing or false
        //     => new app client id
        //    else
        //     clientID/secret present => custom client id
        //     clientID/secret missing => legacy client id
        //
        // Ver1.1
        //  If refresh token present and cache flag
        //  not present, cache flag == false is implied.

        protected const string Ver0 = "0.0"; // virtual version
        protected const string Ver1_0 = "1.0";
        protected const string Ver1_1 = "1.1";
        protected const string CurrentVer = Ver1_1;

        public const string EntryRefreshTokenKey = "GoogleSync.RefreshToken";
        public const string EntryActiveAccountKey = "GoogleSync.ActiveAccount";
        public const string EntryActiveAccountFalseKey = EntryActiveAccountKey + "." + GdsDefs.ConfigFalse;
        public const string EntryActiveAccountTrueKey = EntryActiveAccountKey + "." + GdsDefs.ConfigTrue;
        public const string EntryActiveAppFolderKey = "GoogleSync.ActiveAppFolder";
        public const string EntryVersionKey = "GoogleSync.ConfigVersion";
        public const string EntryDontCacheAuthTokenKey = "GoogleSync.NoAuthTokens";

        public static Version CurrentVersion
        {
            get { return Version.Parse(CurrentVer); }
        }

        public static bool IsPriorToVer1_0(SyncConfiguration config)
        {
            return config.Version < Version.Parse(Ver1_0);
        }

        // KeePass string fields.
        public abstract string LoginHint { get; }
        public abstract ProtectedString RefreshToken { get; set; }
        public abstract string ActiveFolder { get; set; }
        public abstract bool DontSaveAuthToken { get; set; }
        public abstract Version Version { get; }
    }

    /// <summary>
    /// Mirror, and defer incremental modifications to, PwEntry object
    /// "Strings" properties.  This mainly serves as the data model
    /// for the PwEntry-backed properties on the configuration dialog.
    /// </summary>
    public class EntryConfiguration : SyncConfiguration
    {
        readonly Dictionary<string, object> m_changes;
        DateTime m_touched;
        bool m_credsChanged;

        public EntryConfiguration(PwEntry entry)
        {
            Entry = entry;
            m_changes = new Dictionary<string, object>(5);
            m_touched = Entry.LastModificationTime;
            m_credsChanged = false;
            ChangesCommitted = false;
        }

        ProtectedStringDictionary Strings
        {
            get
            {
                return Entry.Strings;
            }
        }

        StringDictionaryEx CustomData
        {
            get
            {
                return Entry.CustomData;
            }
        }

        public PwEntry Entry { get; private set; }

        public PwEntry CommitChangesIfAny()
        {
            EnsureSettingsMigration();
            if (!IsModified)
            {
                ChangesCommitted = false;
            }
            else
            {
                foreach (KeyValuePair<string, object> kv in m_changes)
                {
                    switch (kv.Key)
                    {
                        case EntryActiveAccountKey:
                        case EntryActiveAppFolderKey:
                        case EntryVersionKey:
                        case EntryDontCacheAuthTokenKey:
                            string stringVal = kv.Value as string;
                            CustomData.Set(kv.Key, 
                                stringVal == null ? string.Empty : stringVal);
                            break;
                        case EntryRefreshTokenKey:
                            ProtectedString ps = kv.Value as ProtectedString;
                            CustomData.Set(kv.Key,
                                ps == null ? string.Empty : ps.ReadString());
                            break;
                        default:
                            Debug.Fail("Unknown key!!");
                            break;
                    }
                }
                m_changes.Clear();
                ChangesCommitted = true;
            }
            return Entry;
        }

        /// <summary>
        /// Indicates that there are changes that have not been committed to
        /// the Entry object yet.  The property is set and reset by
        /// incremental changes to the properties mirroring Entry.
        /// </summary>
        public bool IsModified
        {
            get
            {
                return m_changes.Keys.Any();
            }
        }

        /// <summary>
        /// Indicates there are uncommitted changes to the OAuth 2.0-related
        /// properties and a refresh token that doesn't match them, or
        /// an existing refresh token is being otherwise removed (by say,
        /// session-stored tokens request).
        /// </summary>
        public bool IsStaleRefreshToken
        {
            get
            {
                return (m_changes.Keys.Any(k =>
                            k == EntryRefreshTokenKey) &&
                        RefreshToken.IsNullOrEmpty() &&
                        !Get(EntryRefreshTokenKey).IsNullOrEmpty());
            }
        }

        /// <summary>
        /// Indicates that changes have been made and committed to the Entry
        /// object.  You might want to save the database if Entry is contained
        /// in it, for example.  This property is set when IsModified is true
        /// when the CommitChangesIfAny method is called.  You can also set
        /// this as a flag in the constructor overload.
        /// </summary>
        public bool ChangesCommitted 
        {
            get
            {
                return m_touched < Entry.LastModificationTime;
            }
            private set
            {
                bool prevVal = ChangesCommitted;
                if (value)
                {
                    Entry.Touch(true);
                }
                else if (!prevVal)
                {
                    m_touched = Entry.LastModificationTime;
                }
            }
        }

        /// <summary>
        /// Indicates that changes have been committed to the entry which
        /// include the app credentials-related properties.  Initially
        /// false. Set true by CommitChangesIfAny() if necessary.  Set
        /// to false by Reset().
        /// </summary>
        public bool CredentialsChanged
        {
            get
            {
                return m_credsChanged;
            }
        }

        public bool Reset()
        {
            m_credsChanged = false;
            DateTime prevTouch = m_touched;
            m_touched = Entry.LastModificationTime;
            return prevTouch < Entry.LastModificationTime;
        }

        public override string LoginHint
        {
            get
            {
                return Strings.ReadSafe(PwDefs.UserNameField);
            }
        }

        public string User
        {
            get
            {
                return Strings.ReadSafe(PwDefs.UserNameField);
            }
        }

        public ProtectedString Password
        {
            get
            {
                return Strings.Get(PwDefs.PasswordField);
            }
        }

        T GetValue<T>(string key, Func<string, T> getter) where T : class
        {
            object retVal;
            if (!m_changes.TryGetValue(key, out retVal))
            {
                retVal = getter(key);
            }
            return retVal as T;
        }

        void SetValue(string key, string value)
        {
            string curVal = ReadSafe(key);
            if (string.Equals(curVal, value, StringComparison.Ordinal))
            {
                m_changes.Remove(key);
            }
            else
            {
                m_changes[key] = value;
            }
        }

        void SetValue(string key, ProtectedString value)
        {
            ProtectedString curVal = Get(key);
            if (curVal != null)
            {
                if (value != null &&
                    curVal.OrdinalEquals(value, true))
                {
                    // Changed back to the original value.
                    m_changes.Remove(key);
                }
                else
                {
                    m_changes[key] = value;
                }
            }
            else if (value != null)
            {
                // Entry value null, given value non-null.
                m_changes[key] = value;
            }
            else
            {
                // Both null.
                m_changes.Remove(key);
            }
        }

        string ReadSafe(string key)
        {
            if (CustomData.Exists(key))
            {
                return CustomData.Get(key);
            }
            if (Strings.Exists(key))
            {
                // Copy to plug-in data area.
                string value = Strings.ReadSafe(key);
                CustomData.Set(key, value);
                ChangesCommitted = true;
                return value;
            }
            return string.Empty;
        }

        ProtectedString GetSafe(string key)
        {
            if (CustomData.Exists(key))
            {
                return new ProtectedString(true, CustomData.Get(key));
            }
            if (Strings.Exists(key))
            {
                // A requested key exists in the legacy location.  Get it from
                // CustomData from now on.
                ProtectedString value = Strings.Get(key);
                CustomData.Set(key, value.ReadString());
                ChangesCommitted = true;
                return value;
            }
            return GdsDefs.PsEmptyEx;
        }

        ProtectedString Get(string key)
        {
            if (CustomData.Exists(key))
            {
                // For key users that may expect null values, an empty string
                // in CustomData will now imply the null value.
                string value = CustomData.Get(key);
                return string.IsNullOrEmpty(value) ? null :
                    new ProtectedString(true, value);
            }
            if (Strings.Exists(key))
            {
                // $$BUG
                // If this plugin is used SxS with the legacy plugin, this key
                // could relay changes made by the legacy that don't apply to 
                // this plugin; specifically, a previously null value in the 
                // legacy plugin could be changed to non-null, and subseqently
                // be retrieved here.

                // A requested key exists in the legacy location.  Get it from
                // CustomData from now on.
                ProtectedString value = Strings.Get(key);
                CustomData.Set(key, value.ReadString());
                ChangesCommitted = true;
                return value;
            }
            return null;
        }

        public bool? ActiveAccount
        {
            get
            {
                string stringVal = GetValue(EntryActiveAccountKey, ReadSafe);
                if (stringVal == EntryActiveAccountFalseKey)
                {
                    return false;
                }
                else if (stringVal == EntryActiveAccountTrueKey)
                {
                    return true;
                }
                return null;
            }
            set
            {
                if (!value.HasValue)
                {
                    SetValue(EntryActiveAccountKey, (string)null);
                }
                else if (value.Value)
                {
                    SetValue(EntryActiveAccountKey, EntryActiveAccountTrueKey);
                }
                else // !value.Value
                {
                    SetValue(EntryActiveAccountKey, EntryActiveAccountFalseKey);
                }
            }
        }

        public override ProtectedString RefreshToken
        {
            get
            {
                return GetValue(EntryRefreshTokenKey, Get);
            }
            set
            {
                ProtectedString newVal = DontSaveAuthToken ?
                    GdsDefs.PsEmptyEx : value;
                SetValue(EntryRefreshTokenKey, newVal);
            }
        }

        public override string ActiveFolder
        {
            get
            {
                return GetValue(EntryActiveAppFolderKey, ReadSafe);
            }
            set
            {
                SetValue(EntryActiveAppFolderKey, value);
            }
        }

        public override bool DontSaveAuthToken
        {
            get
            {
                return GdsDefs.ConfigTrue ==
                    GetValue(EntryDontCacheAuthTokenKey, ReadSafe);
            }
            set
            {
                SetValue(EntryDontCacheAuthTokenKey,
                    value ? GdsDefs.ConfigTrue : GdsDefs.ConfigFalse);
                if (value)
                {
                    RefreshToken = GdsDefs.PsEmptyEx;
                }
            }
        }

        public override Version Version
        {
            get
            {
                string strVer = GetValue(EntryVersionKey, ReadSafe);
                Version retVal;
                if (!Version.TryParse(strVer, out retVal))
                {
                    retVal = Version.Parse(Ver0);
                }
                return retVal;
            }
        }

        void EnsureSettingsMigration()
        {
            if (Version >= CurrentVersion)
            {
                return;
            }

            // Only upgrade the version if all properties associated with the
            // particular version level are present.
            if (Version < Version.Parse(Ver1_0))
            {
                SetValue(EntryVersionKey, Ver1_0);
            }

            if (Version < Version.Parse(Ver1_1))
            {
                if (!CustomData.Exists(EntryDontCacheAuthTokenKey))
                {
                    DontSaveAuthToken = PluginConfig.Default.DontSaveAuthToken;
                }
                SetValue(EntryVersionKey, Ver1_1);
            }

            Debug.Assert(Version == CurrentVersion);
        }
    }
}
