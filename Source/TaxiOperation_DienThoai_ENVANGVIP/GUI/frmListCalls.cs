using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Taxi.Business;
using Taxi.Utils;
using Janus.Windows.GridEX;

namespace Taxi.GUI
{
    public partial class frmListCalls : Form
    {
        private List<DieuHanhTaxi> mListOfCalls = new List<DieuHanhTaxi>();
        private DieuHanhTaxi mDieuHanhTaxiChon = new DieuHanhTaxi();

        private List<DieuHanhTaxi> lstDienThoai = new List<DieuHanhTaxi>();
        public DieuHanhTaxi DieuHanhTaxiChon
        {
            get { return mDieuHanhTaxiChon; }
            set { mDieuHanhTaxiChon = value; }
        }
        
        
        
        public frmListCalls()
        {
            InitializeComponent();
        }
        public frmListCalls(long IDCurrent)
        {
            InitializeComponent();
            LoadAllCuocGoiHienTai(IDCurrent);
                                 
        }
        public frmListCalls(DieuHanhTaxi DHTaxi)
        {
            InitializeComponent();
            LoadAllCuocGoiHienTai(DHTaxi.ID_DieuHanh);
            // Tim so dien thoi da co trong list va set Select row do luon
            TimSoDienThoaiDaCoTrongLuoi(DHTaxi);
        }

        private void TimSoDienThoaiDaCoTrongLuoi(DieuHanhTaxi DHTaxi)
        {
           // gridListCalls.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;
           //DieuHanhTaxiChon = (DieuHanhTaxi)((GridEXSelectedItem)gridListCalls.SelectedItems[0]).GetRow().DataRow;
            

           // if (gridListCalls.SelectedItems.Count > 0)
           // {

           // }
        }
        /// <summary>
        /// load all cacs cuoc goi chua ket thuc (tat ca khong phai cua minh nua)
        /// </summary>

        private void LoadAllCuocGoiHienTai(long IDCurrent)
        {
            try
            {
                DieuHanhTaxi objDHTaxi = new DieuHanhTaxi();
                string SQLCondition = " ORDER BY ThoiDiemGoi DESC";
                lstDienThoai = objDHTaxi.GetAllOf_DienThoai(SQLCondition);

                foreach (DieuHanhTaxi objDHTX in lstDienThoai)
                {
                    if (objDHTX.ID_DieuHanh != IDCurrent)
                    {
                        mListOfCalls.Add(objDHTX);
                    }
                }

                gridListCalls.DataMember = "ListDienThoai";
                gridListCalls.SetDataBinding(mListOfCalls, "ListDienThoai");
            }
            catch (Exception ex)
            {

            }
        }

        private void frmListCalls_Load(object sender, EventArgs e)
        {
            
        }

        private void gridEX1_DoubleClick(object sender, EventArgs e)
        {
            gridListCalls.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;
            
            if (gridListCalls.SelectedItems.Count > 0)
            {
                DieuHanhTaxiChon = (DieuHanhTaxi)((GridEXSelectedItem)gridListCalls.SelectedItems[0]).GetRow().DataRow;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
   
        }

        private void btnChon_Click(object sender, EventArgs e)
        {

                gridListCalls.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;
                if (gridListCalls.SelectedItems.Count > 0)
                {
                    DieuHanhTaxiChon = (DieuHanhTaxi)((GridEXSelectedItem)gridListCalls.SelectedItems[0]).GetRow().DataRow;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
   
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void frmListCalls_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                gridListCalls.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;
                if (gridListCalls.SelectedItems.Count > 0)
                {
                    DieuHanhTaxiChon = (DieuHanhTaxi)((GridEXSelectedItem)gridListCalls.SelectedItems[0]).GetRow().DataRow;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }
    }
}