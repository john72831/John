using Cupboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace John.Cupboard
{
    public class WindowsComputer : Catalog
    {
        public override void Execute(CatalogContext context)
        {
            if (!context.Facts.IsWindows()) return;

            context.UseManifest<Chocolatey>();
        }
    }
}
