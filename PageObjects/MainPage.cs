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
    public class MainPage
    {

        ILocator LoginButton => Page.GetByTestId("bignav").GetByRole(AriaRole.Link, new() { Name = "Log in" });

        public IPage Page { get; }

        public MainPage(IPage page)
        {
            Page = page;
        }



        public async Task OpenLoginPagesAsync()
        {
            await LoginButton.ClickAsync();
        }



    }
}
