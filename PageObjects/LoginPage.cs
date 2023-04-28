using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightTests.PageObjects
{
    public class LoginPage : BasePage
    {

        ILocator EmailInput => page.GetByPlaceholder("Podaj adres e-mail");
        ILocator ContinueButton => page.GetByRole(AriaRole.Button, new() { Name = "Kontynuuj" }).First;
        ILocator PasswordInput => page.GetByPlaceholder("Wprowadź hasło");
        ILocator LoginButton => page.GetByRole(AriaRole.Button, new() { Name = "Zaloguj się" });
        public LoginPage(IPage _page) : base(_page) { }

        public async Task FillEmailAdress(string email)
        {
          await EmailInput.FillAsync(email);
        }
        public async Task ClickContinueButton()
        {
          await ContinueButton.ClickAsync();
        }

        public async Task FillPassword(string password)
        {
         await PasswordInput.FillAsync(password);
        }

        public async Task ClickLoginButton()
        {
           await LoginButton.ClickAsync();
        }
    }
}
