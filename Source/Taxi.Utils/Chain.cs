using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Taxi.Common.Extender;

namespace Taxi.Utils
{
    public abstract class Chain<T>
    {
        /// <summary>
        /// Một handler phụ
        /// </summary>
        private T handler;
        /// <summary>
        /// Handler phụ
        /// </summary>
        protected T Handler { get { return handler; } }

        /// <summary>
        /// Thực hiện Set Handler theo kiểu Generic
        /// </summary>
        public void SetHandler<THandler>(Action<THandler> action = null) where THandler : T, new()
        {
            // Khởi tạo một Handler mới
            THandler newHandler = new THandler();

            // Xử lý sau khi khởi tạo
            if (action != null) action(newHandler);

            // Thực hiện Set Handler
            this.SetHandler(newHandler);
        }

        /// <summary>
        /// Thực hiện Set Handler
        /// </summary>
        public void SetHandler(T newHandler)
        {
            // Nếu như Handler phụ hiện thời mà không phải Null, đồng thời lại là ChainResponsibility<T>
            // Thì cho Handler phụ thiết lập thêm Handler
            if (this.handler != null && this.handler.Is<Chain<T>>()) this.handler.As<Chain<T>>().SetHandler(newHandler);

            // Ngược lại thì thiết lập cho Handler phụ
            else this.handler = newHandler;
        }
    }
}
