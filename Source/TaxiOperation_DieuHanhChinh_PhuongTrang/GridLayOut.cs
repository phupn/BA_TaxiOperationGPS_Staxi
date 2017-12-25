using System;
using System.Data;
using Janus.Windows.GridEX;


namespace Taxi.GUI
{
    /// <summary>
    /// lớp này thục hiện chức năng lưu layout của griđ
    /// </summary>
   public  class GridLayout
   {
       private string gUser_Id;
       private string gAppName;
       private string gFormId;
       private string gControlId;
       private int gLayoutId = 0;

       public GridLayout(string user_Id, string appName, string formId, string controlId)
       {
           gUser_Id = user_Id;
           gAppName = appName;
           gFormId = formId;
           gControlId = controlId;
       }



       /// <summary>
       /// Insert noi dung Layout
       /// </summary>       
       public bool InsertLayout(string User_Id, string AppName, string FormId,
                       string ControlId, string LayoutString)
       {
           return new Data.GridLayout.GridLayout().InsertLayout(User_Id, AppName, FormId, ControlId, LayoutString);
       }

       /// <summary>
       /// Update noi dung Layout
       /// </summary>       
       public bool UpdateLayout(int Id, string LayoutString)
       {
           return new Data.GridLayout.GridLayout().UpdateLayout(Id, LayoutString);
       }

       /// <summary>
       /// Select Layout
       /// </summary>       
       public DataTable SelectLayout(string User_Id, string AppName, string FormId,string ControlId)
       {
           return new Data.GridLayout.GridLayout().SelectLayout(User_Id, AppName, FormId, ControlId);
       }


       public GridEXLayout getLayout(GridEXLayout gridEXLayout)
       {
           DataTable dt = new DataTable();
           dt = SelectLayout(gUser_Id, gAppName, gFormId, gControlId);
           if (dt != null && dt.Rows.Count > 0)
           {
               GridEXLayout Layout = new GridEXLayout();
               Layout.IsCurrentLayout = true;
               Layout.Key = "1";
               Layout.LayoutString = dt.Rows[0]["LayoutString"].ToString();

               gLayoutId = Convert.ToInt32(dt.Rows[0]["Id"].ToString());
               return Layout;
           }
           else
           {
               return gridEXLayout;
           }

       }

       public void setLayout(string LayoutString)
       {
           if (gLayoutId > 0)
           {
               if (UpdateLayout(gLayoutId, LayoutString))
               {
                   new MessageBox.MessageBoxBA().Show("Thiết lập cấu hình hiển thị thành công", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Information);
               }
               else
               {
                   new MessageBox.MessageBoxBA().Show("Vui lòng thoát chương trình và thử lại.", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
               }
           }
           else
           {
               if (InsertLayout(gUser_Id, gAppName, gFormId, gControlId, LayoutString))
               {
                   new MessageBox.MessageBoxBA().Show("Thiết lập cấu hình hiển thị thành công", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Information);
               }
               else
               {
                   new MessageBox.MessageBoxBA().Show("Vui lòng thoát chương trình và thử lại.", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
               }
           }
       }
   }
}
