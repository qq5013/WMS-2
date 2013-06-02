using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Framework.SmartDevice.Xml;
using Framework.SmartDevice.Device;
using Business.Domain.Mobile.Wms;

namespace Wms.Mobile.Common
{
    public class ToolKit
    {
        public static string GetServiceAddress()
        {
            string path = System.IO.Path.Combine(DeviceHelper.ApplicationPath, @"WCFService.config");
            string address = XmlHelper.ReadXmlConfig(path, "WCFService", "Address");

            return address;
        }

        public static string GetWebServiceAddress()
        {
            string path = System.IO.Path.Combine(DeviceHelper.ApplicationPath, @"WCFService.config");
            string address = XmlHelper.ReadXmlConfig(path, "WebService", "Address");

            return address;
        }

        public static bool IsLocationBarcode(string barcode)
        {

            return true;

            if (barcode.Substring(0, 1) == "R")
                return true;

            return false;
        }

        public static bool IsContainerBarcode(string barcode)
        {
            return true;

            if (barcode.Substring(0, 1) == "C")
                return true;

            return false;
        }

        public static bool IsSkuBarcode(string barcode)
        {
            return true;

            if (barcode.Substring(0, 1) == "I")
                return true;

            return false;
        }

        public static DateTime GetServerTime()
        {
            try
            {
                string uri = string.Format("Server/GetDataTime");
                var datetime = GlobalState.MyRestService.GetForObject<string>(uri);
                return DateTime.Parse(datetime);
            }
            catch (Exception ex)
            {
                //
            }

            return DateTime.MinValue;
        }

        public static LocationInfo GetLocation(string barcode)
        {
            try
            {
                string uri = string.Format("Warehouse/{0}/Location/{1}", GlobalState.CurrentWarehouse.WarehouseCode, barcode);
                return GlobalState.MyRestService.GetForObject<LocationInfo>(uri);
            }
            catch (Exception ex)
            {
                //
            }

            return null;
        }


        public static ContainerInfo GetContainer(string barcode)
        {
            try
            {
                string uri = string.Format("Warehouse/{0}/Container/{1}", GlobalState.CurrentWarehouse.WarehouseCode, barcode);
                return GlobalState.MyRestService.GetForObject<ContainerInfo>(uri);
            }
            catch (Exception ex)
            {
                //
            }

            return null;
        }
        
    }
}
