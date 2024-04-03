using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace API.Models
{
    [DataContract]
    public class ExecuteAssemblyModel
    {
        [DataMember(Name = "assemblyName")]
        public string assemblyName { get; set; }
        [DataMember(Name = "assembyVersion")]
        public string assembyVersion { get; set; }
        [DataMember(Name = "assemblyLocation")]
        public string assemblyLocation { get; set; }
        [DataMember(Name = "executionNamespace")]
        public string executionNamespace { get; set; }
        [DataMember(Name = "executionClass")]
        public string executionClass { get; set; }
        [DataMember(Name = "executionMethod")]
        public string executionMethod { get; set; }
    }
}