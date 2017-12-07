using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace Selenium.Utils
{
    public static class WebDriveFactory
    {
        /// <summary>        
        /// Each specific browser has an implementation of this interface
        /// Selenium provides a driver that make a bridge between the browser and the project that's being executed                
        /// No caso do IE, edge, chrome, temos que baixar o arquivo na sessao de downloads do prórprio site do selenium, descompactar
        /// We've got to download a file from selenium's download section unpack and put the executable in a folder that the application
        /// will be accessing.        
        /// https://medium.com/@renato.groffe/utilizando-o-selenium-webdriver-com-net-core-2-0-e-net-standard-2-0-31176aa5508e
        /// </summary>
        public static IWebDriver GetWebDriver(Browser browser, string pathDriver = null)
        {
            IWebDriver webDriver = null;
            switch (browser)
            {
                case Browser.Firefox:
                    FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(pathDriver);
                    webDriver = new FirefoxDriver(service);
                    break;
                case Browser.Chrome:
                    webDriver = new ChromeDriver(pathDriver);
                    break;
                case Browser.IE:
                    webDriver = new InternetExplorerDriver(pathDriver);
                    break;
                case Browser.Edge:
                    webDriver = new EdgeDriver(pathDriver);
                    break;     
            }

            return webDriver;
        }
    }
}
