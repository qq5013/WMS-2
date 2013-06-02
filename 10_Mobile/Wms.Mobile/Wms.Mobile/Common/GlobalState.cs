using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Spring.Rest.Client;
using Newtonsoft.Json.Converters;
using Spring.Http.Converters.Json;
using Spring.Rest.Client;
using Spring.Http;
using Spring.Http.Converters;
using Spring.Http.Converters.Json;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Windows;
using Spring.Rest.Client;
using Spring.Http.Converters.Json;
using Business.Domain.Mobile.Wms;
using Business.Domain.Mobile.Application;

namespace Wms.Mobile.Common
{
    public class GlobalState
    {
        private static string _serviceAddress { get; set; }

        private static string _webServiceAddress { get; set; }
        

        public static RestTemplate MyRestService { get; set; }

        public static Warehouse CurrentWarehouse { get; set; }

        public static User CurrentUser { get; set; }

        public static SmartDeviceService.SmartDevice DeviceService { get; set; }

        static GlobalState()
        {
            _serviceAddress = ToolKit.GetServiceAddress();
            _webServiceAddress = ToolKit.GetWebServiceAddress();

            MyRestService = new RestTemplate(_serviceAddress);
            DeviceService = new Wms.Mobile.SmartDeviceService.SmartDevice(_webServiceAddress);

            NJsonHttpMessageConverter converter = new NJsonHttpMessageConverter();
            converter.SupportedMediaTypes.Add(new MediaType("application", "json"));
            converter.SupportedMediaTypes.Add(new MediaType("application", "octet-stream"));
            MyRestService.MessageConverters.Add(converter);
            MyRestService.ErrorHandler = new ServiceErrorHandler();
        }
    }
}
