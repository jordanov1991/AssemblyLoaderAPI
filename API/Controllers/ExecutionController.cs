using API.AssemblyLoader;
using API.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Security.Policy;
using System.Web.Http;

namespace API.Controllers
{
    public class ExecutionController : ApiController
    {

        [Route("api/execute")]
        [HttpPost]
        public HttpResponseMessage ExecuteAssemblyMethod(HttpRequestMessage request)
        {

            ActivatorModel assembly = new ActivatorModel();

            //Deserialize request into execution model. 
            var executionModel = JsonConvert.DeserializeObject<ExecuteAssemblyModel>(request.Content.ReadAsStringAsync().Result);
           
            //Get Assemblies already in memory.
            var loadedAssemblies = LoadedAssemblies.GetLoadedAssemblies();


            //KeyValuePair<string, string> requestAssembly = new KeyValuePair<string, string>(executionModel.assemblyName, executionModel.assembyVersion);


            if (loadedAssemblies[executionModel.executionNamespace] != null)
            {
                // do some stuff here
            }
            else 
            { 

                assembly = AssemblyLoader.AssemblyLoader.Load(executionModel.assemblyLocation, executionModel.executionNamespace, executionModel.executionClass, executionModel.executionMethod);
            }
            


            var result = AssemlyActivator.Execute(assembly, null);

            if (result == null)
            {
                return httpResponse(null);
            }
            return httpResponse(result.ToString());
        }

        
        public static HttpResponseMessage httpResponse(string response) 
        {
            if (response == null)
            {
                return new HttpResponseMessage() { StatusCode = HttpStatusCode.NotFound };
            }
            return new HttpResponseMessage() 
            { 
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(response)
            };
        }

    }
}
