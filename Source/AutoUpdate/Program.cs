using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows.Forms;

using AutoUpdate.Engine.Utility;

namespace AutoUpdate
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            DevExpress.Skins.SkinManager.EnableFormSkins();
            DevExpress.Skins.SkinManager.EnableMdiFormSkins();
            DevExpress.LookAndFeel.LookAndFeelHelper.ForceDefaultLookAndFeelChanged();
            //args = new string[] {"TongDaiV2","" };
            if (InitParams(args) == false)
                return;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new XFMain());
        }

        /// <summary>
        /// System.Diagnostics.Process.Start(RunningParams.DIRECTORY_RUNNING + RunningParams.AUTO_UPDATE_FILE_NAME, RunningParams.AUTO_UPDATE_ARGUMENTS);
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        private static bool InitParams(string[] args)
        {
            if (args != null && args.Length > 0)
            {
                string[] temp = args[0].Trim().Split('@');
                Constants.APP_NAME = temp[0];
                Constants.APP_SUB = temp.Length > 1 ? temp[1] : "";
            }
            else
            {
                Constants.APP_NAME = "";
                Constants.APP_SUB = "";
            }

            if (Constants.DOMAIN.Length > 0)
            {
                IPHostEntry hostEntry = Dns.GetHostEntry(Constants.DOMAIN);
                if (hostEntry == null || hostEntry.AddressList == null || hostEntry.AddressList.Length == 0)
                    return false;

                Constants.FTP_URL = string.Format(Constants.FTP_URL, hostEntry.AddressList[0]);
            }

            return true;
        }
    }
}
