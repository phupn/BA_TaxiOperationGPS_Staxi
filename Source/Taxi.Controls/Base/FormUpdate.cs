using System;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraRichEdit.Utils;
using Taxi.Common.DbBase;
using Taxi.Controls.Base.Extender;
using System.Collections.Generic;
using Taxi.Utils;

namespace Taxi.Controls.Base
{
    /// <summary>
    ///  Form Base Update
    /// </summary>
    public partial class FormUpdate : FormBase
    {
        #region ==== Field ====
        private ModelBase _model;
        public ModelBase Model { get { return _model ?? (_model = ModelNew); } }
        private bool isNew = true;
        public bool IsNew {get { return isNew; }}
        private bool isLoad = true;
        protected bool IsLoad
        {
            get
            {
                return isLoad;
            }
        }
        public virtual ModelBase ModelNew
        {
            get
            {
                return null;
            }
        }
        public string[] FieldEnable { get; set; }
        private FormManager _formManger;

        public FormManager FormParrent { get { return _formManger; } private set { _formManger = value; } }
        #endregion

        #region ==== Function  ====
        public void SetModel(ModelBase model,FormManager parrent=null)
        {
            isNew = model==null;
            _model = model;
            FormParrent = parrent;
        }
        public void SetMessage(string msg)
        {
            lblMessage.Text = msg;
            lblMessage.Location = new Point((this.Width - lblMessage.Width) / 2, lblMessage.Location.Y);
        }
        #endregion

        #region ==== virtual ====
        /// <summary>
        /// Do Validate
        /// </summary>
        /// <returns></returns>
        public virtual bool DoValidate()
        {
           
            return true;
        }
        /// <summary>
        /// Do Save
        /// </summary>
        /// <returns></returns>
        public virtual bool DoSave()
        {
            try
            {
                Model.Save();
                return true;
            }
            catch (Exception ex)
            {
                SetMessage(ex.Message);
                return false;
            }
        }
        /// <summary>
        /// After Load
        /// </summary>
        public virtual void AfterLoad() { }

        #endregion

        #region ==== Event ====

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                SetMessage(string.Empty);
                if (DoValidate())
                {
                    panelInputView.ParseTo(Model, false);

                    if (DoSave())
                    {
                        this.DialogResult=DialogResult.OK;
                        Close();
                    }

                }
            }
            catch (Exception ex)
            {
                SetMessage(ex.Message);
            }
        }

        private void FormUpdate_Resize(object sender, EventArgs e)
        {
            panelButton.Location = new Point((this.Width - panelButton.Width) / 2, panelButton.Location.Y);
            lblMessage.Location = new Point((this.Width - lblMessage.Width) / 2, lblMessage.Location.Y);
        }

        private void FormUpdate_Load(object sender, EventArgs e)
        {
            try
            {
                if (DesignTimeHelper.IsInDesignMode) return;
                panelInputView.BindShControl();
                if (!IsNew)
                {
                    panelInputView.SetEnabled(false, true, this.FieldEnable);
                    panelInputView.Fill(Model);
                }

                SetMessage(string.Empty);
                panelInputView.FocusInput();
            }
            catch (Exception ex)
            {
                SetMessage(ex.Message);
            }
            finally
            {
                AfterLoad();
            }
            isLoad = false;
        }

        #endregion

    }

}
