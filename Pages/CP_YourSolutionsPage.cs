using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightMSTestProject.Pages
{
    public class CP_YourSolutionsPage
    {
        private IPage _Page { get; set; }

        public CP_YourSolutionsPage(IPage page)
        {
            _Page = page;
        }                

        public async Task CreateNewSolution(string endCustomertype = "Medium Business")
        {
            await _Page.WaitForSelectorAsync(selector: "#create_new_solution");
            await _Page.ClickAsync(selector: "#create_new_solution");

            await _Page.WaitForSelectorAsync(selector: "#solutionName");
            await _Page.FillAsync(selector: "#solutionName", "AutomationSolution");

            //await _Page.WaitForSelectorAsync(selector: "#endUserCustomerTypeSelectedDdl");
            await _Page.SelectOptionAsync(selector: "#endUserCustomerTypeSelectedDdl", endCustomertype);

            await _Page.ClickAsync(selector: "#btnNewSolutionCreate");
        }
      
    }
}
