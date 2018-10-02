using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QATesting.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using System.Threading.Tasks;
using System.Threading;
using OtpNet;
namespace QATesting.Test_Steps
{
    [Binding]
    class XeroOrganisation :XeroOrganisationPageBase
    {
        Pages.XeroOrganisationPageBase pageobj = new XeroOrganisationPageBase();
        public string AccountName;
        public string randomnum = DateTime.Now.ToString("HH:mm");

        [Given(@"I navigate to Xero login page and login")]
        public void GivenINavigateToXeroLoginPageAndLogin()
        {
            pageobj.Initialize();
            pageobj.OpenApp();
            GivenINavigateToXeroLoginPageAndLogin(pageobj);
        }
         static void GivenINavigateToXeroLoginPageAndLogin(Pages.XeroOrganisationPageBase pageobj)
        {
            pageobj.LoginEmail.SendKeys("shahparthqa@gmail.com");
            pageobj.Loginpassword.SendKeys("Admin@123");
            pageobj.Button_Login.Click();
           
        }
        [Given(@"I enter (.*)FA code")]
        public void GivenIEnterFACode(int p0)
        {
            var otpKeyStr = "J5ZVAODXMEYDEN2RJ5GWYOJRMY"; // My 2FA authentication key
            var otpKeyBytes = Base32Encoding.ToBytes(otpKeyStr);
            var totp = new Totp(otpKeyBytes);
            var twoFactorCode = totp.ComputeTotp(); 
            pageobj.Text_AuthenticationCode.SendKeys(twoFactorCode);
            pageobj.Button_Login2FA.Click();
        }

        [Given(@"I make sure user is logged in")]
        public void GivenIMakeSureUserIsLoggedIn()
        {
            var assertion = new Action(() => Assert.IsTrue(pageobj.driver.PageSource.Contains("Parth Shah")));
            Equals(assertion);
        }
        [Given(@"Select a (.*) from menu")]
        public void GivenSelectAFromMenu(string HeaderTab)
        {
         pageobj.Header_Accounts.Click();
        }
        [Given(@"Select Bank Accounts")]
        public void GivenSelectBankAccounts()
        {
         pageobj.Menu_BankAccount.Click();
        }

        [Given(@"Click on Add Bank Account button")]
        public void GivenClickOnAddBankAccountButton()
        {
            pageobj.Button_AddBankAccount.Click();
        }

        [Given(@"Select (.*) from banklist")]
        public void GivenSelectFromBanklist(string BankName)
        {
            pageobj.Textbox_searchyourbank.SendKeys(BankName);
            new ManualResetEvent(false).WaitOne(1000);
            pageobj.Link_showresult.Click();
            new ManualResetEvent(false).WaitOne(2000);
            pageobj.Link_SelectBankFromList.Click();
        }
        [Given(@"Enter the account details  (.*),(.*), (.*)")]
        public void GivenEntertheaccountdetails(string AccountName, string AccountType, string AccountNumber)
        {

			AccountName = AccountName + randomnum;
            pageobj.TextBox_AccountName.SendKeys(AccountName);
            pageobj.Input_AccountType.Click();
            pageobj.LI_AccountType.Click();
           //pageobj.Dropdown_AccountType().SelectByText(AccountType);
            pageobj.TextBox_AccountNumber.SendKeys(AccountNumber);
        }

        [When(@"I click on continue")]
        public void WhenIClickOnContinue()
        {
            pageobj.Button_BankAccountContinue.Click();
        }

        [Then(@"Account should be added successfully")]
        public void ThenAccountShouldBeAddedSuccessfully()
        {
            var assertion = new Action(() => Assert.IsTrue(pageobj.driver.PageSource.Contains(" has been added.")));
            Equals(assertion);
            
        }




    }
}
