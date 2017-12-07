using Microsoft.Extensions.Configuration;
using Selenium.Utils;
using System.IO;
using Xunit;

namespace Selenium.Tests
{
    public class Tests
    {
        private readonly IConfiguration _configuration;

        public Tests()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            _configuration = builder.Build();
        }

        private void ExecuteSeleniumTest(Browser browser, double milesValue, double kmValue)
        {
            var screen = new DistanceConverterScreen(_configuration, browser);
            screen.LoadPage();
            screen.FillDistanceMiles(milesValue);
            screen.ConvertMilesToKilometers();

            var valueConverted = screen.GetDistanceKm();
            screen.Close();

            Assert.Equal(kmValue, valueConverted);
        }

        [Theory]
        [InlineData(100, 160.90)]
        [InlineData(200, 321.80)]
        [InlineData(230.05, 370.1505)]
        [InlineData(250.50, 403.0545)]
        public void TestFirefox(double milesValue, double kmValue)
        {
            ExecuteSeleniumTest(Browser.Firefox, milesValue, kmValue);
        }

        [Theory]
        [InlineData(100, 160.90)]
        [InlineData(200, 321.80)]
        [InlineData(230.05, 370.1505)]
        [InlineData(250.50, 403.0545)]
        public void TestChrome(double milesValue, double kmValue)
        {
            ExecuteSeleniumTest(Browser.Chrome, milesValue, kmValue);
        }

        [Theory]
        [InlineData(100, 160.90)]
        [InlineData(200, 321.80)]
        [InlineData(230.05, 370.1505)]
        [InlineData(250.50, 403.0545)]
        public void TestEdge(double milesValue, double kmValue)
        {
            ExecuteSeleniumTest(Browser.Edge, milesValue, kmValue);
        }

        [Theory]
        [InlineData(100, 160.90)]
        [InlineData(200, 321.80)]
        [InlineData(230.05, 370.1505)]
        [InlineData(250.50, 403.0545)]
        public void TestIE(double milesValue, double kmValue)
        {
            ExecuteSeleniumTest(Browser.IE, milesValue, kmValue);
        }        
    }
}
