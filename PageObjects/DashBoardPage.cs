using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightTests.PageObjects
{
    public class DashBoardPage : BasePage
    {
        public ILocator CreateNewTableTile => Page.GetByTestId("create-board-tile");

        public DashBoardPage(IPage page) : base(page) { }

        public async Task OpenCreateNewTableFormAsync()
        {
            await CreateNewTableTile.ClickAsync();
        }
    }
}