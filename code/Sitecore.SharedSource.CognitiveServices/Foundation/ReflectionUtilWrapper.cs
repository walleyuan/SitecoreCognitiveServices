
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

        public T CreateObject<T>(Type t)
        {
            return (T)ReflectionUtil.CreateObject(t);
        }

        public T CreateObject<T>(Type t, object[] constructorParams)
        {
            return (T)ReflectionUtil.CreateObject(t, constructorParams);
        }

        public T CreateObject<T>(string name)
        {
            return (T)ReflectionUtil.CreateObject(name);
        }

        public T CreateObject<T>(string assembly, string classType, object[] constructorParams)
        {
            return (T)ReflectionUtil.CreateObject(assembly, classType, constructorParams);
        }

        public T CreateObjectFromSettings<T>(string settingsTypeKey)
        {
            return (T)ReflectionUtil.CreateObject(Settings.GetSetting(settingsTypeKey));
        }
    }
}