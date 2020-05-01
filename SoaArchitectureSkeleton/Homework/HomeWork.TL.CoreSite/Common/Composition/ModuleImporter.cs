using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using HomeWork.TL.Core.Common.Composition;
using HomeWork.TL.Core.Common.IoC;

namespace HomeWork.TL.CoreSite.Common.Composition
{
    public class ModuleImporter
    {
        private const String OutputPath = @"bin";

        [ImportMany(typeof(IModule))]
        private IEnumerable<IModule> modules;

        public void ImportModules()
        {
            var root = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, OutputPath);

            if (String.IsNullOrEmpty(root))
            {
                throw new NotSupportedException();
            }

            using (var catalog = new AggregateCatalog())
            {
                catalog.Catalogs.Add(new DirectoryCatalog(root));
                using (var container = new CompositionContainer(catalog))
                {
                    // Get each module (assembly) from the root folder with ExportModule attribute
                    // and set it into Modules property
                    container.ComposeParts(this);
                }
            }

            // Initialize each module (assembly) from the root folder with ExportModule attribute
            foreach (var module in modules)
            {
                module.Initialize(DependencyInjection.Container);
            }
        }
    }
}