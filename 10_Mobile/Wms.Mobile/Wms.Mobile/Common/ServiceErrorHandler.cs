using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Xml.Linq;
using Spring.Http;
using Spring.Http.Client;
using Spring.Rest.Client;
using System.Xml;

namespace Wms.Mobile.Common
{
    public class ServiceErrorHandler : IResponseErrorHandler
    {
        public bool HasError(Uri requestUri, HttpMethod requestMethod, IClientHttpResponse response)
        {
            if (response.StatusCode == HttpStatusCode.OK)
                return false;

            return true;
        }

        public void HandleError(Uri requestUri, HttpMethod requestMethod, IClientHttpResponse response)
        {
            // This method should not be called because HasError returns false.
            Stream stream = ((WebClientHttpResponse)response).HttpWebResponse.GetResponseStream();
            stream.Position = 0;
            StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8);
            string xmlResult = reader.ReadToEnd();
            XElement rootElement = XElement.Parse(xmlResult);
            XElement detailElement = rootElement
            .Descendants()
            .First(el => el.Name.LocalName == "Detail");

            XElement serviceError = detailElement
            .Descendants()
            .First(el => el.Name.LocalName == "ServiceError");

            ServiceError error = new ServiceError("SERVICE_ERROR","远程服务发生未知异常。", "");
            try
            {
                string errorCode = ((XElement)(serviceError.FirstNode)).Value;
                string errorMessage = ((XElement)(serviceError.FirstNode.NextNode)).Value;
                string stackTrace = ((XElement)(serviceError.FirstNode.NextNode.NextNode)).Value;

                error.ErrorCode = errorCode;
                error.ErrorMessage = errorMessage;
                error.StackTrace = stackTrace;
            }
            catch (Exception ex)
            {
                //
            }

            throw new ServiceException((ServiceError)error);
        }
    }
}
