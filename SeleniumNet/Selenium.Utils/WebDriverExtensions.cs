﻿using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using System;

namespace Selenium.Utils
{
    public static class WebDriverExtensions
    {
        public static void LoadPage(this IWebDriver webDriver, TimeSpan timeToWait, string url)
        {
            webDriver.Manage().Timeouts().PageLoad = timeToWait;
            webDriver.Navigate().GoToUrl(url);
        }

        public static string GetText(this IWebDriver webDriver, By by)
        {
            var webElement = webDriver.FindElement(by);
            return webElement.Text;
        }

        public static void SetText(this IWebDriver webDriver, By by, string text)
        {            
            //Basic representation of an html element in selenium with IWebElement
            var webElement = webDriver.FindElement(by);
            webElement.SendKeys(text);
        }

        public static void Submit(this IWebDriver webDriver, By by)
        {
            var webElement = webDriver.FindElement(by);
            if (webDriver is InternetExplorerDriver)
            {                
                webElement.SendKeys(Keys.Enter);
            }
            else
            {
                webElement.Submit();
            }
        }
    }
}