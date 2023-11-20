using Microsoft.Playwright;

namespace PlaywrightTests.PageObjects
{
    public class LoginPage : BasePage
    {

        ILocator EmailInput => Page.GetByPlaceholder("Podaj adres e-mail");

        ILocator ContinueButton => Page.GetByRole(AriaRole.Button, new() { Name = "Kontynuuj" }).First;

        ILocator PasswordInput => Page.GetByPlaceholder("Wprowadź hasło");

        ILocator LoginButton => Page.GetByRole(AriaRole.Button, new() { Name = "Zaloguj się" });

        public LoginPage(IPage page) : base(page) { }

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
