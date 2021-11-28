using System;
using OpenQA.Selenium;

namespace TTA.BlazorApp.Selenium.Tests
{
    public static class SeleniumExtensions
    {
        public static bool ElementExists(this ISearchContext context, By by)
        {
            try
            {
                context.FindElement(by);
                return true;
            }
            catch { return false; }
        }
    }
}