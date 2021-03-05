using MarsFramework.Global;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Threading;
using static MarsFramework.Global.GlobalDefinitions;
using System;
using NUnit.Framework;
using System.Collections.Generic;

namespace MarsFramework.Pages
{
    internal class ManageListings
    {
        public ManageListings()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        //Click on Manage Listings Link
        [FindsBy(How = How.LinkText, Using = "Manage Listings")]
        private IWebElement ManageListingsLink { get; set; }

        //View the listing
        [FindsBy(How = How.XPath, Using = "//i[@class='eye icon']")]
        private IWebElement view { get; set; }

        //Edit the listing
        [FindsBy(How = How.XPath, Using = "//div[@class = 'ui small icon buttons basic vertical']//button[2]")]
        private IWebElement edit { get; set; }

        //Click on Active or Inactive
        [FindsBy(How = How.XPath, Using = "//input[@name='isActive']")]
        private IWebElement clickActionsButton { get; set; }

        //Enter the Title in textbox
        [FindsBy(How = How.Name, Using = "title")]
        private IWebElement Title { get; set; }

        //Click on Save button
        [FindsBy(How = How.XPath, Using = "//input[@value='Save']")]
        private IWebElement Save { get; set; }

        //Delete the listing
        [FindsBy(How = How.XPath, Using = "//div[@class = 'ui small icon buttons basic vertical']//button[3]")]
        private IWebElement delete { get; set; }

        //Confirm Donot Delete (NO)
        [FindsBy(How = How.XPath, Using = "//div[@class = 'actions']/button[1]")]
        private IWebElement DonotDelete { get; set; }

        //Confirm Donot Delete (NO)
        [FindsBy(How = How.XPath, Using = "//div[@class ='actions']/button[2]")]
        private IWebElement YesDelete { get; set; }

        internal void Viewlistings()
        {
            GlobalDefinitions.wait(20);
            //Populate data from Excel Sheet
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "Manage List");
            //Click on Manage Listings Link
            ManageListingsLink.Click();
            //GlobalDefinitions.WaitForElement(driver, By.XPath("//td[@class='four wide'][text()= 'Selenium']"), 10);
            IList<IWebElement> noOfrows = driver.FindElements(By.XPath("//*[@id = 'listing-management-section']//table//tbody//tr"));
            int rows = noOfrows.Count;
            Console.WriteLine(rows);
            for (int i = 1; i <= rows; i++)
            {
                //var pagination = driver.FindElements(By.XPath("//div[@class='ui buttons semantic-ui-react-button-pagination']//button[i]")).Count;
                var titleName = driver.FindElement(By.XPath("//table[@class = 'ui striped table']//tr[" + i + "]//td[3]")).Text;
                Thread.Sleep(5000);
                var viewSkill = driver.FindElement(By.XPath("//table[@class ='ui striped table']//tr[" + i + "]//td[8]//div//button[1]"));

                var expectedValue = "Selenium";

                if (titleName == expectedValue)
                {
                    Assert.IsTrue(expectedValue == titleName, "Titlename Selenium not found");

                    //var pagination = driver.FindElements(By.XPath("//div[@class='ui buttons semantic-ui-react-button-pagination']//button[2]")).Count;
                    //GlobalDefinitions.WaitForElement(driver, By.XPath("//table[@class ='ui striped table']//tr["+i+"]//td[8]//div//button[1]//i[1]"),10);
                    viewSkill.Click();
                    var viewPage = "Service Detail";
                    Assert.AreEqual(viewPage, driver.Title, "Service Listing not opened");
                    Console.WriteLine("Service Listing opened");
                    Thread.Sleep(5000);
                    //GoBack to Previous Page
                    GlobalDefinitions.goback();
                    Thread.Sleep(5000);
                }
                else
                {
                    Console.WriteLine("Test fail");
                }
            }

        }
        internal void EditListing()
        {
            GlobalDefinitions.wait(20);
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "Manage List");
            //Click on Manage Listings Link
            ManageListingsLink.Click();
            //count number of rows
            IList<IWebElement> noOfrows = driver.FindElements(By.XPath("//*[@id = 'listing-management-section']//table//tbody//tr"));
            int rows = noOfrows.Count;
            Thread.Sleep(5000);
            Console.WriteLine(rows);

            for (int x = 1; x <= rows; x++)
            {
                var titleName = driver.FindElement(By.XPath("//table[@class = 'ui striped table']//tr[" + x + "]//td[3]")).Text;
                Thread.Sleep(5000);
                var edit = driver.FindElement(By.XPath("//table[@class ='ui striped table']//tr[" + x + "]//td[8]//div//button[2]"));

                if (titleName == "Selenium")
                {

                    Thread.Sleep(5000);
                    //GlobalDefinitions.WaitForElement(driver, By.XPath("//table[@class ='ui striped table']//tr["+x+"]//td[8]//div//button[1]//i[1]"),10);
                    edit.Click();
                    Thread.Sleep(5000);
                    var serviceListing = "ServiceListing";
                    Assert.AreEqual(serviceListing, driver.Title, "Service listing not opened");
                    Console.WriteLine("Edit clicked");
                    break;
                }
                else
                {
                    Console.WriteLine("Test fail");
                }
            }
            Thread.Sleep(5000);
            Title.Click();
            //CLear the current tilte
            Title.Clear();

            //Edit the new Title
            Title.SendKeys(ExcelLib.ReadData(2, "SKillTitle"));

            //CLick on save to save updated title
            Save.Click();
            GlobalDefinitions.WaitForElement(driver, By.XPath("//div[@class ='ui center aligned']"), 10);
            var listingManagement = "ListingManagement";
            Assert.AreEqual(listingManagement, driver.Title, "skill Not updated");
            Console.WriteLine("Skill updated Successfully");
        }
        internal void DeleteListing()
        {
            GlobalDefinitions.wait(20);
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "Manage List");
            //Click on Manage Listings Link
            ManageListingsLink.Click();
            Thread.Sleep(5000);
            IList<IWebElement> noOfrows = driver.FindElements(By.XPath("//*[@id = 'listing-management-section']//table//tbody//tr"));
            int rows = noOfrows.Count;
            Thread.Sleep(5000);
            for (int y = 1; y <= rows; y++)
            {
                var titleName = driver.FindElement(By.XPath("//table[@class = 'ui striped table']//tr[" + y + "]//td[3]")).Text;

                var delete = driver.FindElement(By.XPath("//table[@class ='ui striped table']//tr[" + y + "]//td[8]//div//button[3]"));
                Thread.Sleep(5000);

                if (titleName == "Selenium WebDriver")
                {
                    //GlobalDefinitions.WaitForElement(driver, By.XPath("//table[@class ='ui striped table']//tr["+x+"]//td[8]//div//button[1]//i[1]"),10);
                    delete.Click();
                    Console.WriteLine("Delete clicked");
                    break;
                }
                else
                {
                    Console.WriteLine("Test fail");
                }
            }

            if (ExcelLib.ReadData(2, "Deleteaction") == "Yes")
            {
                YesDelete.Click();
                Console.WriteLine("Deleted");
            }
            else
            {
                DonotDelete.Click();
                Console.WriteLine("NotDeleted");
            }

        }
    }
}
