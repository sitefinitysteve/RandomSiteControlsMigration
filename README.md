# RandomSiteControls - Migration

## About

This is all the pure hybrid widgets and layouts abstracted out of the core RSC.  All of the extensions and helpers have been removed.  This is to be used side-by-side with the RandomSiteControlsMVC to assist in migrating.

## Why

If you just remove the old RandomSiteControls and put in RandomSiteControlsMVC and reload an existing site, you'll get YSOD screens saying it can't find the old widgets.  You also couldn't put RandomSiteControlsMVC in alongside RandomSiteControls because there the helpers and extensions have migrated over as well (naming conflicts).  This will let you see the old widgets and their data.
