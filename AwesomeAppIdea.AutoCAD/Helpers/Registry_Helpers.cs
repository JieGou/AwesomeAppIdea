using Microsoft.Win32;
using System.IO;
using AADS = Autodesk.AutoCAD.DatabaseServices;

namespace AwesomeAppIdea.AutoCAD.Helpers
{
    public struct Registry_Helpers
    {
        public static string GetCurrentRelease()
        {
            return new DirectoryInfo(GetCurrentReleaseRegistryKey().Name).Name;
        }

        public static string GetCurrentVersion()
        {
            var list = AADS.HostApplicationServices.Current.UserRegistryProductRootKey.Split('\\');
            return list[list.Length - 1];
        }

        public static string GetCurrentProductCode()
        {
            var list = AADS.HostApplicationServices.Current.UserRegistryProductRootKey.Split('\\');
            string productfullname = list[list.Length - 1];
            return productfullname.Remove(0, 6).Split(':')[0];
        }

        public static string GetCurrentLanguageCode()
        {
            var list = AADS.HostApplicationServices.Current.UserRegistryProductRootKey.Split('\\');
            string productfullname = list[list.Length - 1];
            return productfullname.Remove(0, 6).Split(':')[1];
        }

        public static RegistryKey GetCurrentReleaseRegistryKey()
        {
            RegistryKey CurrentProductKey = Registry.CurrentUser.OpenSubKey($"{AADS.HostApplicationServices.Current.UserRegistryProductRootKey}");
            return GetParentRegistryKey(CurrentProductKey);
        }

        private static RegistryKey GetParentRegistryKey(RegistryKey registryKey)
        {
            if (registryKey == null) throw new System.ArgumentNullException(nameof(registryKey));

            int first = registryKey.Name.IndexOf(@"\");
            int last = registryKey.Name.LastIndexOf(@"\");
            string parentname = registryKey.Name.Substring(first + 1, last - first);
            return Registry.CurrentUser.OpenSubKey(parentname);
        }
    }
}