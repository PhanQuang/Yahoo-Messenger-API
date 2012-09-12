using System;
using System.Collections.Generic;
using System.Text;

namespace YahooLib.Messenger.Exception
{
    public class MessengerException : SystemException
    {
        public static int UNKNOWN_USERNAME = 101;
        public static int INCORRECT_PASSWORD = 102;
        public static int INVALID_TOKEN = 103;
        public static int NO_USERNAME_GIVEN = 104;
        public static int ALREADY_LOGGED_IN = 105;
        public static int NO_PASSWORD_GIVEN = 106;
        public static int NO_CONSUMER_KEY_GIVEN = 107;

        public static int NO_CRUMB_GIVEN = 110;
        public static int NO_SESSION_ID_GIVEN = 111;

        public static int NO_NETWORK_GIVEN = 120;
        public static int NO_TARGET_ID_GIVEN = 121;
        public static int NO_CONTACT_ID_GIVEN = 122;

        public static int NO_SEQUENCE_GIVEN = 130;

        public static int JSON_PARSER_EXCEPTION = 990;

        public static int UNKNOWN_SERVER_ERROR = 998;
        public static int UNKNOWN_ERROR = 999;

        public int Code { get; set; }

        public MessengerException(int code) : base()
        {
            Code = code;
        }

        public MessengerException(int code, string mess) : base(mess)
        {
            Code = code;
        }

        public MessengerException(string mess) : base(mess)
        {
            Code = UNKNOWN_ERROR;
        }
    }
}
