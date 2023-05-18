using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumExtras.PageObjects;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;

public class SignIn : BasePage
{
    
    [FindsBy(How = How.XPath, Using = "//input[@id='mat-input-0']")]
    public IWebElement usernameInput;

    [FindsBy(How = How.XPath, Using = "//input[@id='mat-input-1']")]
    public IWebElement passwordInput;

    [FindsBy(How = How.XPath, Using = "//button[normalize-space()='Sign In']")]
    public IWebElement loginButton;

    public SignIn(IWebDriver driver ) :base (driver)
    {
        //this.driver = driver;
        PageFactory.InitElements(driver, this);
    }

    public void EnterUsername(string username)
    {
        usernameInput.SendKeys(username);
    }

    public void EnterPassword(string password)
    {
        passwordInput.SendKeys(password);
    }

    public void ClickLoginButton()
    {
        loginButton.Click();
    }
    public void CheckLoginSuccessful()
    {
        // Assert that the user is successfully logged in
        string expectedUrl = "https://rlv-01-core-shared-ui-cia-test.azurewebsites.net/#/patientDashboard/appointments";
        string actualUrl = driver.Url;
    
        Assert.That(actualUrl, Is.EqualTo(expectedUrl), "User should be successfully logged in and redirected to the home page.");
      
            
    }
}
