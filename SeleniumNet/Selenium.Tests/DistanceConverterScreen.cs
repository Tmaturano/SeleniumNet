using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Selenium.Utils;
using System;

namespace Selenium.Tests
{
    public class DistanceConverterScreen
    {
        private readonly Browser _browser; //type of browser
        private IWebDriver _driver; //bridge with the browser that will be used for testing
        private readonly IConfiguration _configuration;

        public DistanceConverterScreen(IConfiguration configuration, Browser browser)
        {
            _browser = browser;
            _configuration = configuration;

            string driverPath = null;

            switch (_browser)
            {
                case Browser.Firefox:
                    driverPath = _configuration.GetSection("Selenium:FirefoxDriverPath").Value;
                    break;
                case Browser.Chrome:
                    driverPath = _configuration.GetSection("Selenium:ChromeDriverPath").Value;
                    break;
                case Browser.IE:
                    driverPath = _configuration.GetSection("Selenium:IEDriverPath").Value;
                    break;
                case Browser.Edge:
                    driverPath = _configuration.GetSection("Selenium:EdgeDriverPath").Value;
                    break;
            }

            _driver = WebDriveFactory.GetWebDriver(_browser, driverPath);
        }

        public void LoadPage()
        {
            _driver.LoadPage(TimeSpan.FromSeconds(5),
                _configuration.GetSection("Selenium:UrlDistanceConverterScreen").Value);                
        }

        public void FillDistanceMiles(double value)
        {            
            _driver.SetText(By.Name("DistanceInMiles"), value.ToString());
        }

        public void ConvertMilesToKilometers()
        {            
            _driver.Submit(By.Id("btnConvert"));
            
            //time that will be waited
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until(d => d.FindElement(By.Id("DistanceKm")) != null); 
        }

        public double GetDistanceKm()
        {
            return Convert.ToDouble(_driver.GetText(By.Id("DistanceKm")));
        }

        public void Close()
        {
            _driver.Quit();
            _driver = null;
        }
    }
}