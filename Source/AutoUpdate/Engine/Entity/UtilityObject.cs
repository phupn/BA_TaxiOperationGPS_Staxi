using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoUpdate.Engine.Entity
{
    public enum UODownloadKind
    {
        FILE_LIST_SUCCESS = 1,
        FILE_LIST_FAIL = 127,

        FILE_DOWNLOAD_SUCCESS = 128,
        FILE_DOWNLOAD_FAIL = 255
    }

    public enum UODownloadStep
    {
        GET_LIST_FILE = 1,
        DOWNLOAD_FILE = 2
    }

    public enum UODState
    {
        NORMAL = 1,
        DOWLOADING = 2,
        SUCCESS = 3,
        FAIL = 255
    }

    public class UODownloadState
    {
        public UODState ID { get; set; }
        public string Name { get; set; }

        public UODownloadState() { }

        public UODownloadState(UODState id, string nm)
        {
            ID = id;
            Name = nm;
        }
    }
}
