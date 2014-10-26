using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JustRunnerChat.Repositories
{
    public class PubnubRepository
    {
        public static void MakeConnection(string channelName)
        {
            PubnubAPI pubnub = new PubnubAPI(
            "pub-c-5093de55-5a92-4b74-9522-d10c4c129dcc",
            "sub-c-20837058-05f4-11e3-991c-02ee2ddab7fe",
            "sec-c-NWJjODE5NGYtNDE1Mi00OWRiLWEwMmMtMjE3NDZlMTk3ODk3", true);
        }
    }
}