
using System;

namespace Sitecore.SharedSource.CognitiveServices.Foundation
{
    public interface IReflectionUtilWrapper
    {
        T CreateObject<T>(Type t);
        T CreateObject<T>(Type t, object[] constructorParams);
        T CreateObject<T>(string name);
        T CreateObject<T>(string assembly, string classType, object[] constructorParams);
        T CreateObjectFromSettings<T>(string settingsTypeKey);
        T CreateObjectFromSettings<T>(string settingsTypeKey, object[] constructorParams);
    }
}