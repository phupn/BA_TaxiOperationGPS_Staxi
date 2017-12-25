using Staxi.Utils.DbBase;
using System;

namespace OneTaxi.Controls.Base.Forms
{
    public partial class FormUpdate : FormBase
    {
        public FormUpdate()
        {
            InitializeComponent();
        }
        public FormUpdate(ModelBase model)
        {
            InitializeComponent();
            modelUpdate = model;
        }
        public bool IsLoadForm = false;
        public virtual ModelBase ModelNew { get { return null; } }
        private ModelBase modelUpdate { get; set; }
        public ModelBase ModelSave { get { return modelUpdate ?? (modelUpdate = ModelNew); } }
        public void SetModel(ModelBase model)
        {
            modelUpdate = model;
        }
        private bool isNew=true;
        public virtual bool IsNew { get { return isNew; } }
        public virtual bool DoValidate()
        {
            return true;
        }
        public virtual void DoShowMessage(string message)
        {
            lblMsg.Text = message;
        }
        public virtual bool DoParse()
        {
            if (modelUpdate != null)
            {
                panelView.ParseTo(ModelSave);
                return true;
            }
            return false;
        }
        public virtual bool DoFill()
        {
            if (modelUpdate != null)
            {
                panelView.Fill(modelUpdate);
                return true;
            }
            return false;
        }
        public virtual bool DoSave()
        {
            ModelSave.Save();
            return true;
        }
        protected override void OnLoad(EventArgs e)
        {
            if (IsLoadForm)
            LoadModel(modelUpdate);
            base.OnLoad(e);
        }
        public virtual void LoadModel(ModelBase model)
        {
            try
            {
                DoShowMessage(string.Empty);
                modelUpdate = model;
                panelView.ClearForm();
                panelView.BindData();
                isNew = !DoFill();
            }
            catch (Exception ex)
            {
                DoShowMessage(ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (DoValidate())
                {
                    DoFill();
                    DoSave();
                    DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                DoShowMessage(ex.Message);
            }
           
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
    }
}
