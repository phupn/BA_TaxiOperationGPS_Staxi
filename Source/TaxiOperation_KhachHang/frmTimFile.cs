using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Taxi.GUI
{
    public partial class frmTimFile : Form
    {
        public string FilenameRet = "";

        public string GetFilename()
        {
            return FilenameRet;
        }

        public frmTimFile()
        {
            InitializeComponent();
        }

        public frmTimFile(string ThuMuc, string FilenameTimKiem)
        {
            InitializeComponent();
            this.ctrlTimFile1.SetThuMuc(ThuMuc );
            this.ctrlTimFile1.SetFileTimKiem(FilenameTimKiem);
        }

        private void frmTimFile_Load(object sender, EventArgs e)
        {
            this.ctrlTimFile1.OnChonFile += new Taxi.Controls.ctrlTimFile.ChonFileHanlder(ctrlTimFile1_OnChonFile);
            
        }



        void ctrlTimFile1_OnChonFile(object sender, Taxi.Business.EventTimFileArgs e)
        {
            FilenameRet = e.Filename;
            this.Close(); this.DialogResult  = DialogResult.OK;
        }

         


    }
}