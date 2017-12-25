using Aspose.Cells;
using System.Drawing;
namespace Taxi.Controls.BaoCao.ExcelBinders
{
    /// <summary>
    /// Cung cấp phương thức Binder
    /// </summary>
    public abstract class ExcelBinderBase
    {
        /// <summary>
        /// Form Target là Form nào
        /// </summary>
        public FrmReportBase Target { set; get; }

        private int rowBegin = 7;
        /// <summary>
        /// Thiết lập Row bắt đầu thực hiện bind dữ liệu
        /// Mặc định là bắt đầu từ Row thứ 7
        /// </summary>
        public int RowBegin
        {
            get { return rowBegin; }
            set { rowBegin = value; }
        }

        private int cellStart = -1;
        /// <summary>
        /// Vị trí cell bắt đầu fill
        /// </summary>
        public int CellStart
        {
            get { return cellStart; }
            set { cellStart = value; }
        }

        public bool IsFormat { get
        {
            if (Target == null) return true;
            else return Target.IsFormat;
        }
            set { if (Target!=null) Target.IsFormat = value; }
        }
        public abstract int Bind(Workbook workbook, object data);

        private static Style styleHeader = null;
        /// <summary>
        /// Style cho Header
        /// </summary>
        public static Style StyleHeader
        {
            get 
            {
                if (styleHeader == null)
                {
                    styleHeader = CreateStyleCell();
                    styleHeader.Pattern = BackgroundType.Solid;
                    styleHeader.ForegroundColor = Color.FromArgb(191, 191, 191);
                    styleHeader.HorizontalAlignment = TextAlignmentType.Center;
                }
                return styleHeader; 
            }
        }

        private static Style styleCell = null;
        /// <summary>
        /// Style cho các cột
        /// </summary>
        public static Style StyleCell
        {
            get 
            {
                if (styleCell == null)
                    styleCell = CreateStyleCell();
                
                return styleCell; 
            }
        }

        private static Style styleCellCenter = null;
        /// <summary>
        /// 
        /// </summary>
        public static Style StyleCellCenter
        {
            get 
            {
                if (styleCellCenter == null)
                {
                    styleCellCenter = CreateStyleCell();
                    styleCellCenter.HorizontalAlignment = TextAlignmentType.Center;
                }
                return styleCellCenter; 
            }
        }

        private static Style styleCellRight = null;
        /// <summary>
        /// 
        /// </summary>
        public static Style StyleCellRight
        {
            get 
            {
                if (styleCellRight == null)
                {
                    styleCellRight = CreateStyleCell();
                    styleCellRight.HorizontalAlignment = TextAlignmentType.Right;
                }
                return styleCellRight; 
            }
        }

        private static Style styleCellLeft = null;
        /// <summary>
        /// 
        /// </summary>
        public static Style StyleCellLeft
        {
            get 
            {
                if (styleCellLeft == null)
                {
                    styleCellLeft = CreateStyleCell();
                    styleCellLeft.HorizontalAlignment = TextAlignmentType.Left;
                }
                return styleCellLeft; 
            }
        }

        /// <summary>
        /// Tạo Style cell
        /// </summary>
        /// <returns></returns>
        public static Style CreateStyleCell()
        {
            var styleCell = new Style();
            styleCell.SetBorder(BorderType.BottomBorder, CellBorderType.Thin, Color.Black);
            styleCell.SetBorder(BorderType.RightBorder, CellBorderType.Thin, Color.Black);
            styleCell.SetBorder(BorderType.LeftBorder, CellBorderType.Thin, Color.Black);
            styleCell.SetBorder(BorderType.TopBorder, CellBorderType.Thin, Color.Black);
            styleCell.IsTextWrapped = true;
            styleCell.VerticalAlignment = TextAlignmentType.Center;
            styleCell.HorizontalAlignment=TextAlignmentType.Center;
            return styleCell;
        }
    }
}
