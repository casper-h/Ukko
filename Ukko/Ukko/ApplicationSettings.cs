using System;
using System.Collections.Generic;
using System.Text;

namespace Ukko
{
    public static class ApplicationSettings
    {
        /// <summary>
        /// From ipconfig or from conveyor
        /// </summary>
        public static readonly string LOCALHOST_API_ADDRESS = "YOUR_LAN_IP_HERE";

        public static readonly string RELEASE_API_ADDRESS = "https://ukkoapi.azurewebsites.net/api";

        public static readonly string AzureBackendUrl = App.IS_DEBUG
            ? LOCALHOST_API_ADDRESS
            : RELEASE_API_ADDRESS;
    }
}
