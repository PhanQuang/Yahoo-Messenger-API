using System;
using System.Collections.Generic;
using System.Text;
using YahooLib.Messenger.ReqResp;

namespace TestYMLib
{
    class Program
    {
        static void Main(string[] args)
        {
            var case1 = new YahooMessengerGetPARTReqResp
                            {
                                ConsumerKey =
                                    "dj0yJmk9V0Y5bTBNbGFQREw4JmQ9WVdrOVRIbG9jazUwTTJVbWNHbzlOVE13TlRnek9UWXkmcz1jb25zdW1lcnNlY3JldCZ4PWMy",
                                Username = "yahu.tienich",
                                Password = "@Traidatmeo@"
                            };
            case1.ExecuteRequest();

            var case2 = new YahooMessengerExchangePARTForOAuthReqResp()
                            {
                                ConsumerKey = case1.ConsumerKey,
                                ConsummerSecret = "39b1f53648b47225dc37548e45355e1e5bec69cc",
                                Token = case1.RequestToken
                            };
            case2.ExecuteRequest();

            var case3 = new YahooMessengerGetCrumbReqResp()
                            {
                                Authentication = case2.AuthenticationToken
                            };
            case3.ExecuteRequest();
        }
    }
}
