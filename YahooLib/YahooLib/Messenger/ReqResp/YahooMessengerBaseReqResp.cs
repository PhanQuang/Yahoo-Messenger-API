using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;
using YahooLib.Messenger.Util;

namespace YahooLib.Messenger.ReqResp
{
    public class YahooMessengerBaseReqResp
    {
        public string RequestServer
        {
            get { return YahooMessengerConstants.DevUrl; }
        }
        public YahooMessengerAuthentication Authentication { get; set; }

        protected string Crumb;
        protected string SessionId;

        public virtual void ExecuteRequest(){}

        public JObject SerializeJsonRequestParameters()
        {
            return null;
        }

        public void UnserializeJsonResponseParameters(JObject o){}
    }
}
