using Microsoft.Playwright;
using Microsoft.Playwright.MSTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightMSTestProject.Pages
{
    public class CP_BrowseProductPage
    {
        private IPage _Page { get;  set; }
        private PlaywrightTest Validator { get; set; }
        public CP_BrowseProductPage(IPage page)
        {
            _Page = page;
        }

        public async Task SearchAndAddProduct(string product)
        {
            await _Page.FillAsync(selector: "#txtPDSearch", product);
            await _Page.ClickAsync("//button[text()=' Search ']");
            await _Page.WaitForLoadStateAsync();
            await ClickFirstSearchItem();
        }

        private async Task ClickFirstSearchItem()
        {
            await _Page.ClickAsync("(//span[@class='spTooltipAddProduct']//button)[1]");
            await _Page.WaitForLoadStateAsync();
            Console.WriteLine("Product Added");
        }

        public async Task LoadSolutionConfiguration()
        {
            await _Page.ClickAsync(selector: "#ph-configure-solution-btn");
            //await _Page.WaitForLoadStateAsync();
            await _Page.WaitForURLAsync("**/build-solution**",new PageWaitForURLOptions() { Timeout = 100000});
        }
    }
}
