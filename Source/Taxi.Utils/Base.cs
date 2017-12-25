using System;
namespace Taxi.Utils
{
    public abstract class Base : IDisposable 
    {
        //------------------------------------------        
        // store Error Message
        protected string strErrorMsg;
        // store Error Code
        protected int intErrorCode;
        // store SQL Statement output string
        protected string querySQL;

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
                return querySQL;
            }
            set
            {
                querySQL = value;
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}