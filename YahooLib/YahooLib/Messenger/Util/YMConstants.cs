using System;
using System.Collections.Generic;
using System.Text;

namespace YahooLib.Messenger.Util
{
    public class YahooMessengerConstants
    {
        public static int DebugHttpRequestResponse = 1;

        public static string LoginServerUrl = "https://login.yahoo.com";
        public static string ApiLoginServerUrl = "https://api.login.yahoo.com";

        public static string PwTokenGetUrl = LoginServerUrl + "/config/pwtoken_get?";
        public static string PwTokenLoginUrl = LoginServerUrl + "/config/pwtoken_login?";
        public static string PartTokenGetUrl = LoginServerUrl + "/WSLogin/V1/get_auth_token";
        public static string ExchangePartGetUrl = ApiLoginServerUrl + "/oauth/v2/get_token";

        public static string StagingServerUrl = "stage.rest-core.msg.yahoo.com";
        public static string MobileProductionServerUrl = "mobile.rest-core.msg.yahoo.com";
        public static string StagingServerOAuthUrl = "stage-ydn.rest-core.msg.yahoo.com";

        public static string MessengerServerUrl = StagingServerUrl;
        public static string DevUrl = "developer.messenger.yahooapis.com";


        public static string AuthenticationConsumerKey =
                "dj0yJmk9YmVSZkFRQjJNdU9aJmQ9WVdrOVFtOWhjM1prTnpnbWNHbzlOekkzTmpBMU9UWXkmcz1jb25zdW1lcnNlY3JldCZ4PTJl";
        public static string AuthenticationConsumerSecret =
                "d7824ee7ff07b5ab423abf06bc8f24aea4bdb1a6";

        public static string DeleteSuffix = "_method=delete";
        public static string PutSuffix = "_method=put";
        public static string CreateSuffix = "_method=create";


        public static string MessengerApiVersion = "/v1";

        public static string SessionManagementUrl = MessengerApiVersion + "/session";
        public static string SessionManagementKeepaliveUrl =
                MessengerApiVersion + "/session/keepalive";
        public static string PresenceManagementUrl =
                MessengerApiVersion + "/presence";
        public static string ContactListManagementUrl =
                MessengerApiVersion + "/contacts";
        public static string ContactManagementUrl =
                MessengerApiVersion + "/contact";
        public static string MessageManagementUrl =
                MessengerApiVersion + "/message";
        public static string NotificationManagementUrl =
                MessengerApiVersion + "/notifications";
    }
}
