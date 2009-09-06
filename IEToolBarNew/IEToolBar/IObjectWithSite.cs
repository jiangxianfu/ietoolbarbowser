using System;
using System.Runtime.InteropServices;

namespace IEToolBar
{
    /// <summary>
    /// IE查找BHO的接口。
    /// </summary>
    [ComVisible(true), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("FC4801A3-2BA9-11CF-A229-00AA003D7352")]
    public interface IObjectWithSite
    {
        [PreserveSig]
        int SetSite([MarshalAs(UnmanagedType.IUnknown)]object site);//加载BHO

        [PreserveSig]
        int GetSite(ref Guid guid, out IntPtr ppvSite);
    }
}
