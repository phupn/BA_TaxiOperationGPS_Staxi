﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TaxiCapture;
using System.Threading;
using Taxi.Business;

namespace TaxiOperation_CallCapture2
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()       

        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                // A mutex is visible across application boundaries.
                // Create it initially owned.  If it cannot be owned,
                // then another process already owns it.
                bool onlyInstance;
                if (Configuration.TrangThaiBatSo > 0)
                {
                    Mutex mtx = new Mutex(true, Application.ProductName, out onlyInstance);

                    // If no other process owns the mutex, this is the
                    // only instance of the application.
                    if (onlyInstance)
                    {
                        // Create the main form, then start the
                        // application.  If the form is closed,
                        // the application continues to run.
                        // frmCallCapture frm = new frmCallCapture();
                        Application.Run(new frmMainUDPThanhNga());
                        // Application.Run(new frmGenCall());
                        // Application.Run(new frmTestMain());
                        mtx.ReleaseMutex();
                    }
                    else
                    {
                        MessageBox.Show(
                            "Đã có một chương trình đang chạy",
                            "Call Capture",
                            MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        Application.Exit();
                    }
                }

                Application.Run(new frmMainUDPThanhNga());
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                        "Lỗi main func : " + ex.Message,
                        "Call Capture",
                        MessageBoxButtons.OK, MessageBoxIcon.Stop);
                Application.Exit( );
            }
        }
    }
}