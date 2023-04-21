using Microsoft.Playwright.NUnit;
using PlaywrightTests.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightTests.Tests
{
    [TestFixture]
    public class TabsTests : BaseTest
    {


        [Test]
        public async Task TabsTest1()
        {
           var mainPage = new MainPage(Page);
          await mainPage.NavigateToExerciseTabsAsync();
        }
    }
}
