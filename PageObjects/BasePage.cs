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
        public readonly IPage page;
        public BasePage(IPage _page)
        {
            this.page = _page;
        }
        public async Task CloseAd()
        {
        }
    }
}
