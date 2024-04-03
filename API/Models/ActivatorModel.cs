using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace API.Models
{
    public class ActivatorModel
    {
        public MethodInfo method { get; set; }
        public Type className { get; set; }
        public Exception AssemlyLoadError { get; set; }
    }
}