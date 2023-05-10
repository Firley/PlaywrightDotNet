using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightTests.PageObjects.Dashboard
{
    public class CreationOfTableSubPage : BasePage
    {
        ILocator TitleInput => Page.GetByTestId("create-board-title-input");
        ILocator BackgroundColorList => Page.GetByRole(AriaRole.Button, new() { Name = "🌊" });
        ILocator NonStandardBackgroundColorList => Page.GetByRole(AriaRole.Button, new() { Name = "Obraz niestandardowy" });

        public CreationOfTableSubPage(IPage page) : base(page)
        {
        }

        public async Task InsertTitle(string title)
        {
            await TitleInput.FillAsync(title);
        }

        public async Task SelectNonStandardColor(int number = 1)
        {
            await NonStandardBackgroundColorList.Nth(number).ClickAsync();
        }
    }
}
