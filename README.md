# SitecoreCognitiveServices
SDK integrating Microsoft's Cognitive Services into Sitecore

## Getting the demo site up and running
This is largely copied from the original [source](https://www.markstiles.net/blog/2017/2/22/sitecore-cognitive-services/) and updated to make the installation a bit easier.

__Environment Prep__
- Get a set of API Keys from Microsoft
- SIM Install a version of Sitecore 8.2 rev. 160729 and the Launch Sitecore package (http://launchsitecore.net > register to obtain the 8.2 MVC package) (or use your own site if you're comfortable with it)
- Download the source code from GitHub

__Configuration files__

In order to prevent sharing API keys and local dev paths to the world two config files needs to be copied (to the same folder) and renamed:
- Copy `Sitecore.SharedSource.CognitiveServices\App_Config\Include\SitecoreCognitiveServices\SitecoreCognitiveServices.config.localdev` and remove the `.localdev` suffix.
  - Enter your API Keys into the renamed SitecoreCognitiveServices.config file.
- Copy `Sitecore.SharedSource.CognitiveServices\App_Config\Include\SitecoreCognitiveServices\UnicornSerializationRoot.localdev.config` and remove the `localdev` suffix. 
  - Update this config file with the full path in your local repository where the Sitecore items are serialized (this should end with `\serialization\Sitecore.SharedSource.CognitiveServices`).
- Update the publishing profile on the core library project with the path to your Sitecore webroot (so the publish goes to your local web root)
- Build the projects (to ensure all the Nuget packages get downloaded because this doesn't always work right away)
- Publish the core and launch demo projects onto your website

__Go into the webroot and modify the web.config__
- add a node to the compilation assembles: `<add assembly="System.Runtime, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" />`
- change `Newtonsoft.Json` version from `6.0.0.0` to `9.0.0.0` (the project oxford clients are using the new version)

__Unicorn sync__
- Browse to `http://<domain>/unicorn.aspx` and sync the configuration
- Additionally you may want to browse to these files and force refresh them (browsers cache them)
  - `http://<domain>/sitecore/shell/Themes/Standard/Default/Content%20Manager.css`
  - `http://<domain>/sitecore/shell/Controls/Rich%20Text%20Editor/RichText%20Commands.js`

__Sitecore__
- Log into Sitecore, go to the Control Panel
- Open the Indexing Manager and reindex the `cognitive_master_index`
- Start viewing the analysis of content or media items and go build more functionality!
