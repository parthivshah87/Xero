using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;

namespace QATesting.Pages
{
    class XeroOrganisationPageBase
    {
        public IWebDriver driver;

        public void Initialize()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(50);
        }
        public void OpenApp()
        {
            driver.Url = "https://login.xero.com/";
        }
       
        public IWebElement LoginEmail
        {
            get { return driver.FindElement(By.Id("email")); }
        }
        public IWebElement Loginpassword
        {
            get { return driver.FindElement(By.Id("password")); }
        }
        public IWebElement Button_Login
        {
            get { return driver.FindElement(By.Id("submitButton")); }
        }
        public IWebElement Text_AuthenticationCode
        {
            get { return driver.FindElement(By.XPath("//INPUT[@type='tel']")); }
        }
       
        public IWebElement Button_Login2FA
        {
            get { return driver.FindElement(By.XPath("//BUTTON[@class='xui-button xui-button-main xui-u-fullwidth'][text()='Log in']")); }
        }
       
        public IWebElement Link_LoggedinUser
        {
           get { return driver.FindElement(By.XPath("A[@class = 'username'][text() = 'Parth Shah']")); }
        }
        public IWebElement Header_Accounts
        {
            get { return driver.FindElement(By.XPath("//A[@data-type='menu-focus'][text()='Accounts']")); }
        }
        public IWebElement Menu_BankAccount
        {
            get { return driver.FindElement(By.XPath("//A[@data-type='menu-focus'][text()='Bank Accounts']")); }
        }
        public IWebElement Button_AddBankAccount
        {
            get { return driver.FindElement(By.XPath("//SPAN[@class='text'][text()='Add Bank Account']")); }
        }
        public IWebElement Textbox_searchyourbank
        {
            get { return driver.FindElement(By.Id("xui-searchfield-1018-inputEl")); }
        }
        public IWebElement Link_showresult
        {
            get { return driver.FindElement(By.XPath("//A[@href='#'][text()='Show 1 result from other countries...']")); }
        }
        public IWebElement Link_SelectBankFromList
        {
            get { return driver.FindElement(By.Id("dataview-1025")); }
        }
        public IWebElement TextBox_AccountName
        {
            get { return driver.FindElement(By.XPath("//input[starts-with(@id,'accountname-')]")); }
        }
        public IWebElement TextBox_AccountNumber
        {
            get { return driver.FindElement(By.Id("accountnumber-1068-inputEl")); }
        }
        public IWebElement Input_AccountType
        {
            get { return driver.FindElement(By.XPath("//input[starts-with(@id,'accounttype-')]")); }
        }
        public IWebElement LI_AccountType
        {
            get { return driver.FindElement(By.XPath("//*[@id=\"boundlist-1076-listEl\"]/li[1]")); }
        }
        public IWebElement Button_BankAccountContinue
        {
            get { return driver.FindElement(By.Id("common-button-submit-1015-btnInnerEl")); }
        }
        public IWebElement P_AddBankAccountSuccessMessage
        {
            get { return driver.FindElement(By.Id("ext-gen71")); }
        }

    }
}
