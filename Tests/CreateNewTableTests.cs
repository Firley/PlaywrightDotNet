using Microsoft.Playwright;
using PlaywrightTests.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightTests.Tests
{
    internal class CreateNewTableTests : BaseTest
    {
        [Test]
        public async Task CreateNewTable()
        {
            await Page.GotoAsync(settings.Link);
            DashBoardPage dashBoard = new DashBoardPage(Page);
            dashBoard.OpenCreateNewTableFormAsync().Wait();
        }
    }
}
