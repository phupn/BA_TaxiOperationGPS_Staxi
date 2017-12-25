using System;
namespace APIServices.DAL
{
    public abstract class Base : IDisposable 
    {
        //------------------------------------------        
        // store Error Message
        protected string strErrorMsg;
        // store Error Code
        protected int intErrorCode;
        // store SQL Statement output string
        protected string strSQL;

        //------------------------------------------
        // Properties 
        //------------------------------------------
        // Error Message property

        public string ErrorMsg
        {
            get 
            {
                return strErrorMsg;
            }
            set 
            {
                strErrorMsg = value;
            }
        }


        // Error Code property
        public int ErrorCode
        {
            get 
            {
                return intErrorCode;
            }
            set
            {
                intErrorCode = value;
            }
        }

        // SQL property
        public string SQL
        {
            get 
            {
                return strSQL;
            }
            set
            {
                strSQL = value;
            }
        }

        public void Dispose()
        {
            Dispose();
            System.GC.SuppressFinalize(this);
        }
            
        //protected void Finalize()
        //{
        //    // Simply call Dispose(False).
        //    Dispose(false);
        //}
    }
}