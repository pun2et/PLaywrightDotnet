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
    public class UnitTest2
    {
        public IPage PageP { get; private set; }
        public PlaywrightTest Validator { get; private set; }

        [TestInitialize]
        public async Task SetupTest()
        {      
            PageP = await new BrowserConnect().GetContext();
            Console.WriteLine("I am inside SetupTest");
            Validator = new PlaywrightTest();
        }

        [TestMethod]
        public async Task TestMethod1()
        {

            await PageP.GotoAsync("https://playwright.dev");
            var tittle = await PageP.TitleAsync();

            // Expect a title "to contain" a substring.
            Assert.IsTrue(tittle.Contains("Playwright"));
            
            //    // create a locator
            //    var getStarted = PageP.GetByRole(AriaRole.Link, new() { Name = "Get started" });

            //    // Expect an attribute "to be strictly equal" to the value.
            //    await getStarted.ToHaveAttributeAsync("href", "/docs/intro");

            //    // Click the get started link.
            //    await getStarted.ClickAsync();
            
            // Expects the URL to contain intro.
            await Validator.Expect(PageP).ToHaveURLAsync(new Regex(".*intro"));
        }


    }
}