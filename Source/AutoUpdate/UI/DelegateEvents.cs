using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using AutoUpdate.Engine.Entity;

namespace AutoUpdate.UI
{
    public delegate void FTPDownloadSuccess(int index);
    public delegate void FTPDownloadFail(int index);
    public delegate void FTPDownloadFinshed(UODownloadKind kind, object data);

    public delegate void CMIMainProcessDownloadSuccess(int rows, int column);
    public delegate void CMIMainProcessDownloadFail(string tile, string folder, int rows, int column, bool success);
}
