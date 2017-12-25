using OneTaxi.Controls.Base.Controls.Grids;
using OneTaxi.Controls.Base.Extender;
using Staxi.Utils.DbBase;
using System;
using System.Linq;
using System.Windows.Forms;

namespace OneTaxi.Controls.Base.Forms
{
    public partial class FormManager : FormBase
    {
        private FormUpdate formSave;
        /// <summary>
        /// Đây là giúp biết được form Update là form nào được kế thừa từ FormUpdate
        /// </summary>
        public virtual FormUpdate FormUpdate { get { return null; } }
        /// <summary>
        /// Giúp không phải khởi tạo form nhiều lần.
        /// Vì nếu khởi tạo nhiều thì máy tính tổn thương nguyên khí quá nhiều.
        /// </summary>
        protected virtual FormUpdate FormSave { get { return formSave ?? (formSave = FormUpdate); } }
        private GridControl grid;
        protected GridControl GridFisrt { get { return grid ?? (grid = panelView.FindAllChildrenByType<GridControl>().First()); } }
        public virtual ModelBase RowModel { get { return GridFisrt.LayoutGrid.GetFocusedRow() as ModelBase; } }
        public virtual object GetData() { return null; }
        public string FileExcel { get; set; }
        public FormManager()
        {
            InitializeComponent();
        }

        public virtual void DoAdd()
        {
            FormSave.LoadModel(null);
            if (FormSave.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                DoRefresh();
            }
        }
        public virtual void DoEdit()
        {
            if (RowModel != null)
            {
                FormSave.LoadModel(RowModel);
                if (FormSave.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    DoRefresh();
                }
            }
            
        }
        public virtual void DoRemove()
        {
            if (RowModel != null)
            {
                if (MessageBox.Show("Bạn có muốn xóa bản ghi đã chọn không?", "Thông báo", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    RowModel.Delete();
                }
            }            
        }
        public virtual void DoFind()
        {
            panelFind.ParseTo(this, false);
            GridFisrt.DataSource = GetData();
        }
        public virtual void DoRefresh()
        {
            panelFind.ClearForm();
            GridFisrt.DataSource = GetData();
        }
        public virtual void DoExportExcel()
        {
            var filename = string.Format("{0}_{1:ddMMyyyHH:mm:ss}", !string.IsNullOrEmpty(FileExcel) ? FileExcel : this.Text, DateTime.Now);
            
            GridFisrt.ExportToXls(filename);
            
            //GridFisrt.ExportToXlsx(filename);
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            DoAdd();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            DoEdit();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            DoRemove();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            DoFind();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            DoRefresh();
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            DoExportExcel();
        }
    }
}
