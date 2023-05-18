using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightMSTestProject.Pages
{
    public class AutoRecoveryPage
    {
        private IPage _Page { get; set; }

        public AutoRecoveryPage(IPage page)
        {
            _Page = page;
        }

        public async Task CloseAutoRecoveryIfExit()
        {
            
            try
            {                
                await _Page.Locator("//*[@id=\"exampleModal\"]/div//button[@aria-label=\"close dialog\"]").ClickAsync();
                Console.WriteLine("Clicked Auto revocery");
            }
            catch (Exception)
            {
                 Console.WriteLine("Auto recovery not found");
            }
            
        }
    }
}
