using DevExpress.Mvvm;
using Grpc.Core;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace POS.Client.ViewModels
{
    public abstract class BaseViewModel : ViewModelBase, IDisposable
    {
        public const string Address = "https://localhost:5001";

        public IMessageBoxService MessageBoxService { get { return GetService<IMessageBoxService>(); } }
        public IDispatcherService DispatcherService { get { return this.GetService<IDispatcherService>(); } }
      
        public bool IsNewRecord { get; set; }
        private ObservableCollection<object> _Collection;

        public ObservableCollection<object> GridCollection
        {
            get { return _Collection; }
            set { SetValue(ref _Collection, value); }
        }
        // Flag: Has Dispose already been called?
        internal bool disposed = false;
        // Instantiate a SafeHandle instance.
        internal SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected abstract void Dispose(bool disposing);

        private static async Task<string> Authenticate()
        {
            var httpClient = new HttpClient();
            var request = new HttpRequestMessage
            {
                RequestUri = new Uri($"{Address}/generateJwtToken?name={HttpUtility.UrlEncode(Environment.UserName)}"),
                Method = HttpMethod.Get,
                Version = new Version(2, 0)
            };
            var tokenResponse = await httpClient.SendAsync(request);
            tokenResponse.EnsureSuccessStatusCode();

            var token = await tokenResponse.Content.ReadAsStringAsync();
            Console.WriteLine("Successfully authenticated.");

            return token;
        }

        private static Metadata? TokenHeader(string? token)
        {
            Metadata? headers = null;
            if (token != null)
            {
                headers = new Metadata();
                headers.Add("Authorization", $"Bearer {token}");
            }

            return headers;
        }
    }
}
