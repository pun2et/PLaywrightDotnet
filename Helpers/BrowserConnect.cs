using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Microsoft.Playwright.MSTest;
using Newtonsoft.Json.Linq;

namespace PlaywrightMSTestProject.Helpers
{
    public class BrowserConnect
    {
        public IPage Page { get; private set; } = null!;
        public async Task<IPage> GetContext()
        {

            if (bool.Parse(ConfigLoader.LoadConfig()["MoonExecution"].ToString()))
            {
                var playwrith = await Playwright.CreateAsync();
                var browser = await playwrith.Chromium.ConnectAsync(ConfigLoader.LoadConfig()["MoonWSEndPoint"].ToString());
                var browserContext = await browser.NewContextAsync();
                Page = await browserContext.NewPageAsync();
                
                return Page;

            }
            else
            {
                var playwrith = await Playwright.CreateAsync();
                var browser = await playwrith.Chromium.LaunchAsync(new BrowserTypeLaunchOptions() { Headless = false});
                var browserContext = await browser.NewContextAsync(new BrowserNewContextOptions() { ScreenSize = new ScreenSize() { } });
                var page = await browserContext.NewPageAsync();
                return page;
            }
        }

    }
}
