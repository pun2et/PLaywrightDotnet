using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace PlaywrightMSTestProject.Pages
{
    public class CP_LoginPage
    {
        private IPage _Page { get; set; }
     
        public CP_LoginPage(IPage page)
        {
            _Page = page;    
            
        }

        private async Task EnterUserName(string username) => await _Page.FillAsync(selector: "#SignInModel_EmailAddress", username);

        private async Task EnterPassword(string password) => await _Page.FillAsync(selector: "#userPwd_UserInputSecret", password);

        private async Task ClickSignIn() => await _Page.ClickAsync(selector: "#btnSignIn");
        public async Task SignInWithUser(string username, string password)
        {
            await EnterUserName(username);
            await EnterPassword(password);
            await ClickSignIn();
            await _Page.WaitForURLAsync("**/your-solutions/**");
          
        }

        
    }
}
