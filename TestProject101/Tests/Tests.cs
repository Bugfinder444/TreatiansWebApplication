using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V113.FedCm;
using OpenQA.Selenium.Support.UI;

namespace TreatiansWeb.Tests
{
    [TestFixture]
    public class TreatiansWebApp
    {
        public IWebDriver driver;
        [OneTimeSetUp]
        public void Setup()
        {
            // Initialize the WebDriver
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://rlv-01-core-shared-ui-cia-test.azurewebsites.net/#/cms/login");
        }

        [Test]
        public void SignUpTest()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(50);
            SignUp su = new SignUp(driver);
            su.ClickRegisterButtonOnHomePage();
            Thread.Sleep(2000);
            su.FillRequiredDetails("Gayas", "Khan", "gayaskhan@gmail.com", "9999999999", "12345678", "12345678");
            Thread.Sleep(3000);
            su.SelectCountryCity();
            su.EnterAddress("Sector 62");
            su.ClickRegisterButton();
            CaptureScreenshot("SignUpTest");
        }

        [Test]
        public void LoginTest()
        {
            // Test case for login
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(50);
            SignIn si = new SignIn(driver);
            Thread.Sleep(2000);
            si.EnterUsername("gayas");
            si.EnterPassword("gayas123");
            Thread.Sleep(2000);
            si.ClickLoginButton();
            Thread.Sleep(2000);
            si.CheckLoginSuccessful();
            CaptureScreenshot("LoginTest");
        }

        [OneTimeTearDown]
        public void Cleanup()
        {
            // Close the WebDriver
            driver.Quit();
        }

        private void CaptureScreenshot(string Test)
        {
            var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            string screenshotFileName = $"{Test}_{DateTime.Now:yyyyMMddHHmmssfff}.png";
            string screenshotPath = "C:\\Users\\Fleek\\ProjectC#\\TestProject101\\TestProject101\\Screenshots" + screenshotFileName; // Replace with your desired screenshot directory

            screenshot.SaveAsFile(screenshotPath, ScreenshotImageFormat.Png);
            TestContext.AddTestAttachment(screenshotPath, "Failed Test Screenshot");
        }
    }
}

//C: \Users\Fleek\.nuget\packages\nunit.consolerunner\3.16.3\tools>nunit3-console.exe C:\Users\Fleek\ProjectC#\TestProject101\TestProject101\bin\Debug\net6.0\TreatiansWeb.dll --result=C:\Users\Fleek\ProjectC#\TestProject101\TestProject101\TestsResult.xml --out=C:\Users\Fleek\ProjectC#\TestProject101\TestProject101\TestsResult.txt