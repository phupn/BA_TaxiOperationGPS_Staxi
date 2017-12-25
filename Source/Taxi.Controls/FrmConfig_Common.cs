using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Taxi.Business;
using Taxi.Common.EnumUtility;
using Taxi.Common.Extender;
using Taxi.Controls.Base;
using Taxi.Controls.Base.Inputs;
using Taxi.Utils;
using Taxi.Controls.Base.Extender;
using Taxi.Controls.Base.Controls;
namespace Taxi.Controls
{
    public partial class FrmConfig_Common : FormBase
    {
        private bool IsSave = false;
        #region === Event Form ====
        private void FrmConfig_Common_Load(object sender, EventArgs e)
        {
            IniLayout(Config_Common.ColConfig);
        }
        private void FrmConfig_Common_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (IsSave)
            {
                try
                {
                    Config_Common.LoadConfig_Common();
                }
                catch (Exception ex)
                {
                    LogError.WriteLogError("FrmConfig_Common.Closed", ex);
                }
            }
        }
        private void shButton1_Click(object sender, EventArgs e)
        {

            if ((new MessageBox.MessageBoxBA()).Show("Bạn có muốn lưu cấu hình hiện tại không?\nLưu ý:Chỉ lưu những cấu hình được thay đổi.", "Thông báo", MessageBox.MessageBoxButtonsBA.YesNo).ToUpper() == "Yes".ToUpper())
            {
                IsSave = true;
                DoSave();
                
            }
        }
        #endregion
        #region === Xử lý ===
        /// <summary>
        /// Xử lý những dữ liệu thay đổi
        /// </summary>
        private void DoSave()
        {
            var ListUpdate = LayoutControl.FindAllChildrenByType<Control>().Where(c => c is IShInput && c.Tag != null && c.Tag.ToString() != null && c is ITextChange && ((ITextChange)c).IsChangeText).Cast<IShInput>().ToList();
            if (ListUpdate != null && ListUpdate.Count > 0)
            {
                ListUpdate.ForEach(p =>
                {
                    Config_Common.Update(((Control)p).Tag.To<int>(), ConvertToString(p.GetValue()));
                    ((ITextChange)p).IsChangeText = false;
                });
            }
        }
        private string ConvertToString(object value)
        {
            if (value is Color)
            {
                return ((Color)value).Name;
            }
            return value.ToString();
        }
        public List<Config_Common> db;
        private void AddControl(Config item, ref int i)
        {
            if (item.ItemType != null)
            {
                object Input = null;
                bool IsDefault = false;
                ShLabel lbl = new ShLabel()
                {
                    Name = string.Format("lbl_{0}", i),
                    Visible = true,
                    Text = String.Format("{0}", i),
                    Dock = DockStyle.Fill,
                    ToolTip = item.ItemType.Description
                };
                lbl.Text = string.Format("[{0}].{1}", (int)item.EnumValue, item.ItemType.Name);
                string valueEnum = null;

                if (db != null)
                {
                    var itemEnum = db.FirstOrDefault(p => p.Id == (int)item.EnumValue);
                    if (itemEnum != null)
                    {
                        valueEnum = itemEnum.HasValue;
                    }
                }
                if (valueEnum == null)
                {
                    var itemEnum = item.listDisplayValue.FirstOrDefault(p => p.IsDefault);
                    if (itemEnum != null)
                    {
                        IsDefault = true;
                        valueEnum = itemEnum.Value.ToString();
                    }
                }
                if (valueEnum == null)
                {
                    valueEnum = string.Empty;
                }
                if (item.ItemType.Type == Enum_ItemType.Auto)
                {

                    if (item.listDisplayValue != null && item.listDisplayValue.Count > 1)
                    {
                        var inputText = new InputLookUp()
                        {
                            Visible = true,
                            Tag = (int)item.EnumValue
                        };
                        inputText.Properties.DisplayMember = "DisplayName";
                        inputText.Properties.ValueMember = "Value";
                        inputText.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DisplayName", " "));
                        inputText.Properties.DataSource = item.listDisplayValue;
                        inputText.Dock = DockStyle.Fill;
                        inputText.Properties.MaxLength = item.ItemType.Length;
                        inputText.ToolTip = item.ItemType.Description;
                        inputText.SetValue(valueEnum);
                        if (IsDefault)
                        {
                            inputText.IsChangeText = true;
                            inputText.BackColor = Color.YellowGreen;
                        }
                        Input = inputText;
                    }
                    else
                    {
                        if (item.ItemType.ValueEnum == null)
                        {
                            var inputText = new InputText()
                            {
                                Visible = true,
                                Tag = (int)item.EnumValue,
                                Dock = DockStyle.Fill
                            };
                            inputText.Properties.MaxLength = item.ItemType.Length;
                            inputText.ToolTip = item.ItemType.Description;
                            inputText.SetValue(valueEnum);
                            if (IsDefault)
                            {
                                inputText.IsChangeText = true;
                                inputText.BackColor = Color.YellowGreen;
                            }
                            if (!string.IsNullOrEmpty(item.ItemType.TextMask))
                            {
                                inputText.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
                                inputText.Properties.Mask.EditMask = item.ItemType.TextMask;
                            }
                            Input = inputText;
                        }
                        else
                        {
                            var inputText = new InputLookUp()
                            {
                                Visible = true,
                                Tag = (int)item.EnumValue
                            };
                            ;
                            inputText.Properties.DisplayMember = "Name";
                            inputText.Properties.ValueMember = "Value";
                            inputText.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", " "));
                            if (IsDefault)
                            {
                                inputText.IsChangeText = true;
                                inputText.BackColor = Color.YellowGreen;
                            }
                            try
                            {
                                inputText.Properties.DataSource = Enum.GetValues(item.ItemType.ValueEnum).Cast<Object>().Select(
                             p =>
                             {
                                 var en = p.GetType().GetField(p.ToString()).GetAttribute<EnumItemAttribute>();
                                 en.Value = ((int)p).ToString();
                                 en.ValueEnum = p;
                                 return en;
                             }).ToList();
                            }
                            catch (Exception ex)
                            {
                                LogError.WriteLogError("FrmConfig_Common.1", ex);
                            }

                            //InputLookUpEnum.Properties.DataSource = item.listDisplayValue;
                            inputText.Dock = DockStyle.Fill;
                            inputText.Properties.MaxLength = item.ItemType.Length;
                            inputText.ToolTip = item.ItemType.Description;
                            inputText.SetValue(valueEnum);
                            Input = inputText;
                        }


                    }
                }
                else if (item.ItemType.Type == Enum_ItemType.Color)
                {
                    var inputText = new InputColorPicker()
                    {
                        Visible = true,
                        Tag = (int)item.EnumValue,
                        Dock = DockStyle.Fill,
                    };
                    inputText.Properties.MaxLength = item.ItemType.Length;
                    inputText.Properties.ShowColorDialog = false;
                    inputText.Properties.ShowCustomColors = false;
                    inputText.Properties.ShowSystemColors = false;
                    inputText.ToolTip = item.ItemType.Description;
                    inputText.SetValue(Color.FromName(valueEnum));
                    if (IsDefault)
                    {
                        inputText.IsChangeText = true;
                        inputText.BackColor = Color.YellowGreen;
                    }
                    if (!string.IsNullOrEmpty(item.ItemType.TextMask))
                    {
                        inputText.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
                        inputText.Properties.Mask.EditMask = item.ItemType.TextMask;
                    }
                    Input = inputText;
                }
                int row = i / (LayoutControl.ColumnCount);
                int col = (int)(i - row * (LayoutControl.ColumnCount) - 1);
                LayoutControl.Controls.Add(lbl, col, row);
                if (Input == null)
                    Input = new Label()
                    {
                        Name = string.Format("lblT_{0}", i),
                        Visible = true,
                        Text = String.Format("Chưa có n/d,{0}", i)
                    };
                LayoutControl.Controls.Add((Control)Input, col + 1, row);
                i += 2;
            }

        }
        /// <summary>
        /// Tạo layout có 6 Cột
        /// </summary>
        private void IniLayout(int col=6)
        {
            db = Config_Common.GetAllConfig();

            #region === Ini Layout ===
            LayoutControl.RowStyles.Clear();
            LayoutControl.ColumnStyles.Clear();
            LayoutControl.ColumnCount = col;

            int index = 1;
            var lsEnum = Enum.GetValues(typeof(Enum_Config_Common)).Cast<Enum_Config_Common>().Select(p =>
               new Config
               {
                   EnumValue = p,
                   TypeEnum = p.GetType(),
                   listDisplayValue = EnumHandler<Enum_Config_Common>.Inst.GetListAttributes<DisplayValueAttribute>(p).OrderBy(p1=>p1.OrderBy).ToList(),
                   ItemType = EnumHandler<Enum_Config_Common>.Inst.GetAttribute<EnumItemTypeAttribute>(p)
               }).Where(p => p.ItemType != null).ToList();
            LayoutControl.RowCount = lsEnum.Count * 2 / (LayoutControl.ColumnCount);
            this.Width = (LayoutControl.ColumnCount / 2) * (220 + 120) + 50;
            this.Height = LayoutControl.RowCount * 25 + panel1.Height + 120;
            // this.StartPosition = FormStartPosition.CenterScreen;
            foreach (var item in lsEnum)
            {
                try
                {
                    LayoutControl.RowStyles.Add(new RowStyle() { SizeType = SizeType.Absolute, Height = 25 });
                    LayoutControl.ColumnStyles.Add(new ColumnStyle() { SizeType = SizeType.Absolute, Width = 220 });
                    LayoutControl.ColumnStyles.Add(new ColumnStyle() { SizeType = SizeType.Absolute, Width = 120 });
                    AddControl(item, ref index);

                }
                catch (Exception ex)
                {
                    LogError.WriteLogError("", ex);
                }
            }

            #endregion
        }
        public class Config
        {
            public Type TypeEnum { get; set; }
            public object EnumValue { get; set; }
            public List<DisplayValueAttribute> listDisplayValue { get; set; }
            public EnumItemTypeAttribute ItemType { get; set; }
        }
        #endregion

       
    }
}
