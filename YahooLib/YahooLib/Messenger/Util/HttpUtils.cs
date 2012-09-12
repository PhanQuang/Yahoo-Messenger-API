using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using YahooLib.Messenger.Exception;

namespace YahooLib.Messenger.Util
{
    public class HttpUtils
    {
        public static string SendHttpGet(WebRequest request)
        {
            return SendHttpGet(request, null);
        }

        public static string SendHttpGet(WebRequest request, YahooMessengerAuthentication authentication)
        {
            request.Method = "GET";

            if(authentication!=null)
            {
                if(!authentication.IsUsingOAuth)
                    request.Headers.Add("Cookie",authentication.Cookie);
                else request.Headers.Add("Authorization", "OAuth");
            }

            using(var response = (HttpWebResponse)request.GetResponse())
            {
                if(response == null) throw new NullReferenceException();

                var respCode = response.StatusCode;

                if (respCode != HttpStatusCode.OK) 
                    throw new HttpException(HttpException.HTTP_OK_NOT_RECEIVED, respCode.ToString());

                var dataStream = response.GetResponseStream();

                if (dataStream == null) throw new NullReferenceException();
                var reader = new StreamReader(dataStream);

                // Read the content.
                var responseFromServer = new StringBuilder("");
                responseFromServer.Append(reader.ReadToEnd());
                reader.Close();
                dataStream.Close();
                response.Close();

                return responseFromServer.ToString();
            }
        }

        public static string SendHttpPost(WebRequest request, YahooMessengerAuthentication authentication, string content)
        {
            request.Method = "POST";
            byte[] byteArray = Encoding.UTF8.GetBytes(content);
            request.ContentLength = byteArray.Length;
            var dataStream = request.GetRequestStream();
            // Write the data to the request stream.
            dataStream.Write(byteArray, 0, byteArray.Length);
            // Close the Stream object.
            dataStream.Close();
            using(var response = (HttpWebResponse) request.GetResponse())
            {
                if (response == null) throw new NullReferenceException();

                var respCode = response.StatusCode;

                if (respCode != HttpStatusCode.OK)
                    throw new HttpException(HttpException.HTTP_OK_NOT_RECEIVED, respCode.ToString());

                dataStream = response.GetResponseStream();
                if (dataStream == null) throw new NullReferenceException();
                var reader = new StreamReader(dataStream);

                var responseFromServer = new StringBuilder("");
                responseFromServer.Append(reader.ReadToEnd());
                reader.Close();
                dataStream.Close();
                response.Close();

                return responseFromServer.ToString();
            }
        }
    }
}
