using PlaywrightTests.cofiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightTests.ApiRequests
{
    public class BoardRequest : ApiRequest
    {
        string Route => "boards";
        public BoardRequest(TestsSettings settings) : base(settings)
        {

        }

        public override void MakeRequest(string apiKey, string stringApiToken, string route)
        {
            
        }
    }
}
