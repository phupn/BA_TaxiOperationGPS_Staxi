using System;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;

namespace Taxi.Controls.FastTaxis
{
    public partial class ProgressBar : Form
    {
        public ProgressBar()
        {
            InitializeComponent();
             _worker.WorkerReportsProgress = true;
        _worker.DoWork += _worker_DoWork;
        _worker.ProgressChanged += WorkerProgressChanged;
        _worker.RunWorkerCompleted += WorkerRunWorkerCompleted;

        _worker.RunWorkerAsync();
        }
        readonly BackgroundWorker _worker = new BackgroundWorker();

    private void _worker_DoWork(object sender, DoWorkEventArgs e)
    {
        var worker = sender as BackgroundWorker;
        //this.Show();
        // Simulate work (uploading Excel records to SQL Server)
        for (var i = 1; i <= 100; i++)
        {
            if (worker.CancellationPending)
            {
                e.Cancel = true;
                break;
            }

            // Upload some data here, Sleep(100) is just an example
            Thread.Sleep(100);

            // Calculate current progress and report
            worker.ReportProgress(i);
        }
    }

    void WorkerProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        try
        {
            shProgressBar1.EditValue = e.ProgressPercentage;
        }
        catch (Exception ex) { }
       
    }

    void WorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        try
        {
            shProgressBar1.EditValue = 0;
            Close();
        }
        catch (Exception ex) { }
       
    }
    }
}
