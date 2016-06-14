using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Telerik.Sitefinity;
using Telerik.Sitefinity.Abstractions;
using Telerik.Sitefinity.Abstractions.VirtualPath.Configuration;
using Telerik.Sitefinity.Configuration;
using Telerik.Sitefinity.Data;
using Telerik.Sitefinity.Modules.Pages.Configuration;

namespace RandomSiteControls
{

    public static class Installer
    {
        /// <summary>
        /// This is the actual method that is called by ASP.NET even before application start. Sweet!
        /// </summary>
        public static void PreApplicationStart()
        {
            // With this method we subscribe for the Sitefinity Bootstrapper_Initialized event, which is fired after initialization of the Sitefinity application
            Bootstrapper.Initialized += (new EventHandler<ExecutedEventArgs>(Installer.Bootstrapper_Initialized));
        }

        public static void Bootstrapper_Initialized(object sender, Telerik.Sitefinity.Data.ExecutedEventArgs e)
        {
            Telerik.Sitefinity.Configuration.Config.RegisterSection<RandomSiteControls.Configuration.SitefinitySteveConfig>();

            //Add Tools
            InstallVirtualPaths(); // See that method for VIRTUAL PATHS installation code
        }

        private static void InstallVirtualPaths()
        {
            SiteInitializer initializer = SiteInitializer.GetInitializer();
            var virtualPathConfig = initializer.Context.GetConfig<VirtualPathSettingsConfig>();

            string key = "~/SitefinitySteve/*";
            if (!virtualPathConfig.VirtualPaths.ContainsKey(key))
            {
                var newVirtualPathNode = new VirtualPathElement(virtualPathConfig.VirtualPaths)
                {
                    VirtualPath = key,
                    ResolverName = "EmbeddedResourceResolver",
                    ResourceLocation = "RandomSiteControls"
                };

                virtualPathConfig.VirtualPaths.Add(newVirtualPathNode);
                Config.GetManager().SaveSection(virtualPathConfig);
            }
        }
    }

}
