using DSLController_MModell.MetaModell.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSLController_MModell.Generator
{
    public static class AttributeHelper
    {
        public static string Render(IMAttribute attr)
        {
            return attr switch
            {
                MHttpMethod m => $"[Http{m.HttpMethod.ToString()[0]}{m.HttpMethod.ToString().Substring(1).ToLower()}]",
                MAuthorize a => a.Roles.Length == 0 ? "[Authorize]" : $"[Authorize(Roles=\"{string.Join(",",a.Roles)}\")]",
                MRoute r => $"[Route(\"{r.Route}\")]",
                MAntiforgery af => af.isAntiforgery ? "[ValidateAntiForgeryToken]" : "[IgnoreAntiforgeryToken]",
                MConsumes c => $"[Consumes(\"{c.MediaType}\")]",
                MProduces p => $"[Produces(\"{p.MediaType}\")]",
                _ => $"[UnknownAttribute: {attr.GetType().Name}]"
            };
        }
    }
}
