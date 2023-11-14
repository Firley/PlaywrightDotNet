using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightTests.PageObjects
{
    public class BasePage
    {
        public IPage Page { get; }

        public BasePage(IPage page)
        {
            Page = page;
        }
    }
}
