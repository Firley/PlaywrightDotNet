using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightTests.PageObjects
{
    public abstract class BasePage
    {
        public readonly IPage _page;

        public BasePage(IPage page)
        {
            _page = page;
        }

    }
}
