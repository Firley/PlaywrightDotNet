using Microsoft.Extensions.Configuration;
using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PlaywrightTests.PageObjects
{
    public class MainPage : BasePage
    {

        ILocator TabsButton => page.GetByRole(AriaRole.Link, new() { Name = "Tabs" });
        public MainPage(IPage page) : base(page) { }



    public async Task NavigateToExerciseTabsAsync()
        {
          await TabsButton.ClickAsync();
        }



    }
}
