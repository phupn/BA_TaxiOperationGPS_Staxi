using System;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using Taxi.Common.Extender;

namespace Taxi.Controls.Base.Controls
{
    public class ShRepositoryItemProgressBar : RepositoryItemProgressBar
    {
        //public ShRepositoryItemProgressBar()
        //{
        //   // this.Editable = true;
        //    this.Minimum = 0;
        //    this.Maximum = 5*60;
        //    this.CustomDisplayText += ShRepositoryItemProgressBar_CustomDisplayText;
        //}

        //void ShRepositoryItemProgressBar_CustomDisplayText(object sender, CustomDisplayTextEventArgs e)
        //{
        //    int sophut = (e.Value.To<int>() / 60);
        //    int soGiay = e.Value.To<int>() - sophut * 60;
        //    e.DisplayText = string.Format(sophut > 0 ? "Còn lại {0} phút {1} giây" : "Còn lại {1} giây", sophut, soGiay);
        //}
    }
}
