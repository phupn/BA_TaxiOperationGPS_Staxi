using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Taxi.Utils;
using Taxi.Business;

namespace Taxi.Controls
{
    public partial class ctrlTimFile : UserControl
    {
        public delegate void ChonFileHanlder(object sender, EventTimFileArgs e);
        public event ChonFileHanlder OnChonFile;

        public string ThuMuc = "";
        public string FilenameReturn = "";
        
        public ctrlTimFile()
        {
            InitializeComponent();
        }

        

        public void SetThuMuc(string TenThuMuc)
        {
            this.ThuMuc = TenThuMuc; this.lblTenThuMuc.Text = this.ThuMuc;
        }

        public string GetFilename()
        {
            return this.FilenameReturn;
        }
        /// <summary>
        /// thiết lập thông tin file time kiemé
        /// </summary>
        /// <param name="TenFile"></param>
        public void SetFileTimKiem(string TenFile)
        {
            this.txtFilename.Text = TenFile;
        }
        private void ctrlTimFile_Load(object sender, EventArgs e)
        {
            this.GetFile();
            this.lblTenThuMuc.Text = this.ThuMuc;
        }

        private void GetFile()
        {
            if (this.txtFilename.Text.Length > 0)
            {
                try
                {
                    string[] arrFiles = FileTools.SearchFileInDirectory(this.ThuMuc,
                        StringTools.TrimSpace(this.txtFilename.Text));
                    if (arrFiles.Length > 0)
                    {
                        lstFile.Items.Clear();
                        for (int i = 0; i < arrFiles.Length; i++)
                        {
                            lstFile.Items.Add(arrFiles[i]);
                        }
                    }
                }
                catch (Exception ex)
                {
                    new MessageBox.MessageBoxBA().Show(ex.Message);
                }
                
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            this.GetFile();
        }

        private void lstFile_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void txtFilename_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.GetFile();
            }
        }

        private void lstFile_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lstFile.SelectedItem != null)
            {
                this.FilenameReturn = (string)lstFile.SelectedItem;
                EventTimFileArgs eventTim = new EventTimFileArgs(this.FilenameReturn);
                if (OnChonFile != null)
                    OnChonFile(this, eventTim);

            }
        }
    }
}
