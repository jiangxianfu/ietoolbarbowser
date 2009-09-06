using System;
using Microsoft.Win32;
using System.Runtime.InteropServices;
using SHDocVw;
using System.Windows.Forms;

namespace IEToolBar
{/// <summary>
    /// 过滤关键字的BHO。
    /// </summary>
    [ComVisible(true), Guid("5ADEFB9E-B824-45e6-86E2-2B7941F5D6A3"), ClassInterface(ClassInterfaceType.None)]
    public class FilterToolBar : IObjectWithSite
    {

        #region FilterIEHelper 成员

        SHDocVw.WebBrowser webBrowser;//当前浏览器控件

        string strFilterKeys = "game;sex;stock;hnainfo";//过滤关键字，用;隔开。

        /// <summary>
        /// 导航前过滤关键字。
        /// </summary>
        /// <param name="pDisp"></param>
        /// <param name="URL"></param>
        /// <param name="Flags"></param>
        /// <param name="TargetFrameName"></param>
        /// <param name="PostData"></param>
        /// <param name="Headers"></param>
        /// <param name="Cancel"></param>
        private void webBrowser_BeforeNavigate2(object pDisp, ref object URL, ref object Flags, ref object TargetFrameName, ref object PostData, ref object Headers, ref bool Cancel)
        {

            string strUrl = URL.ToString();

            string[] strFilterKeyItems = this.strFilterKeys.Split(new char[] { ';' });

            foreach (string strFilterKey in strFilterKeyItems)
            {
                if (strUrl.IndexOf(strFilterKey) > -1)
                {
                    webBrowser.StatusText = "未授权访问包含" + strFilterKey + "关键字的地址!";
                    Cancel = true;
                    return;
                }
            }

            this.webBrowser.StatusText = strUrl;
        }

        #endregion

        #region IObjectWithSite 成员

        /// <summary>
        /// 加载当前浏览器插件。
        /// </summary>
        /// <param name="site"></param>
        /// <returns></returns>
        public int SetSite(object site)
        {
            if (site != null)
            {
                webBrowser = (SHDocVw.WebBrowser)site;
               
                webBrowser.BeforeNavigate2 += new DWebBrowserEvents2_BeforeNavigate2EventHandler(webBrowser_BeforeNavigate2);
                ShowBrowserBar(true);
            }
            else
            {
                webBrowser.BeforeNavigate2 -= new DWebBrowserEvents2_BeforeNavigate2EventHandler(webBrowser_BeforeNavigate2);
                ShowBrowserBar(false);
            }

            return 0;
        }
        

        /// <summary>
        /// 获取浏览器插件。
        /// </summary>
        /// <param name="guid"></param>
        /// <param name="ppvSite"></param>
        /// <returns></returns>
        public int GetSite(ref Guid guid, out IntPtr ppvSite)
        {
            IntPtr punk = Marshal.GetIUnknownForObject(webBrowser);
            int hr = Marshal.QueryInterface(punk, ref guid, out ppvSite);
            Marshal.Release(punk);

            return hr;
        }

        private void ShowBrowserBar(bool bShow)
        {
            object pvaClsid = (object)(new Guid("22d6f312-b0f6-11d0-94ab-0080c74c7e95").ToString("B"));
            object pvarShow = (object)bShow;
            object pvarSize = null;

            if (bShow) /* hide Browser bar before showing to prevent erroneous behavior of IE*/
            {
                object pvarShowFalse = (object)true;
                this.webBrowser.ShowBrowserBar(ref pvaClsid, ref pvarShowFalse, ref pvarSize);
                


            }

            this.webBrowser.ShowBrowserBar(ref pvaClsid, ref pvarShow, ref pvarSize);
        }

        #endregion
    }
}
