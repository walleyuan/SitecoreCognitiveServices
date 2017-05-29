# SitecoreCognitiveServices
SDK integrating Microsoft's Cognitive Services into Sitecore

## Getting the demo site up and running
This is largely copied from the original [source](https://www.markstiles.net/blog/2017/2/22/sitecore-cognitive-services/) and updated to make the installation a bit easier.

__Environment Prep__
- Get a set of API Keys from Microsoft
- SIM Install a version of Sitecore 8.2 rev. 160729 and the Launch Sitecore package (http://launchsitecore.net > register to obtain the 8.2 MVC package) (or use your own site if you're comfortable with it)
- Download the source code from GitHub

__Configuration files__

In order to prevent sharing API keys and local dev paths (the Unicorn serialization root) to the world two config files needs to be copied (to the same folder) and renamed. This is done by running the `setup-localdev.ps1` script located in the setup folder. This script will also set the Unicorn serialization root to match the folder in the repository so there's no need to copy yml files.

- Run the `setup-localdev.ps1` script (make sure that the PowerShell execution policy is at least set to [RemoteSigned](https://ss64.com/ps/set-executionpolicy.html)).
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

## Troubleshooting
<dl>
  <dt>How do I get API keys?</dt>
  <dd><p>Check out some of the answers on this StackOverflow question: https://stackoverflow.com/questions/40757076/unable-to-find-subscription-key-for-microsoft-cognitive-services</p>
  <p>
In general, you need to provision the service in Azure Portal and then go to the Keys section and copy the primary key value for that particular service. This needs to be done for each service you want to use.</p></dd>

  <dt>My FACE API key is specified, but I am getting a "access denied due to invalid subscription key" error. What gives?</dt>
  <dd><p>The keys appear to be specific to region. You need to configure the endpoint for your Face API to match to the endpoint in your Azure portal.</p>
  <p>See this Stackoverflow question for details: https://stackoverflow.com/questions/43918434/face-api-access-denied-due-to-invalid-subscription-key</p></dd>
  
  <dt>Visual Studio Publish fails with access error for target folder</dt>
  <dd>If you have installed Sitecore in a restricted area, such as the standard inetpub\wwwroot folder, you need elevated access to publish to this area of the file system. Launch Visual Studio in Administrator mode to allow you to publish to these folders.</dd>
  
  <dt>After publishing Sitecore shows error 'Access to the path denied' when executing Rainbow.Storage.SerializationFileSystemDataStore.InitializeRootPath</dt>
  <dd><p>By default, the PowerShell setup script will initialize your serialization folder (`serializationRootPath` setting in `App_Config\Include\SitecoreCognitiveServices\UnicornSerializationRoot.config`) to the location where your CognitiveServices project source code is located. Your IIS worker process likely does not have access to your source control folder if you receive this message. </p>
  <p>To correct the issue, navigate in Windows Explorer to your serialization folder (e.g `{sourcepath}\SitecoreCognitiveServices\serialization`). Right-click on the folder and open the Security dialog. Grant modify access to the local IIS_IUSRS group (or the equivalent on your OS version/application pool configuration).
  </p></dd>
</dl>
