## 4.1.0

There are only a few bugfixes and enhancements in this release:

* Several modifications to address issues related to the [Auto Sync](https://www.kpsync.org/usage/autosync) feature, as mentioned in #49 and #50. If you continue to experience these problems in this release, do let us know.
* The [configuration](https://www.kpsync.org/install/config) UI has undergone a minor makeover.  This includes improvements in visual performance for higher pixel density displays.

#### Release Notes

Though unresolved [issues](https://github.com/walterpg/google-drive-sync/issues) and many reasonable enhancement requests remain, it appears that most  who have used and commented on the operation of the plugin are generally satisfied with its day-to-day performance. Google reports that in the last 30 days the plugin successfully exercised Drive transactions at an average rate of 2-3 per minute. We are therefore pleased to announce this first "General Availability" release.

Apologies again for the delay, and not yet addressing the concerns of all users. Life has a curious habit of distracting us from our favorite endeavors. It is our *intention* to pick up the pace with new features in the new year. As always your involvement and support are most welcome.

---
## 4.0.7-beta

#### [Important: do not use KeePass 2.48 with this or the prior two plugin releases.](https://www.kpsync.org/notices/kp2-48-save)  The [2.48.1](https://sourceforge.net/projects/keepass/files/KeePass%202.x/2.48.1/KeePass-2.48.1-Setup.exe/download) release fixes a blocking issue, and earlier KeePass releases do not appear to exhibit the problem.
 
* Several backlog bugfixes, including issue #32, #18, and (with any luck) #37 and #27.
* Rudimentary diagnostic logging feature (partially implementing #33).
* Fix to use new app creds by default in new "clean" installation and databases.
* Fix for #36, auto sync ops disrupted by KP auto-lock, save-on-exit, etc.
* New plugin option to automatically handle deferred auto-sync-on-save ops.
* For new installs, disable "legacy creds" for new databases. 

#### Release Notes
Thanks to all for your continued support.

Apologies for the relatively long delay in this release.  With any luck this is the last beta.  Unfortunately, the current maintainers are the only source of *pre-release* feedback. Also, a few non-trivial issues went unnoticed even after a several releases.

As outlined above, this is mostly a bufix release.  The most significant new feature is plugin run-time logging.  The plugin can now be configured to log development "asserts", Google API logging, and other significant events to a plain text file.  Currently, logging can only be enabled via the ``KeePass.exe.config`` file.  For example:

    <configuration>
        ...
	    <appSettings>
            ...
            <add key="KpSyncLogLevel" value="Debug"/>
            <add key="KpSyncLogFile" value="c:\temp\KpSyncLog.txt"/>
	    </appSettings>
    </configuration>

Modifying the configuration as shown above (and subsequently restarting KP) causes the plugin to create a file named ``KpSyncLogXXX.txt`` for each new KP session, where "XXX" is the encoded date/time for the session.  In this case, the file will be created in the ``c:\temp`` folder.

Eventually, this crude interface should be replaced with a GUI-accessible logging feature.  For now, please experiment with the feature to help us troubleshoot plugin problems in [bug reports and other issues](https://github.com/walterpg/google-drive-sync/issues), and to help everyone understand how the plugin works internally.

---
## 4.0.6-beta

* #31 REBRANDING. The name of the plugin has changed yet again, this time in deference to KP preferences.  This is the first release with the new name, matching changes already made to the [website](https://kpsync.org) and the Google Sign-in consent screen. See further notes below regarding this change.
* Fix for localization resources not deployed in .plgx ([normal installation](https://www.kpsync.org/install/normal)).
* Internal changes to project tooling used to create releases.
* Documentation updates for the above changes.

#### Release Notes: "KPSync for Google Drive"
This is almost a purely cosmetic update. For that reason you may wish to skip this release.  If so, be aware that the Google Sign-in screen will reflect the new plugin name, even when used with a prior release.  If you do eventually  update to a new release, be vigilant regarding the names of the component files, past and present.

The upgrade is similar to the prior "ALPHA" plugin upgrade, [the notes for which have been updated to include details for this upgrade](https://www.kpsync.org/install/upgrade0).  In short, the names of some major component files have changed.  Before installing the upgrade, remove prior release files with the following name *prefixes* from the KP installation and Plugins folders, and clear the [KP plugin cache](https://keepass.info/help/v2/plugins.html#cache):

* KeePassSyncForDrive
* GoogleDriveSync

The file prefix name is now **KPSyncForDrive**.  This will be used in the name of the portable zip file, the .PLGX file, and the plugin assembly .DLL file.

If you spot a problem or need a new feature, [please raise an issue](https://github.com/walterpg/google-drive-sync/issues)!  Thanks for your help.

---
## 4.0.5-beta

* Transparently support [Drive shortcuts](https://support.google.com/drive/answer/9700156?co=GENIE.Platform%3DDesktop&oco=1) (issue #20).
* Fix unexpected "upgrade" popup dialog after changing the sync configuration entry.
* Disable default sync ops to [shared files](https://support.google.com/drive/answer/2494822?co=GENIE.Platform%3DDesktop&hl=en) due to a potential security problem (issue #21).
* Implement a [session-stored authorization token](https://www.kpsync.org/usage/authorize#session-stored-tokens) option.
* Fixed privacy policy link on authorization upgrade form.
* Many minor UI tweaks for better KP integration.
* Update Google support packages.
* Fix config upgrade crash, #30 (thanks to @Rookiestyle).

##### Drive Shortcut Feature
The release includes a solution for syncing databases to Drive files referred to by "internal" Drive shortcuts.  Please see the [kpsync.org documentation](https://www.kpsync.org/usage/shortcuts) for details.

##### Addressing Shared Database Security
As of this release, the plugin, by default, will not synchronize with Drive files that are shared with other Drive accounts via Drive's
[shared file feature](https://support.google.com/drive/answer/2494822?co=GENIE.Platform%3DDesktop&hl=en). As discussed in issue #21, and detailed in a published [security bulletin](https://www.kpsync.org/notices/sharedsec), such usage enables a means to obtain unauthorized access to the Drive account of the sharer (or a sharee). While there remain many less convenient ways to share a KP database containing valid Drive authorization tokens, the plugin is no longer complicit in such usages.

Since the shared file issue is considered a long-standing *defect*, some users may already be aware of it.  Others may be unexpectedly impacted by the security implications and/or the change in default behavior mentioned above. The latter should follow the guidance contained in the [security bulletin](https://www.kpsync.org/notices/sharedsec).

To address security hazards, the **optional** [session-stored authorization token](https://www.kpsync.org/usage/authorize#session-stored-tokens) feature was implemented. *Safe* access to databases shared by any means, including Drive's shared file feature, can be enabled with this option. The security issue is mitigated by displacing authorization tokens from the database into secure KeePass session storage. To synchronize with this feature, users are required to authorize the plugin with Google Sign-in once per open database at *each* restart of KeePass. It is thus an effective but inadequate solution.

A more general solution for shared file security will be a subject of a future release.

##### Still in Beta
Maybe the last?

Do you use shared KeePass databases? If you have ideas for safely, *conveniently* doing so with the plugin, please raise an issue or submit a pull request.

*As always,* **Thank you for your feedback.**

---
## 4.0.3-beta
* Fixed Google Sync 3.0 regression (issue #14).
* Implemented target subfolder feature.
* Implemented KeePass proxy server configuration support (#15).
* Fixed regression in Configuration drop-down control (issue #17).

##### Release Note
This release fixes a Google Drive Sync 3.0 compatibility problem introduced
by the [Target Folder](https://kpsync.org/usage/target-folder)
feature.  If you prefer not to use Target Folder, the database file
can reside in any Drive folder, but its name cannot be duplicated in
any other Drive folder.

The plugin now respects KeePass proxy server settings when constructing
connections to Drive.  This has undergone limited testing, so please share
your experiences.

The [Target Folder](https://kpsync.org/usage/target-folder) feature now 
provides access to subfolders using a "file separator" syntax in the
specification.

**Thank you for your feedback.**


---
## 4.0.2-beta
* Ship Google-verified OAuth 2.0 creds (woo-hooo!!).
* Add upgrade prompt, shown once for those using the legacy creds.
* Rebranding as required by the service provider.
* Fix satellite resource dll deployment.
* Change binary distribution blob names.
* Migrate to proposed OAuth 2.0 client_id.
* Add "limited access" detail docs.
* Publish [https://kpsync.org](https://kpsync.org) (nee gdrivesync.org).
* Warn user when changing auth method if there is a refresh_token
present.
* Add "issue" templates, CONTRIBUTING, and CODE_OF_CONDUCT.
* Beautify "about" tab.

##### Release Note
New builtin OAuth 2.0 creds are here, and about time too!
These are freshly minted, fully Google-approved, and project
(re)branded for your security and simple pleasure!  Full 
compatibility with prior creds is retained (both old-plugin builtin,
and user customized), but the new creds will be the default option
going forward.  NO MORE scary sign-in screens! (Unless that's what
you prefer!)

Unfortunately, rebranding required for verification changed
some names and such.  Please review the UPGRADE docs for more
info.

Also, everything worth documenting is now found at
[kpsync.org](https://kpsync.org).  As always, we want to know
how the plugin works for **you**, whether bad or good (please
submit an "issue").

---
## 4.0.1-alpha.2
* Fix [MRU bug](https://github.com/walterpg/google-drive-sync/issues/2).
* Fix broken links, typos.  Some doc changes.
* Implement selective command disabling feature.
* Fix [drive scope](https://github.com/walterpg/google-drive-sync/issues/3)
selection and related configuration issues.

##### Release Note
Many thanks to those who have started using the new plugin.  Your
feedback is always valuable and welcome.

Google Drive OAuth 2.0 authorization has become tricky business for Google-unverified
applications such as this.  Even using your own OAuth credentials may 
result in scary-looking warnings when authenticating your account, especially
in the Chrome browser.  And the built-in OAuth credentials may not work at all,
or only in a limited scope.  Please see the
[Default OAuth](https://github.com/walterpg/google-drive-sync/issues/3#issuecomment-637851334)
topic for more info, and bear with us as we prepare to apply for verification.

---
## 4.0.0-alpha.1
* Prepare to go public.
* Reasonable first draft of documentation.
* Release build tool for signing the KeePass version manifest.
* Release build tool for managing "built-in" credentials.
* Fix global config bug.

---
## 4.0.0-alpha
First alpha.