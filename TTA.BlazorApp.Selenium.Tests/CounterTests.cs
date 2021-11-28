using System;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace TTA.BlazorApp.Selenium.Tests
{
    [TestFixture]
    public class CounterTests : TestBase
    {
        [Test]
        public void VerifyCounterOnInit()
        {
            Driver.Navigate().GoToUrl(new Uri(BaseUri, "counter"));
            var innerText = Wait.Until(d => d.FindElement(By.XPath("/html/body/div[1]/div/div[2]/div[2]/p"))).Text;
            Assert.AreEqual("Current count: 0", innerText);
        }

        [Test]
        public void VerifyCounterClick()
        {
            Driver.Navigate().GoToUrl(new Uri(BaseUri, "counter"));
            Wait.Until(d => d.FindElement(By.Id("counterBtn"))).Click();
            var innerText = Driver.FindElement(By.CssSelector(".content.px-4")).FindElement(By.TagName("p")).Text;
            Assert.AreEqual("Current count: 1", innerText);
        }
    }
}