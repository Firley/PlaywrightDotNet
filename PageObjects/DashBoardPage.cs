using Microsoft.Playwright;

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