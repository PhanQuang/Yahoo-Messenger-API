using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Web;
using NUnit.Framework;
using YahooLib.Messenger.Exception;
using YahooLib.Messenger.Util;

namespace YahooLib.Messenger.ReqResp
{
    public class YahooMessengerGetPARTReqResp
    {
        //  Request parameters
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConsumerKey { get; set; }

        //  Response parameters
        public string RequestToken { get; set; }

        [Test]
        public void ExecuteRequest()
        {
            //  Verify mandatory parameters
            if (Username == null)
                throw new MessengerException(MessengerException.NO_USERNAME_GIVEN, "No username given");
            if (Password == null)
                throw new MessengerException(MessengerException.NO_PASSWORD_GIVEN, "No password given");
            if (ConsumerKey == null)
                throw new MessengerException(MessengerException.NO_CONSUMER_KEY_GIVEN, "No consumer key given");

            //  Create the HTTP URL
            var url = YahooMessengerConstants.PartTokenGetUrl + "?" +
                    "&login=" + Username + "&passwd=" + Password +
                    "&oauth_consumer_key=" + ConsumerKey;

            //  Perform the actual call to the server
            var request = WebRequest.Create(url);
            var resultstring = HttpUtils.SendHttpGet(request, null);
            var queryStr = HttpUtility.ParseQueryString(resultstring);
            RequestToken = queryStr["RequestToken"];
        }
    }
}