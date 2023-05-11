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

        public override void MakeGETBoardRequest(string id)
        {
            var issues = await Request.GetAsync($"/{Route}/" +  id");
            Assert.True(issues.Ok);
        }
    }
}
