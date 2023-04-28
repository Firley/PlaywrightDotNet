using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightTests.PageObjects
{
    public class DashBoardPage
    {
        public ILocator CreateNewTableTile => Page.GetByTestId("create-board-tile");

        public IPage Page { get; }

        public DashBoardPage(IPage page)
        {
            Page = page;
        }


        public async Task OpenCreateNewTableFormAsync() 
        {
         await CreateNewTableTile.ClickAsync();
        }
    }
}
