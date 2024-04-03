using API.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
using System.Web;

namespace API.AssemblyLoader
{
    public static class LoadedAssemblies
    {
        public static NameValueCollection GetLoadedAssemblies()
        {
            NameValueCollection  loadedAssemblies = new NameValueCollection();

            AppDomain currentDomain = AppDomain.CurrentDomain;
            //Provide the current application domain evidence for the assembly.
            Evidence asEvidence = currentDomain.Evidence;

            //Make an array for the list of assemblies.
            Assembly[] assems = currentDomain.GetAssemblies();
            LoadedAssemblyModel loadedAssembly = new LoadedAssemblyModel();



            NameValueCollection assemblyData = new NameValueCollection();



            //List the assemblies in the current application domain.
            foreach (Assembly assem in assems)
            {
                loadedAssembly = DeserializeAssemblyProperties(assem.FullName);
                loadedAssemblies.Add(loadedAssembly.Name, loadedAssembly.Version);
            }

            return loadedAssemblies;
        }

        public static LoadedAssemblyModel DeserializeAssemblyProperties(string inputData)
        {
            var model = new LoadedAssemblyModel();
            inputData = inputData.Trim(new Char[] { '{', '}' }); 

            var inp = inputData.Split(',');
            model.Name = inp[0].Trim();
            model.Version = inp[1].Trim();
            model.Culture = inp[2].Trim();
            model.PublicKeyToken = inp[3].Trim();

            return model;

        }
    }
}