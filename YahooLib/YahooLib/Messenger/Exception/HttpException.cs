using System;
using System.Collections.Generic;
using System.Text;

namespace YahooLib.Messenger.Exception
{
    public class HttpException : MessengerException
    {
        public static int HTTP_OK_NOT_RECEIVED = 100;
        public static int NO_AUTHENTICATION_GIVEN = 101;

        public int _httpCode;

        public HttpException(int code) : base(code)
        {
        }

        public HttpException(string mess) : base(mess)
        {
        }

        public HttpException(int code, string mess) : base(code, mess)
        {
        }
    }
}
