using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightMSTestProject.Pages
{
   
    public class CP_NavigatorPage
    {
         public IPage _Page { get; private set; }

        public CP_NavigatorPage(IPage page)
        { 
            _Page = page;
        }

        public async Task NavigateTo(string url)
        {
            await _Page.GotoAsync(url);
        }
    }
}
