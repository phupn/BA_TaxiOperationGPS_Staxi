using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using AutoUpdate.Engine.Utility;

namespace AutoUpdate.Engine.Entity
{
    public class FileDownload
    {
        public int IndexID { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public UODState State { get; set; }

        public bool FromString(string data)
        {
            try
            {
                int i = data.LastIndexOf(' ');
                Name = data.Substring(i + 1, data.Length - i - 1).Trim();
                if (Constants.APP_SUB.Length > 0)
                    Path = Constants.FTP_URL + Constants.APP_NAME + "/" + Constants.APP_SUB + "/" + Name;
                else
                    Path = Constants.FTP_URL + Constants.APP_NAME + "/" + Name;
                State = UODState.NORMAL;

                return true;
            }
            catch { return false; }
        }
    }
}
