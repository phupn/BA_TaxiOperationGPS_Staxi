#region ============= Copyright © 2016 BinhAnh =============
using OneTaxi.Utils;
using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
#endregion ============= Copyright © 2016 BinhAnh =============

namespace OneTaxi.Controls.Base.Controls.Grids.Extender
{
    public enum RealTimeStep
    {
        Step_1 = 0x1,
        Step_2 = 0x2,
        Step_3 = 0x3,
        Step_4 = 0x4,
        Step_5 = 0x5
    }

    public abstract class RealTimeGridView<TData, TKey, TCommand> : RealTimeGridView<TData, TKey>
        where TData : class,new()
        where TCommand : ICommand
    {
        public RealTimeGridView() { }
        protected List<TCommand> dicCommand = new List<TCommand>();

        [Category("RealTime")]

        public event Action<TData, TCommand> DoCommand;
        public abstract bool CheckCommand(TData data, TCommand command);

        [Category("RealTime")]
        public virtual List<TCommand> DicCommand { get { return dicCommand; } }
        public virtual void SetCommand(List<TCommand> dic)
        {
            dicCommand = dic;
        }

        [Category("RealTime")]
        public bool IsCommand { get; set; }
        public override void IniGridView() { }

        public override string GetLineVung() { return string.Empty; }
        bool LoadFisrt = true;
        protected override void OnLoaded()
        {
            if (!IsDesignMode && LoadFisrt)
            {
                if (IsCommand && DoCommand != null)
                {
                    this.KeyDown += RealTimeGridViewCommand_KeyDown;
                    LoadFisrt = false;
                }
            }
            base.OnLoaded();

        }

        private void RealTimeGridViewCommand_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (DicCommand != null)
                {
                    var Command = DicCommand.FirstOrDefault(p => ((Keys)p.Shortcuts == e.KeyData || ((int)p.Shortcuts >= 48 && (int)p.Shortcuts <= 57 && (Keys)(p.Shortcuts + 48) == e.KeyData)));
                    if (Command != null)
                    {
                        var data = FocusedRow;
                        if (CheckCommand(data, Command))
                        {
                            DoCommand(data, Command);
                        }
                    }
                }

            }
            catch (Exception ex) { ExceptionError("RealTimeGridViewCommand_KeyDown", ex); }
        }
    }

    public abstract class RealTimeGridView<TData, TKey> : GridView where TData : class,new()
    {
        protected virtual void ExceptionError(string name, Exception ex)
        {
        }
        private int rowIndex = 0;
        public virtual int RowIndex { get { return rowIndex; } set { rowIndex = value; } }
        public RealTimeGridView() { }

        public TData FocusedRow { get { return GetFocusedRow() as TData; } }
        public new TData GetRow(int index)
        {
            return base.GetRow(index) as TData;
        }
        [Category("RealTime")]

        private bool isKeyEnterAndDoubleClickOnPopUp = true;
        public bool IsKeyEnterAndDoubleClickOnPopUp { get { return isKeyEnterAndDoubleClickOnPopUp; } set { isKeyEnterAndDoubleClickOnPopUp = value; } }

        public abstract void IniGridView();
        public abstract string GetLineVung();

        private Timer Data_Timer;
        private int Data_Timer_Step_1 = 0;
        private int Data_Timer_Step_2 = 0;
        private int Data_Timer_Step_3 = 0;
        private int Data_Timer_Step_4 = 0;
        private int Data_Timer_Step_5 = 0;

        #region === Timer_Step ===
        private int _Timer_Step_1 = 0;
        /// <summary>
        /// Default=0;
        /// </summary>
        [Description("Timer_Step_1 là thời gian đợi để xử lý bước 1.")]
        [Category("RealTime")]
        public int Timer_Step_1 { get { return _Timer_Step_1; } set { _Timer_Step_1 = value; } }
        private int _Timer_Step_2 = 3;
        /// <summary>
        /// Default=3;
        /// </summary>
        [Description("Timer_Step_2 là thời gian đợi để xử lý bước 2.")]
        [Category("RealTime")]
        public int Timer_Step_2 { get { return _Timer_Step_2; } set { _Timer_Step_2 = value; } }
        private int _Timer_Step_3 = 5;
        /// <summary>
        /// Default = 5 ;
        /// </summary>
        [Description("Timer_Step_3 là thời gian đợi để xử lý bước 3.")]
        [Category("RealTime")]
        public int Timer_Step_3 { get { return _Timer_Step_3; } set { _Timer_Step_3 = value; } }
        private int _Timer_Step_4 = 10;
        /// <summary>
        /// Default = 10 ;
        /// </summary>
        [Description("Timer_Step_4 là thời gian đợi để xử lý bước 4.")]
        [Category("RealTime")]
        public int Timer_Step_4 { get { return _Timer_Step_4; } set { _Timer_Step_4 = value; } }
        private int _Timer_Step_5 = 60;
        /// <summary>
        /// Default = 60;
        /// </summary>
        [Description("Timer_Step_5 là thời gian đợi để xử lý bước 5.")]
        [Category("RealTime")]
        public int Timer_Step_5 { get { return _Timer_Step_5; } set { _Timer_Step_5 = value; } }
        #endregion

        #region == Data ==
        #region === define ===
        private int timerInterval = 1000;
        //
        // Summary:
        //     Gets or sets the time, in milliseconds, before the System.Windows.Forms.Timer.Tick
        //     event is raised relative to the last occurrence of the System.Windows.Forms.Timer.Tick
        //     event.
        //
        // Returns:
        //     An System.Int32 specifying the number of milliseconds before the System.Windows.Forms.Timer.Tick
        //     event is raised relative to the last occurrence of the System.Windows.Forms.Timer.Tick
        //     event. The value cannot be less than one.
        [Description("TimerInterval,Là thời gian trễ timer milliseconds")]
        [Category("RealTime")]
        public virtual int TimerInterval { get { return timerInterval; } set { timerInterval = value; } }
        private bool isPopUp = false;
        [Description("IsPopUp = true,Cho phép gọi tới sự kiện Popup khi có dữ liệu mới.")]
        [Category("RealTime")]
        public virtual bool IsPopUp { get { return isPopUp; } set { isPopUp = value; } }

        private DateTime LastUpdate = DateTime.MinValue;
        private DateTime LastNew = DateTime.MinValue;

        private List<TData> _listData = new List<TData>();

        [Category("RealTime")]
        public List<TData> ListData { get { return _listData; } protected set { _listData = value; } }
        #endregion

        #region === Func Get Data ===
        [Category("RealTime")]
        public Func<string, List<TData>> FuncGetAll;
        [Category("RealTime")]
        public Func<string, DateTime, List<TData>> FuncGetNew;
        [Category("RealTime")]
        public Func<string, DateTime, List<TData>> FuncGetUpdate;
        [Category("RealTime")]
        public Func<string, string, List<TKey>> FuncGetDelete;
        #endregion

        #region === Func ===
        public Func<TData, TKey> GetKey;
        public Func<TData, DateTime> GetLastUpdate;

        public Func<TData, bool> CheckPopup;
        public Func<DateTime> FuncGetTimerServer;
        public event Action<TData> ActionPopUp;
        public Action<TData, TData> ActionUpdateData;
        protected void SetDataSource(object data)
        {
            if (GridControl != null)
                GridControl.DataSource = data;

        }
        public virtual void ShowPopUp(int IndexCuocGoi = 0)
        {
            if (ActionPopUp != null)
            {
                if (ListData != null && IndexCuocGoi < ListData.Count)
                {
                    ActionPopUp(ListData[IndexCuocGoi]);
                }
            }
        }
        protected virtual void AddNew(TData data)
        {
            this.ListData.Insert(0, data);
            RowIndex++;
        }
        public virtual void FindAndUpdate(TData data)
        {
            var update = ListData.FirstOrDefault(p => GetKey(p).Equals(GetKey(data)));
            if (update != null)
            {
                ActionUpdateData(update, data);
                RefreshDataRealTime();
            }
        }
        public virtual void FindAndRemove(TData data)
        {
            ListData.RemoveAll(p => GetKey(p).Equals(GetKey(data)));
            RefreshDataRealTime(true);
        }
        #endregion

        #region === Process Data ===
        public virtual void LoadAll()
        {
            try
            {
                if (FuncGetAll != null)
                {
                    LastUpdate = FuncGetTimerServer();
                    LastNew = LastUpdate;
                    System.Threading.Tasks.Task.Factory.StartNew(() =>
                    {
                        lock (_listData)
                        {
                            _listData = FuncGetAll(GetLineVung());
                        }
                    }).ContinueWith((T) =>
                    {
                        this.SetDataSource(_listData);

                    }, TaskScheduler.FromCurrentSynchronizationContext());
                }
            }
            catch (Exception ex)
            {
                ExceptionError(string.Format("{0}.LoadAll", this.Name), ex);
            }
        }

        protected virtual KeyValuePair<bool, bool> GetNew()
        {
            bool isNew = false;
            bool isPopup = false;
            try
            {
                if (FuncGetNew != null)
                {
                    var lsNew = FuncGetNew(GetLineVung(), LastNew);
                    if (lsNew != null && lsNew.Count > 0)
                    {

                        foreach (var item in lsNew)
                        {
                            if (GetLastUpdate != null)
                            {
                                if (LastNew < GetLastUpdate(item)) LastNew = GetLastUpdate(item);
                            }
                            isNew = true;
                            var IndexRow = ListData.FindIndex(p => GetKey(p).Equals(GetKey(item)));
                            if (IndexRow < 0)
                            {

                                AddNew(item);
                                if (CheckPopup(item))
                                {
                                    isPopup = true;
                                }
                            }
                            else
                            {
                                if (ActionUpdateData != null)
                                {
                                    ActionUpdateData(ListData[IndexRow], item);
                                }
                            }
                        }
                        this.RowIndex = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionError(string.Format("{0}.GetNew", this.Name), ex);
            }
            return new KeyValuePair<bool, bool>(isNew, isPopup);

        }

        protected virtual bool GetUpdate()
        {
            bool isChange = false;
            try
            {
                if (FuncGetUpdate != null)
                {
                    var lsUpdate = FuncGetUpdate(GetLineVung(), LastUpdate);
                    if (lsUpdate != null && lsUpdate.Count > 0)
                    {
                        foreach (var item in lsUpdate)
                        {
                            if (GetLastUpdate != null)
                            {
                                if (LastUpdate < GetLastUpdate(item)) LastUpdate = GetLastUpdate(item);
                            }
                            var itemUpdate = ListData.Where(p => GetKey(p).Equals(GetKey(item))).FirstOrDefault();
                            if (itemUpdate != null)
                            {
                                isChange = true;
                                if (ActionUpdateData != null)
                                {
                                    ActionUpdateData(itemUpdate, item);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionError(string.Format("{0}.GetUpdate", this.Name), ex);
            }
            return isChange;
        }

        protected virtual bool GetDelete()
        {

            bool isChange = false;
            try
            {
                if (FuncGetDelete != null)
                {
                    if (this.ListData != null && this.ListData.Count > 0)
                    {
                        string lsKeys = string.Empty;

                        lsKeys = this.ListData.Select(p => GetKey(p).ToString()).Aggregate((T1, T2) => string.Format("{0},{1}", T1, T2)).Trim(',');
                        var lsId = FuncGetDelete(GetLineVung(), lsKeys);
                        if (lsId != null && lsId.Count > 0)
                        {
                            foreach (var id in lsId)
                            {
                                var IndexRow = this.ListData.FindIndex(p => GetKey(p).Equals(id));
                                if (IndexRow >= 0)
                                {
                                    isChange = true;
                                    if (IndexRow < RowIndex) RowIndex--;
                                    this.ListData.RemoveAt(IndexRow);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionError(string.Format("{0}.GetDelete", this.Name), ex);
            }

            return isChange;
        }
        public virtual void RefreshDataRealTime(bool add = false)
        {
            int RowTop = this.RowIndex - (this.FocusedRowHandle - this.TopRowIndex);
            //  if (add) RowTop = 0;
            int RowIndex = this.RowIndex;

            if (add)
            {
                this.SetDataSource(ListData);
                this.RefreshData();
            }
            else
            {
                this.RefreshData();
            }
            if (RowTop < ListData.Count) this.TopRowIndex = RowTop;

            if (RowIndex < ListData.Count) this.FocusedRowHandle = RowIndex;

        }
        #endregion
        #endregion

        #region == RealTime ==

        public event Action<RealTimeStep> EventActionStep;
        public virtual void ActionStep(RealTimeStep StepIndex)
        {
            try
            {
                switch (StepIndex)
                {
                    case RealTimeStep.Step_1:
                        //Thực hiện Kiểm tra dữ liệu thêm mới.
                        var value = GetNew();
                        if (value.Key)
                        {
                            RefreshDataRealTime(true);
                        }
                        if (value.Value)
                        {
                            ShowPopUp();
                        }
                        break;

                    case RealTimeStep.Step_2:
                        //Thực hiện cập nhật dữ liệu thay đổi
                        var IsChange = GetUpdate();
                        if (IsChange)
                        {
                            RefreshDataRealTime(true);
                        }
                        break;

                    case RealTimeStep.Step_3:
                        // Thực hiện cập nhật dữ liệu kết thúc.
                        var IsDelete = GetDelete();
                        if (IsDelete)
                        {
                            RefreshDataRealTime(true);
                        }
                        break;

                    case RealTimeStep.Step_4:
                        break;

                    case RealTimeStep.Step_5:
                        break;

                }
            }
            catch (Exception ex)
            {
                ExceptionError(string.Format("{0}.ActionStep[{1}]", this.Name, StepIndex.ToString()), ex);
            }
            try
            {
                if (EventActionStep != null)
                {
                    EventActionStep(StepIndex);
                }
            }
            catch (Exception ex)
            {
                ExceptionError(string.Format("{0}.EventActionStep[{1}]", this.Name, StepIndex.ToString()), ex);
            }
        }
        protected virtual void IniRealTime()
        {
            Data_Timer = new Timer();
            Data_Timer.Interval = TimerInterval;
            Data_Timer.Tick += Data_Timer_Tick;
        }

        void Data_Timer_Tick(object sender, EventArgs e)
        {
            Data_Timer_Step_1++;
            Data_Timer_Step_2++;
            Data_Timer_Step_3++;
            Data_Timer_Step_4++;
            Data_Timer_Step_5++;

            if (Data_Timer_Step_1 > Timer_Step_1)
            {
                ActionStep(RealTimeStep.Step_1);
                Data_Timer_Step_1 = 0;
            }
            if (Data_Timer_Step_2 > Timer_Step_2)
            {
                ActionStep(RealTimeStep.Step_2);
                Data_Timer_Step_2 = 0;
            }
            if (Data_Timer_Step_3 > Timer_Step_3)
            {
                ActionStep(RealTimeStep.Step_3);
                Data_Timer_Step_3 = 0;
            }
            if (Data_Timer_Step_4 > Timer_Step_4)
            {
                ActionStep(RealTimeStep.Step_4);
                Data_Timer_Step_4 = 0;
            }
            if (Data_Timer_Step_5 > Timer_Step_5)
            {
                ActionStep(RealTimeStep.Step_5);
                Data_Timer_Step_5 = 0;
            }
        }
        public virtual void StartRealTime()
        {
            IniRealTime();
            Data_Timer.Start();
        }
        public virtual void StopRealTime()
        {
            try
            {
                Data_Timer.Stop();
                Data_Timer.Dispose();
                Data_Timer = null;
            }
            catch (Exception ex) { }
        }
        #endregion

        #region == Event Control ==
        protected override void OnLoaded()
        {
            base.OnLoaded();
            if (IsDesignMode) return;
            if (LoadFisrt)
            {
                LoadFisrt = false;
                if (IsKeyEnterAndDoubleClickOnPopUp)
                {
                    KeyDown += (s, e) =>
                    {
                        if (e.KeyData == System.Windows.Forms.Keys.Enter)
                        {
                            this.ShowPopUp(this.FocusedRowHandle);
                        }
                    };
                    DoubleClick += (s, e) =>
                    {
                        this.ShowPopUp(this.FocusedRowHandle);
                    };
                }
                try
                {
                    IniGridView();
                }
                catch (Exception ex)
                {
                    ExceptionError(string.Format("{0}.IniGridView", this.Name), ex);
                }
            }
        }
        bool LoadFisrt = true;
        protected override void DoChangeFocusedRow(int currentRowHandle, int newRowHandle, bool raiseUpdateCurrentRow)
        {
            base.DoChangeFocusedRow(currentRowHandle, newRowHandle, raiseUpdateCurrentRow);
            this.RowIndex = newRowHandle;
        }
        #endregion
    }
}