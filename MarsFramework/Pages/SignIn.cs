using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using MarsFramework.Global;
using static MarsFramework.Global.GlobalDefinitions;
using System.Threading;

namespace MarsFramework.Pages
{
    class SignIn
    {
        public SignIn()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        #region  Initialize Web Elements 
        //Finding the Sign Link
        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Sign')]")]
        private IWebElement SignIntab { get; set; }

        // Finding the Email Field
        [FindsBy(How = How.Name, Using = "email")]
        private IWebElement Email { get; set; }

        //Finding the Password Field
        [FindsBy(How = How.Name, Using = "password")]
        private IWebElement Password { get; set; }

        //Finding the Login Button
        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'Login')]")]
        private IWebElement LoginBtn { get; set; }

        #endregion

        internal void LoginSteps()
        {
            GlobalDefinitions.wait(10);
            //Populate the Excel Sheet
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "SignIn");
            GlobalDefinitions.driver.Navigate().GoToUrl(ExcelLib.ReadData(2, "Url"));
            SignIntab.Click();
            Email.SendKeys(ExcelLib.ReadData(2, "Username"));
            Password.SendKeys(ExcelLib.ReadData(2, "Password"));
            LoginBtn.Click();
            Thread.Sleep(5000);

        }
    }
}