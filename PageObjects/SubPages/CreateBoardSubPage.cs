using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightTests.PageObjects.Dashboard
{
    public class CreateBoardSubPage : BasePage
    {
        public ILocator BoardSubpageTitleHeading => Page.GetByRole(AriaRole.Heading, new() { Name = "Utwórz Tablicę" });

        public ILocator BackgroundImagePreview => Page.Locator("img");
        public ILocator BackgroundPickerLabel => Page.GetByText("Tło");
        public ILocator DefaultBackgroundImages => Page.GetByRole(AriaRole.Button, new() { Name = "Obraz niestandardowy" });
        public ILocator BackgroundColorList => Page.Locator("#background-picker").GetByRole(AriaRole.List).Nth(1).GetByRole(AriaRole.Button);


        public ILocator TitleInputLabel => Page.GetByText("Tytuł tablicy*");
        public ILocator TitleInput => Page.GetByTestId("create-board-title-input");

        public ILocator CreateBoardSubmitButton => Page.GetByTestId("create-board-submit-button");


        public CreateBoardSubPage(IPage page) : base(page)
        {
        }

        public async Task InsertTitle(string title)
        {
            await TitleInput.FillAsync(title);
        }

        public async Task SelectNonStandardColor(int number = 1)
        {
            await DefaultBackgroundImages.Nth(number).ClickAsync();
        }

        public async Task ClickSubmitButton()
        {
            await CreateBoardSubmitButton.ClickAsync();
        }
    }
}
