using System;
using NUnit.Framework;
using OpenQA.Selenium;

namespace TTA.BlazorApp.Selenium.Tests
{
    public class UserLoginTests : TestBase
    {
        [Order(0)]
        [TestCase("janek@gmail.com", "Janek123!")]
        public void RegisterProperlyUserTest(string email, string password)
        {
            var registerUri = new Uri(BaseUri, "authentication/register");
            Driver.Navigate().GoToUrl(registerUri);
            var emailInput = Wait.Until(d => d.FindElement(By.Id("Input_Email")));
            emailInput.SendKeys(email);
            var passwordInput = Wait.Until( d=>d.FindElement(By.Id("Input_Password")));
            passwordInput.SendKeys(password);
            var passwordConfirmInput = Wait.Until(d => d.FindElement(By.Id("Input_ConfirmPassword")));
            passwordConfirmInput.SendKeys(password);
            Driver.FindElement(By.Id("registerSubmit")).Click();
            Wait.Until(d => d.FindElement(By.XPath("/html/body/div[1]/div/div[2]/div[1]/a[1]")).Text == $"Hello, {email}!");
        }

        [Order(1)]
        [TestCase("janek@gmail.com", "Janek123!")]
        public void LoginForRegisteredUserTest(string email, string password)
        {
            Driver.Navigate().GoToUrl(new Uri(BaseUri, ""));
        }
    }
}