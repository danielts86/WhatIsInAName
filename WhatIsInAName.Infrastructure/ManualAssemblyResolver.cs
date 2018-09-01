using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace WhatIsInAName.Infrastructure
{
    public class ManualAssemblyResolver : IDisposable
    {
        /// <summary>
        /// list of the known assemblies by this resolver
        /// </summary>
        private readonly Dictionary<string, Assembly> _dllNameToAssembly;

        public ManualAssemblyResolver(params string[] dllNames)
        {
            if (dllNames.Length == 0)
            {
                return;
            }

            _dllNameToAssembly = new Dictionary<string, Assembly>();
            var path = Assembly.GetExecutingAssembly().Location;
            path = Path.GetDirectoryName(path);
            foreach (var dllName in dllNames)
            {
                var dllPath = Path.Combine(path, dllName);
                if (!dllName.EndsWith(".dll"))
                {
                    dllPath += ".dll";
                }
                var assembly = Assembly.LoadFrom(dllPath);
                _dllNameToAssembly.Add(dllName , assembly);
            }

            AppDomain.CurrentDomain.AssemblyResolve += OnAssemblyResolve;
        }

        #region Implement IDisposeable

        public void Dispose()
        {
            AppDomain.CurrentDomain.AssemblyResolve -= OnAssemblyResolve;
        }

        #endregion

        /// <summary>
        /// will be called when an unknown assembly should be resolved
        /// </summary>
        /// <param name="sender">sender of the event</param>
        /// <param name="args">event that has been sent</param>
        /// <returns>the assembly that is needed or null</returns>
        private Assembly OnAssemblyResolve(object sender, ResolveEventArgs args)
        {
            var dllName = args.Name.Substring(0, args.Name.IndexOf(","));
            var assembly = _dllNameToAssembly.FirstOrDefault(a => a.Key.Contains(dllName));
            if (assembly.Value != null)
            {
               return assembly.Value;
            }

            return null;
        }
    }
}
