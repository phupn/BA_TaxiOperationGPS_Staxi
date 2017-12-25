using DevExpress.Utils.Serializing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Taxi.Controls.Base.Controls.Grids
{
    public enum ColumnFormatType
    {
        None,
        Integer,
        Decimal,
        Date,
        Time,
        DateTime,
        TimeDate
    }
    public class GridColumn : DevExpress.XtraGrid.Columns.GridColumn, ILanguage
    {
        public GridColumn() : base() { }
        [XtraSerializableProperty]
        public string TagLanguage { get; set; }
        public void SetLanguage(string Language)
        {
            if (!string.IsNullOrEmpty(Language))
                this.Caption = Language;
        }
        private ColumnFormatType formatType;
        [XtraSerializableProperty]
        public ColumnFormatType FormatType
        {
            get
            {
                return formatType;
            }
            set
            {

                if (formatType == value) return;
                formatType = value;
                switch (formatType)
                {
                    case ColumnFormatType.Date:
                        SetFormat(this, "dd/MM/yyyy");
                        if (ReDateEdit == null)
                        {
                            ReDateEdit = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
                            ReDateEdit.EditMask = "dd/MM/yyyy";
                            ReDateEdit.EditFormat.FormatString = "dd/MM/yyyy";
                            ReDateEdit.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                            ReDateEdit.DisplayFormat.FormatString = "dd/MM/yyyy";
                            ReDateEdit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                            this.View.GridControl.RepositoryItems.Add(ReDateEdit);
                        }
                        this.ColumnEdit = ReDateEdit;

                        break;
                    case ColumnFormatType.DateTime:
                        SetFormat(this, "dd/MM/yyyy HH:mm:ss");
                        if (ReDateEdit == null)
                        {
                            ReDateEdit = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
                            ReDateEdit.EditMask = "dd/MM/yyyy HH:mm:ss";
                            ReDateEdit.EditFormat.FormatString = "dd/MM/yyyy HH:mm:ss";
                            ReDateEdit.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                            ReDateEdit.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss";
                            ReDateEdit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                            this.View.GridControl.RepositoryItems.Add(ReDateEdit);
                        }
                        this.ColumnEdit = ReDateEdit;

                        break;
                    case ColumnFormatType.TimeDate:
                        SetFormat(this, "HH:mm:ss dd/MM/yyyy");
                        if (ReDateEdit == null)
                        {
                            ReDateEdit = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
                            ReDateEdit.EditMask = "HH:mm:ss dd/MM/yyyy";
                            ReDateEdit.EditFormat.FormatString = "HH:mm:ss dd/MM/yyyy";
                            ReDateEdit.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                            ReDateEdit.DisplayFormat.FormatString = "HH:mm:ss dd/MM/yyyy";
                            ReDateEdit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                            this.View.GridControl.RepositoryItems.Add(ReDateEdit);
                        }
                        this.ColumnEdit = ReDateEdit;

                        break;
                    case ColumnFormatType.Time:
                        SetFormat(this, "HH:mm:ss");
                        if (ReDateEdit == null)
                        {
                            ReDateEdit = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
                            ReDateEdit.EditMask = "HH:mm:ss";
                            ReDateEdit.EditFormat.FormatString = "HH:mm:ss";
                            ReDateEdit.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                            ReDateEdit.DisplayFormat.FormatString = "HH:mm:ss";
                            ReDateEdit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                            this.View.GridControl.RepositoryItems.Add(ReDateEdit);
                        }
                        this.ColumnEdit = ReDateEdit;

                        break;
                    case ColumnFormatType.Integer:
                        SetFormat(this, "N0");
                        if (ReTextEdit == null)
                        {
                            ReTextEdit = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
                            ReTextEdit.Mask.EditMask = "N0";
                            ReTextEdit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                            ReTextEdit.EditFormat.FormatString = "N0";
                            ReTextEdit.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                            ReTextEdit.DisplayFormat.FormatString = "N0";
                            ReTextEdit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                            this.View.GridControl.RepositoryItems.Add(ReTextEdit);
                        }
                        this.ColumnEdit = ReTextEdit;

                        break;
                    case ColumnFormatType.Decimal:
                        SetFormat(this, "#,##0.##");
                        if (ReTextEdit == null)
                        {
                            ReTextEdit = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
                            ReTextEdit.Mask.EditMask = "#,##0.##";
                            ReTextEdit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Custom;
                            ReTextEdit.EditFormat.FormatString = "#,##0.##";
                            ReTextEdit.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                            ReTextEdit.DisplayFormat.FormatString = "#,##0.##";
                            ReTextEdit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                            this.View.GridControl.RepositoryItems.Add(ReTextEdit);
                        }
                        this.ColumnEdit = ReTextEdit;

                        break;
                    default:
                        SetFormat(this, "");
                        this.ColumnEdit = null;
                        break;
                }

            }

        }
        private static DevExpress.XtraEditors.Repository.RepositoryItemDateEdit ReDateEdit;
        private static DevExpress.XtraEditors.Repository.RepositoryItemTextEdit ReTextEdit;
        /// <summary>
        /// Thiết lập Format
        /// </summary>
        /// <param name="gc"></param>
        /// <param name="format"></param>
        private static void SetFormat(GridColumn gc, string format)
        {
            gc.DisplayFormat.FormatString = format;
            if (string.IsNullOrEmpty(format))
                gc.DisplayFormat.FormatType = DevExpress.Utils.FormatType.None;
            else
                gc.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
        }
    }
    public class GridColumnCollection : DevExpress.XtraGrid.Columns.GridColumnCollection
    {
        public GridColumnCollection(DevExpress.XtraGrid.Views.Base.ColumnView view) : base(view) { }
        protected override DevExpress.XtraGrid.Columns.GridColumn CreateColumn()
        {
            return new GridColumn() { Name = string.Format("GridColumn{0}", DateTime.Now.Ticks) };
        }
    }
}
