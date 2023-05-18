using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Microsoft.Playwright.TestAdapter;
using Microsoft.Playwright.MSTest;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using PlaywrightMSTestProject.Helpers;

namespace PlaywrightMSTestProject.Tests
{
    [TestClass]
    public class UnitTest1 : PageTest
    {
        public IPage PageP { get; private set; }
        

        [TestInitialize]
        public async Task SetupTest()
        {      
            PageP = await new BrowserConnect().GetContext();
            Console.WriteLine("I am inside SetupTest");
        }

        [TestMethod]
        public async Task TestMethod2()
        {
            //using var playwright = await Playwright.CreateAsync();
            //var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions() { Headless = false });
            //var browserContext = await browser.NewContextAsync();
            //var llpage = await browserContext.NewPageAsync();
            //PageP = llpage;
            await Page.GotoAsync("https://playwright.dev");
            await Page.TitleAsync();

            // Expect a title "to contain" a substring.
            await Expect(PageP).ToHaveTitleAsync(new Regex("Playwright"));

            // create a locator
            var getStarted = PageP.GetByRole(AriaRole.Link, new() { Name = "Get started" });

            // Expect an attribute "to be strictly equal" to the value.
            await Expect(getStarted).ToHaveAttributeAsync("href", "/docs/intro");

            // Click the get started link.
            await getStarted.ClickAsync();

            // Expects the URL to contain intro.
            await Expect(PageP).ToHaveURLAsync(new Regex(".*intro"));
        }
    }
}