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

using KeePassLib.Security;
using System.Reflection;

namespace KPSyncForDrive
{
    static partial class GdsDefs
    {
        static string s_productName;
        static string s_productVersion;
        static ProtectedString s_emptyEx;

        public static string ProductName
        {
            get
            {
                if (s_productName == null)
                {
                    Assembly assembly = Assembly.GetExecutingAssembly();
                    object[] attrs = assembly.GetCustomAttributes(
                        typeof(AssemblyTitleAttribute), false);
                    AssemblyTitleAttribute assemblyTitle;
                    assemblyTitle = attrs[0] as AssemblyTitleAttribute;
                    s_productName = assemblyTitle.Title;
                }
                return s_productName;
            }
        }

        public static string Version
        {
            get
            {
                if (s_productVersion == null)
                {
                    Assembly assembly = Assembly.GetExecutingAssembly();
                    object[] attrs = assembly.GetCustomAttributes(
                        typeof(AssemblyInformationalVersionAttribute), false);
                    AssemblyInformationalVersionAttribute asmVer;
                    asmVer = attrs[0] as AssemblyInformationalVersionAttribute;
                    s_productVersion = asmVer.InformationalVersion;
                }
                return s_productVersion;
            }
        }

        // $$REVIEW
        // ProtectedString.EmptyEx is not available until after the current target
        // release (2.35).
        public static ProtectedString PsEmptyEx
        {
            get
            {
                if (s_emptyEx == null)
                {
                    s_emptyEx = new ProtectedString(true, new byte[0]);
                }
                return s_emptyEx;
            }
        }

        public const string ConfigUUID = "GoogleSync.AccountUUID";

        public const string ConfigTrue = "TRUE";
        public const string ConfigFalse = "FALSE";

        public const string AccountSearchString = "accounts.google.com";
        public const string UrlDomainRoot = "kpsync.org";
        public const string UrlDomain = "www." + UrlDomainRoot;
        public const string UrlHome = "https://" + UrlDomain;
        public const string UrlHelp = UrlHome;
        public const string UrlGoogleDev = "https://console.developers.google.com/start";
        public const string UrlGoogleDrive = "https://drive.google.com";
        public const string UrlSignInHelp = "https://developers.google.com/identity/sign-in/web/troubleshooting";
        public const string UrlSharedFileHelp = UrlHome + "/notices/sharedsec";
        public const string UrlPersonalAppCreds = UrlHome + "/usage/oauth";
        public const string UrlTokenHandling = UrlHome + "/usage/authorize#authorization-tokens";
        public const string UrlUpgradeV1 = UrlHome + "/install/upgrade1";
        public const string UrlPrivacy = UrlHome + "/privacy";
        public const string GsyncBackupExt = ".gsyncbak";
        public const string MimeTypeFolder = "application/vnd.google-apps.folder";
        public const string MimeTypeShortcut = "application/vnd.google-apps.shortcut";
        public const int DefaultDotNetFileBufferSize = 4096;
    }

}
