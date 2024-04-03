using API.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;

namespace API.AssemblyLoader
{
    public static class AssemblyLoader
    {

        public static ActivatorModel Load(string dllLoacation, string dllNameSpace , string dllClass, string dllMethod)
        {
            ActivatorModel model = new ActivatorModel();

            try
            {
                
                Assembly DLL = Assembly.LoadFile(dllLoacation);
                Type type = DLL.GetType(dllNameSpace + "." + dllClass);
                MethodInfo method = type.GetMethod(dllMethod);

                model.method = method;
                model.className = type;
               

                return model;

            }
            catch (Exception ex) {

                model.method = null; model.className = null;
                model.AssemlyLoadError = ex;

                return model;
            
            }

        }


        //public static ActivatorModel LoadExisting(string dllLoacation, string dllNameSpace, string dllClass, string dllMethod)
        //{
        //    ActivatorModel model = new ActivatorModel();

        //    try
        //    {

        //        Assembly DLL = Assembly.GetAssembly(dllLoacation);
        //        Type type = DLL.GetType(dllNameSpace + "." + dllClass);
        //        MethodInfo method = type.GetMethod(dllMethod);

        //        model.method = method;
        //        model.className = type;


        //        return model;

        //    }
        //    catch (Exception ex)
        //    {

        //        model.method = null; model.className = null;
        //        model.AssemlyLoadError = ex;

        //        return model;

        //    }

        //}
    }
}