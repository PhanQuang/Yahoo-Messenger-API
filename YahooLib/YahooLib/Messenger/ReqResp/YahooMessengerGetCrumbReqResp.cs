using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Newtonsoft.Json.Linq;
using YahooLib.Messenger.Exception;
using YahooLib.Messenger.Util;

namespace YahooLib.Messenger.ReqResp
{
    public class YahooMessengerGetCrumbReqResp : YahooMessengerBaseReqResp
    {
        //  Response parameters
        public int LoggedIn { get; set; }

        public override void ExecuteRequest()
        {
            //  Create the HTTP URL
            var uri = "http://" + RequestServer + //"developer.messenger.yahooapis.com" +
                            YahooMessengerConstants.SessionManagementUrl
                            + "?" + Authentication.GetOAuthParameters();

            WebRequest request = WebRequest.Create(uri);
            request.ContentType = "application/json; charset=utf-8";

            var responseStr = HttpUtils.SendHttpGet(request, Authentication);
            JObject result = JObject.Parse(responseStr);

            if (result == null) 
                throw new MessengerException(MessengerException.UNKNOWN_SERVER_ERROR, "Unknown server error");

            UnserializeJSONResponseParameters(result);
        }

        private void UnserializeJSONResponseParameters(JObject o)
        {
            Crumb = (string) o["crumb"];
            LoggedIn = (int) o["loggedIn"];
        }
    }
}
