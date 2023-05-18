using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightMSTestProject.Pages
{
    public class CP_SolutionConfiguratorPage
    {
        private IPage _Page { get; set; }

        public CP_SolutionConfiguratorPage(IPage page)
        {
            _Page = page;
        }

        public async Task SaveSolution()
        {
            await _Page.ClickAsync("//div[@id='separate-save-SaveAs']//*[@id='composer-header-solutionbutton-save-link']");
        }

        public async Task SaveAfterConfigChange()
        {
            await _Page.ClickAsync("//div[@class='inlineBlockElement']//button[@title='Save']");
        }

        /// <summary>
        /// updates the quantity of first ordercode
        /// </summary>
        /// <returns></returns>
        public async Task UpdateLoadedProductQuantity()
        {
            await _Page.ClickAsync("//button[text()='+']");
        }

        public async Task ReadLoadedProductQty()
        {
            
            
        }
        public async Task UpdateLoadedProductQuantityAndSave()
        {
            var qtytextbox = await _Page.InputValueAsync("//input[contains(@class,'spinbox-input spinbox-input-vert')]");
            Console.WriteLine("Product Qty is - " + qtytextbox);

            await UpdateLoadedProductQuantity();
            await SaveAfterConfigChange();

            var aftqtytextbox = await _Page.InputValueAsync("//input[contains(@class,'spinbox-input spinbox-input-vert')]");
            Console.WriteLine("Product Qty is - " + aftqtytextbox);
        }
    }
}
