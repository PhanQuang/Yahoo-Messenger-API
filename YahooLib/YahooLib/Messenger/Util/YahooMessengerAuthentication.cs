using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace YahooLib.Messenger.Util
{
    public class YahooMessengerAuthentication
    {
        public string Cookie { get; set; }
        public bool IsUsingOAuth { get; set; }

        public string Realm { get { return "yahoo.com"; } }
        public string OauthConsumerKey { get; set; }
        public string OauthNonce { get { return GenerateNonce(); } }
        public string OauthSignatureMethod { get { return "PLAINTEXT"; } }
        public string OauthTimestamp { get { return GenerateTimeStamp(); } }
        public string OauthToken { get; set; }
        public string OauthVersion { get { return "1.0"; } }
        public string OauthSignature { get; set; }

        public YahooMessengerAuthentication() { IsUsingOAuth = true; }

        public YahooMessengerAuthentication(string authenticationCookie)
        {
            Cookie = authenticationCookie;
            IsUsingOAuth = false;
        }

        public YahooMessengerAuthentication(string consumerKey,
            string token, string signature)
        {
            OauthConsumerKey = consumerKey;
            OauthToken = token;
            OauthSignature = signature;

            IsUsingOAuth = true;
        }

        public string GetOAuthParameters()
        {

            if (!IsUsingOAuth)
            {
                return "";
            }

            long timeStamp = DateTime.UtcNow.Ticks/1000;

            return
              "realm=" + Realm +
              "&oauth_consumer_key=" + OauthConsumerKey +
              "&oauth_nonce=" + OauthNonce +
              "&oauth_signature_method=" + OauthSignatureMethod +
              "&oauth_timestamp=" + timeStamp +
              "&oauth_token=" + HttpUtility.UrlEncode(OauthToken) +
              "&oauth_version=" + OauthVersion +
              "&oauth_signature=" + OauthSignature;
        }

        private string GenerateTimeStamp()
        {
            // Default implementation of UNIX time of the current UTC time
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds).ToString();
        }

        public string GenerateNonce()
        {
            return new Random().Next(123400, 9999999).ToString();
        }
    }
}
