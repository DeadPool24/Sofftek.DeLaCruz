using Sofftek.GestionComercial.Core.Interfaces.ICore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sofftek.GestionComercial.Core.Core
{
    public class Settings : ISettings
    {
        public string ApplicationName { get ; set ; }
        public string EndpointDescription { get ; set ; }
        public string EndpointUrl { get ; set ; }
        public string ContactName { get ; set ; }
        public string ContactUrl { get ; set ; }
        public string DocNameV1 { get ; set ; }
        public string DocInfoTitle { get ; set ; }
        public string DocInfoVersion { get ; set ; }
        public string DocInfoDescription { get ; set ; }
        public string EnabledSwagger { get ; set ; }
    }
}
