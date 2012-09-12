using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Web;
using YahooLib.Messenger.Exception;
using YahooLib.Messenger.Util;

namespace YahooLib.Messenger.ReqResp
{
    public class YahooMessengerExchangePARTForOAuthReqResp
    {
        public string ConsumerKey { get; set; }
        public string ConsummerSecret { get; set; }
        public string Signature
        {
            get { return HttpUtility.UrlEncode(ConsummerSecret + "&"); }
        }
        public string Verifier { get; set; }
        public string Version { get { return "1.0"; } }
        public string Token { get; set; }
        public string TokenSecret { get; set; }

        public YahooMessengerAuthentication AuthenticationToken { get; set; }

        public void ExecuteRequest()
        {
            //  Verify mandatory parameters
            if (ConsumerKey == null)
                throw new MessengerException(MessengerException.NO_CONSUMER_KEY_GIVEN, "No consumer key given");

            AuthenticationToken = new YahooMessengerAuthentication()
                                      {
                                          OauthConsumerKey = ConsumerKey
                                      };

            //  Create the HTTP URL
            string url = YahooMessengerConstants.ExchangePartGetUrl + "?" +
                    "&oauth_consumer_key=" + ConsumerKey +
                    "&oauth_signature_method=" + AuthenticationToken.OauthSignatureMethod +
                    "&oauth_nonce=" + AuthenticationToken.OauthNonce +
                    "&oauth_timestamp=" + AuthenticationToken.OauthTimestamp +
                    "&oauth_signature=" + Signature +
                    "&oauth_version=" + AuthenticationToken.OauthVersion +
                    "&oauth_token=" + Token;

            //  Perform the actual call to the server
            WebRequest request = WebRequest.Create(url);
            var resultStr = HttpUtils.SendHttpGet(request);
            var tmp = HttpUtility.ParseQueryString(resultStr);
            Token = tmp["oauth_token"];
            TokenSecret = tmp["oauth_token_secret"];

            AuthenticationToken.OauthToken = Token;
            AuthenticationToken.OauthSignature = ConsummerSecret + "%26" + TokenSecret;
        }
    }
}
