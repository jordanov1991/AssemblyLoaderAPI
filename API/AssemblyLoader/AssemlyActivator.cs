using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace API.AssemblyLoader
{
    public static class AssemlyActivator
    {
        public static object Execute(ActivatorModel model, object [] parameters)
        {
            object result; 

            if (!model.method.IsStatic)
            {
                var activeInstance = Activator.CreateInstance(model.className);
                var method = model.method;
                result = method.Invoke(activeInstance, parameters);
            }
            else
            {
                var method = model.method;
                result = method.Invoke(null, parameters);
            }
            
            return result;
        }
    }
}