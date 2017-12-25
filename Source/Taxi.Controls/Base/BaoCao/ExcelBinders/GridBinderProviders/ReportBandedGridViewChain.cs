using DevExpress.XtraGrid.Views.BandedGrid;
using Taxi.Common.Extender;
using Taxi.Controls.Base.Controls;
namespace Taxi.Controls.BaoCao.ExcelBinders.GridBinderProviders
{
    public class ReportBandedGridViewChain : ReportGridChain<ShBandedGridView>
    {
        protected override ColumnConfig DoProcess(ShBandedGridView t)
        {
            // Tạo config
            var config = new ColumnConfig();

            // Xử lý tạo config
            ProcessCreateConfig(config, t.Bands);

            // return
            return config;
        }

        /// <summary>
        /// Hàm Test xử lý
        /// </summary>
        /// <param name="stt"></param>
        /// <param name="config"></param>
        /// <param name="bands"></param>
        private void ProcessCreateConfig(ColumnConfig config, GridBandCollection bands)
        {
            // Duyệt qua từng Brand
            for (int i = 0; i < bands.Count; i++)
            {
                // Khởi tạo một config column
                // Đưa vào config cha
                var tc = this.CreateColumnConfig(bands[i]);
                config.Columns.Add(tc);

                // Nếu có Brand con thì tiếp tục xử lý
                if (bands[i].HasChildren) ProcessCreateConfig(tc, bands[i].Children);

                // Còn nếu không thì tạo config cho cột con
                else for (int j = 0; j < bands[i].Columns.Count; j++)
                    tc.Columns.Add(this.CreateColumnConfig(bands[i].Columns[j]));
            }
        }
    }
}
