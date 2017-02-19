
using System;
using Sitecore.Reflection;

namespace Sitecore.SharedSource.CognitiveServices.Foundation
{
    public class ReflectionUtilWrapper : IReflectionUtilWrapper
    {
        protected readonly ISettingsWrapper Settings;

        public ReflectionUtilWrapper(ISettingsWrapper settings)
        {
            Settings = settings;
        }

        public virtual T CreateObject<T>(Type t)
        {
            return (T)ReflectionUtil.CreateObject(t);
        }

        public virtual T CreateObject<T>(Type t, object[] constructorParams)
        {
            return (T)ReflectionUtil.CreateObject(t, constructorParams);
        }

        public virtual T CreateObject<T>(string name)
        {
            return (T)ReflectionUtil.CreateObject(name);
        }

        public virtual T CreateObject<T>(string assembly, string classType, object[] constructorParams)
        {
            return (T)ReflectionUtil.CreateObject(assembly, classType, constructorParams);
        }

        public virtual T CreateObjectFromSettings<T>(string settingsTypeKey)
        {
            return (T)ReflectionUtil.CreateObject(Settings.GetSetting(settingsTypeKey));
        }

        public virtual T CreateObjectFromSettings<T>(string settingsTypeKey, object[] constructorParams)
        {
            string[] assemblyClass = Settings.GetSetting(settingsTypeKey).Split(new[] {","}, StringSplitOptions.RemoveEmptyEntries);
            if (assemblyClass.Length < 2)
                return default(T);

            return (T)ReflectionUtil.CreateObject(assemblyClass[1], assemblyClass[0], constructorParams);
        }
    }
}