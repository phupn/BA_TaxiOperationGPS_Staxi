using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TaxiCapture;
using System.Threading;

namespace  DongBoGoiDi
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // A mutex is visible across application boundaries.
            // Create it initially owned.  If it cannot be owned,
            // then another process already owns it.
            bool onlyInstance;
            Mutex mtx = new Mutex(true, Application.ProductName, out onlyInstance);

            // If no other process owns the mutex, this is the
            // only instance of the application.
            if (onlyInstance)
            {

                // Create the main form, then start the
                // application.  If the form is closed,
                // the application continues to run.

                //frmCallCapture frm = new frmCallCapture();

                Application.Run(new frmDongBoGoiDi());
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
    }
}