using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using BlazorGenericsAndReflection.BusinessLogic.Interface;

namespace BlazorGenericsAndReflection.BusinessLogic.Services
{
    public class FeatureImplementationService
    {
        public List<IFeature> GetFeatureImplementationsViaReflection()
        {
            var result = new List<IFeature>();

            var interfaceType = typeof(IFeature);
            var types = Assembly.GetCallingAssembly().GetTypes();
            var implementations = types.Where(x => x.GetInterface(interfaceType.FullName) == interfaceType && x.IsClass && !x.IsInterface && !x.IsAbstract).ToList();
            foreach (var implementation in implementations)
            {
                result.Add((IFeature)Activator.CreateInstance(implementation));
            }
            return result;
        }
    }
}