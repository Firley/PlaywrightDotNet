using Microsoft.Playwright;
using PlaywrightTests.PageObjects;
using PlaywrightTests.PageObjects.Dashboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightTests.Tests
{
    internal class CreateNewTableTests : BaseTest
    {
        public string TableName { get; set; } = "Table2";
        [Test]
        public async Task CreateNewTable()
        {
            await Page.GotoAsync(settings.Link);
            DashBoardPage dashBoard = new DashBoardPage(Page);
            dashBoard.OpenCreateNewTableFormAsync().Wait();
            CreationOfTableSubPage createTileForm = new CreationOfTableSubPage(Page);
            await Expect(createTileForm.TitleInput).ToBeFocusedAsync();
            await createTileForm.InsertTitle(TableName);

        }
    }
}
