using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class SignUp : BasePage
{
    public SignUp(IWebDriver driver) : base(driver)
    {
        //this.driver = driver;
        PageFactory.InitElements(driver, this);
    }

    [FindsBy(How = How.XPath, Using = "//strong[normalize-space()='Register']")]
    public IWebElement RegisterButtonInHomePage;
    [FindsBy(How = How.XPath, Using = "//input[@id='mat-input-2']")]
    public IWebElement FirstNameTextFeild;
    [FindsBy(How = How.XPath, Using = "//input[@id='mat-input-3']")]
    public IWebElement LastNameTextFeild;
    [FindsBy(How = How.XPath, Using = "//input[@id='mat-input-4']")]
    public IWebElement EmailTextFeild;
    [FindsBy(How = How.XPath, Using = "//input[@id='mat-input-5']")]
    public IWebElement PhoneTextFeild;
    [FindsBy(How = How.XPath, Using = "//input[@id='mat-input-6']")]
    public IWebElement PasswordTextFeild;
    [FindsBy(How = How.XPath, Using = "//input[@id='mat-input-7']")]
    public IWebElement ConfirmPasswordTextFeild;
    [FindsBy(How = How.XPath, Using = "//div[@class='mat-select-arrow ng-tns-c65-9']")]
    public IWebElement CountryDropDown;
    [FindsBy(How = How.XPath, Using = "//span[@class='mat-option-text'][normalize-space()='India']")]
    public IWebElement India;
    [FindsBy(How = How.XPath, Using = "//span[@class='mat-option-text'][normalize-space()='Japan']")]
    public IWebElement Japan;
    [FindsBy(How = How.XPath, Using = "//span[normalize-space()='Cambodia']")]
    public IWebElement Combodia;
    [FindsBy(How = How.XPath, Using = "//div[@class='mat-select-arrow ng-tns-c65-11']")]
    public IWebElement CityDropDown;
    [FindsBy(How = How.XPath, Using = "//span[normalize-space()='Bangalore']")]
    public IWebElement Banglore;

    [FindsBy(How = How.XPath, Using = "//textarea[@id='mat-input-8']")]
    public IWebElement AddressTextFeild;
    [FindsBy(How = How.XPath, Using = "//button[normalize-space()='Register']")]
    public IWebElement RegisterButtonInRegisterPage;


    public void ClickRegisterButtonOnHomePage()
    {
        RegisterButtonInHomePage.Click();

    }
    public void FillRequiredDetails(string firstname, string lastname, string email, string phone, string password, string confirmPassword)
    {
        FirstNameTextFeild.SendKeys(firstname);
        LastNameTextFeild.SendKeys(lastname);
        EmailTextFeild.SendKeys(email);
        PhoneTextFeild.SendKeys(phone);
        PasswordTextFeild.SendKeys(password);   
        ConfirmPasswordTextFeild.SendKeys(confirmPassword); 
    }
    public void SelectCountryCity()
    {
        CountryDropDown.Click();
        India.Click();
        Thread.Sleep(1000);
        CityDropDown.Click();   
        Banglore.Click();  
       /* SelectElement dropdownCountry = new SelectElement(CountryDropDown);
        dropdownCountry.SelectByIndex(0);*/
       
       /* SelectElement dropdownCity = new SelectElement(CityDropDown);
        dropdownCity.SelectByIndex(2);*/  
           
    }
    public void EnterAddress(string address)
    {
        AddressTextFeild.SendKeys(address);
    }
    public void ClickRegisterButton()
    {
        RegisterButtonInRegisterPage.Click();
    }
}

