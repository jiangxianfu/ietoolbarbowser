using System;
using Microsoft.Win32;
using System.Runtime.InteropServices;

namespace RegisterIEToolBar
{
    /// <summary>
    /// 注册FilterIEHelper。
    /// </summary>
    public class RegisterHelper
    {
        public static string BHOKEYNAME = "Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Browser Helper Objects";//BHO注册表位置。

        /// <summary>
        /// 注册FilterIEHelper。
        /// </summary>
        /// <param name="t"></param>
        [ComRegisterFunction]
        public static void RegisterBHO(Type t)
        {
            RegistryKey key = Registry.LocalMachine.OpenSubKey(BHOKEYNAME, true);

            if (key == null)
                key = Registry.LocalMachine.CreateSubKey(BHOKEYNAME);

            string guidString = t.GUID.ToString("B").ToUpper();
            RegistryKey bhoKey = key.OpenSubKey(guidString);

            if (bhoKey == null)
                bhoKey = key.CreateSubKey(guidString);

            key.Close();
            bhoKey.Close();
        }

        /// <summary>
        /// 取消注册FilterIEHelper。
        /// </summary>
        /// <param name="t"></param>
        [ComUnregisterFunction]
        public static void UnRegisterBHO(Type t)
        {
            RegistryKey key = Registry.LocalMachine.OpenSubKey(BHOKEYNAME, true);
            string guidString = t.GUID.ToString("B").ToUpper();

            if (key != null)
                key.DeleteSubKey(guidString, false);
        }
    }
}
