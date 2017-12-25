using System;
using System.ServiceModel;

namespace Taxi.Services
{
    public class ConnectService<TClient> where TClient : class, ICommunicationObject, IDisposable, new()
    {
        private TClient client = null;

        private TClient Client
        {
            get
            {
                if (client == null) NewAndOpen();

                else
                {
                    switch(client.State)
                    {
                        case CommunicationState.Closed:
                        case CommunicationState.Closing:
                        case CommunicationState.Faulted:
                            NewAndOpen(); // Khởi tạo connection mới
                            break;
                    }
                }
                return client;
            }
        }

        public bool Try(Action<TClient> action, int total = 10)
        {
            try
            {
                using (var client = new TClient())
                {
                    action(client);
                }
                return true;
            }
            catch { return false; }

            //var i = 0;            
            //while(i < total)
            //{
            //    try
            //    {

            //        switch (Client.State)
            //        {
            //            case CommunicationState.Opening: 
            //                i++;
            //                if (i >= total) TryDispose();
            //                Thread.Sleep(100); 
            //                continue;
            //            case CommunicationState.Opened:

            //                try
            //                {
            //                    action(Client);
            //                    return true;
            //                }
            //                catch
            //                {
            //                    TryDispose(); // Nếu gặp lỗi khi mở connection => cố gắng mở lại
            //                    i++; Thread.Sleep(100);
            //                }
            //                break;
            //        }
            //    }
            //    catch
            //    {
            //        TryDispose(); // Nếu gặp lỗi khi mở connection => cố gắng mở lại
            //        i++; Thread.Sleep(100);
            //    }
            //}
            //return false;
        }

        public Result<T> TryGet<T>(Func<TClient, T> action, int total = 10)
        {
            var t = default(T);
            var success = Try(client => t = action(client), total);
            return new Result<T> { Success = success, Value = t };
        }

        private void NewAndOpen()
        {
            TryDispose();
            client = new TClient();
            client.Open();
        }
        public void SetClient(TClient _client)
        {
            client = _client;
            client.Open();
        }

        private void TryDispose()
        {
            if (client != null)
            {
                try { client.Dispose(); }
                catch { }
                finally { client = null; }
            }
        }

        public class Result<T>
        {
            public bool Success { set; get; }
            public T Value { set; get; }
        }
    }
}
