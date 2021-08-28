using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using BlazorGenericsAndReflection.BusinessLogic.Interface;

namespace BlazorGenericsAndReflection.BusinessLogic.Services
{
    public class FeatureImplementationService
    {
        public List<IFeature<IFeatureOutput>> GetFeatureImplementationsViaReflection()
        {
            var result = new List<IFeature<IFeatureOutput>>();

            var allTypes = Assembly.GetCallingAssembly().GetTypes();
            foreach (var type in allTypes)
            {
                if (type.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IFeature<>)))
                {
                    result.Add((IFeature<IFeatureOutput>)Activator.CreateInstance(type));
                }
            }
            return result;
        }
    }
}