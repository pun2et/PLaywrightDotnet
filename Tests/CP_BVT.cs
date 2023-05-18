using Microsoft.Playwright.MSTest;
using Microsoft.Playwright;
using PlaywrightMSTestProject.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using PlaywrightMSTestProject.Pages;
using System.Text.Json.Nodes;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace PlaywrightMSTestProject.Tests
{
    [TestClass]
    public class CP_BVT
    {

        public IPage Browser_Page { get; private set; }
              

        [TestInitialize]
        public async Task SetupTest()
        {
            Browser_Page = await new BrowserConnect().GetContext();
            Console.WriteLine("I am inside SetupTest");
        }

        [DataTestMethod]
        [DataRow("CP_APJ_AU")]
        //[DataRow("CP_EMEA_UK")]
        public async Task CreateSaveReopenSolution_CP(string region)
        {
            var jsondata = ConfigLoader.LoadTestData(region);
            await new CP_NavigatorPage(Browser_Page).NavigateTo(jsondata["Loginurl"].ToString());
            await new CP_LoginPage(Browser_Page).SignInWithUser(jsondata["Username"].ToString(), jsondata["Password"].ToString());
            await new AutoRecoveryPage(Browser_Page).CloseAutoRecoveryIfExit();
            await new CP_YourSolutionsPage(Browser_Page).CreateNewSolution();
            await new CP_BrowseProductPage(Browser_Page).SearchAndAddProduct(jsondata["ProductName"].ToString());
            await new CP_BrowseProductPage(Browser_Page).LoadSolutionConfiguration();
            await new CP_SolutionConfiguratorPage(Browser_Page).SaveSolution();
            await new CP_SolutionConfiguratorPage(Browser_Page).UpdateLoadedProductQuantityAndSave();

        }
    }
}
