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

using System;
using System.Reflection;
using KPSyncForDrive.WindowsControls;

namespace KPSyncForDrive
{
    public class AboutData : IAboutData
    {
        public AboutData()
        {
            CopyrightText = Assembly
                .GetAssembly(typeof(ConfigurationForm))
                .GetCustomAttribute<AssemblyCopyrightAttribute>()
                .Copyright;
            SemVer = GdsDefs.Version;
            WebsiteLink = new Uri(GdsDefs.UrlHome);
            WebsiteLinkText = Resources.GetString("Lnk_Home");
            PrivacyLink = new Uri(GdsDefs.UrlPrivacy);
            PrivacyLinkText = Resources.GetString("Lnk_PrivacyPolicy");
            Gs3Attribution = Resources.GetString("Lbl_LegacyAttribution");
        }

        public string WebsiteLinkText { get; private set; }

        public Uri WebsiteLink { get; private set; }

        public string PrivacyLinkText { get; private set; }

        public Uri PrivacyLink { get; private set; }

        public string CopyrightText { get; private set; }

        public string Gs3Attribution { get; private set; }

        public string SemVer { get; private set; }
    }
}
