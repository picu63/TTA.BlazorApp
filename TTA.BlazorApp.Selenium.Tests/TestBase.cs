using System;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace TTA.BlazorApp.Selenium.Tests
{
    public abstract class TestBase : IDisposable
    {
        protected virtual IWebDriver Driver { get; set; }
        protected virtual Uri BaseUri { get; set; } = new Uri("https://localhost:5001");
        protected virtual WebDriverWait Wait { get; set;}
        [SetUp]
        public void InitWebDriver()
        {
            Driver = new ChromeDriver();
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
        }

        [TearDown]
        public void Dispose()
        {
            Driver.Close();
            Driver?.Dispose();
        }
    }
}