using MarsFramework.Global;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Threading;
using static MarsFramework.Global.GlobalDefinitions;
using OpenQA.Selenium.Support.UI;
using System;
using AutoItX3Lib;
using NUnit.Framework;

namespace MarsFramework.Pages
{
    internal class ShareSkill
    {
        public ShareSkill()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        //Click on ShareSkill Button
        [FindsBy(How = How.LinkText, Using = "Share Skill")]
        private IWebElement ShareSkillButton { get; set; }

        //Enter the Title in textbox
        [FindsBy(How = How.Name, Using = "title")]
        private IWebElement Title { get; set; }

        //Enter the Description in textbox
        [FindsBy(How = How.Name, Using = "description")]
        private IWebElement Description { get; set; }

        //Click on Category Dropdown
        [FindsBy(How = How.Name, Using = "categoryId")]
        private IWebElement CategoryDropDown { get; set; }

        //Selecting option from Categorydropdown
        [FindsBy(How = How.XPath, Using = "//select[@name='categoryId']")]
        public IWebElement SelectSubDropdown { get; set; }

        //Click on SubCategory Dropdown
        [FindsBy(How = How.Name, Using = "subcategoryId")]
        private IWebElement SubCategoryDropDown { get; set; }

        //Selecting Option from SubCategory
        [FindsBy(How = How.XPath, Using = "//select[@name = 'subcategoryId']")]
        private IWebElement SelectDropdown { get; set; }

        //Enter Tag names in textbox
        [FindsBy(How = How.XPath, Using = "//body/div/div/div[@id='service-listing-section']/div[contains(@class,'ui container')]/div[contains(@class,'listing')]/form[contains(@class,'ui form')]/div[contains(@class,'tooltip-target ui grid')]/div[contains(@class,'twelve wide column')]/div[contains(@class,'')]/div[contains(@class,'ReactTags__tags')]/div[contains(@class,'ReactTags__selected')]/div[contains(@class,'ReactTags__tagInput')]/input[1]")]
        private IWebElement Tags { get; set; }

        //Select the oneOff service type
        [FindsBy(How = How.XPath, Using = "//input[@name='serviceType'][@value= '1']")]
        private IWebElement OneOffType { get; set; }

        //Select the Hourly service type
        [FindsBy(How = How.XPath, Using = "//input[@name='serviceType'][@value= '0']")]
        private IWebElement HourlyType { get; set; }
        //Select the OnSite Location Type
        [FindsBy(How = How.XPath, Using = "//input[@name = 'locationType'][@value = '0']")]
        private IWebElement OnSiteLocationTypeOption { get; set; }

        //Select the Online Location Type
        [FindsBy(How = How.XPath, Using = "//input[@name = 'locationType'][@value = '1']")]
        private IWebElement OnlineLocationTypeOption { get; set; }


        //Click on Start Date dropdown
        [FindsBy(How = How.Name, Using = "startDate")]
        private IWebElement StartDateDropDown { get; set; }

        //Click on End Date dropdown
        [FindsBy(How = How.Name, Using = "endDate")]
        private IWebElement EndDateDropDown { get; set; }

        //Storing the table of available days
        [FindsBy(How = How.XPath, Using = "//body/div/div/div[@id='service-listing-section']/div[@class='ui container']/div[@class='listing']/form[@class='ui form']/div[7]/div[2]/div[1]")]
        private IWebElement Days { get; set; }

        //Storing the starttime
        [FindsBy(How = How.XPath, Using = "//div[3]/div[2]/input[1]")]
        private IWebElement StartTime { get; set; }

        //Click on StartTime dropdown
        [FindsBy(How = How.XPath, Using = "//div[3]/div[2]/input[1]")]
        private IWebElement StartTimeDropDown { get; set; }

        //Click on EndTime dropdown
        [FindsBy(How = How.XPath, Using = "//div[3]/div[3]/input[1]")]
        private IWebElement EndTimeDropDown { get; set; }

        //Click on DayAvailability
        [FindsBy(How = How.XPath, Using = "//input[@type = 'checkbox'][@index = '1']")]
        private IWebElement DayAvailability { get; set; }

        //click on Sun
        [FindsBy(How = How.XPath, Using = "//div[@class = 'ui checkbox']//input[@index='0']")]
        private IWebElement Sunday { get; set; }

        //click on Mon
        [FindsBy(How = How.XPath, Using = "//div[@class = 'ui checkbox']//input[@index='1']")]
        private IWebElement Monday { get; set; }

        //click on Tue
        [FindsBy(How = How.XPath, Using = "//div[@class = 'ui checkbox']//input[@index='2']")]
        private IWebElement Tuesday { get; set; }

        //click on Wed
        [FindsBy(How = How.XPath, Using = "//div[@class = 'ui checkbox']//input[@index='3']")]
        private IWebElement Wednesday { get; set; }

        //click on Thu
        [FindsBy(How = How.XPath, Using = "//div[@class = 'ui checkbox']//input[@index='4']")]
        private IWebElement Thursday { get; set; }

        //Count no of days available
        [FindsBy(How = How.XPath, Using = "//h3[@id ='requiredField'][text() ='Available days']")]
        private IWebElement noOfDays { get; set; }

        //Select Sunday Start Time 

        [FindsBy(How = How.XPath, Using = "//div[@class = 'fields']//input[@name = 'StartTime'][@index = '0']")]
        private IWebElement SundayTime { get; set; }

        //Select Monday Start Time 

        [FindsBy(How = How.XPath, Using = "//div[@class = 'fields']//input[@name = 'StartTime'][@index = '1']")]
        private IWebElement MondayTime { get; set; }

        //Select Tuesday Start Time 

        [FindsBy(How = How.XPath, Using = "//div[@class = 'fields']//input[@name = 'StartTime'][@index = '2']")]
        private IWebElement TuesdayTime { get; set; }

        //Select Wednesday Start Time 

        [FindsBy(How = How.XPath, Using = "//div[@class = 'fields']//input[@name = 'StartTime'][@index = '3']")]
        private IWebElement WednesdayTime { get; set; }

        //Select Thursday Start Time 

        [FindsBy(How = How.XPath, Using = "//div[@class = 'fields']//input[@name = 'StartTime'][@index = '4']")]
        private IWebElement ThursdayTime { get; set; }

        //Select SundayEndTime 
        [FindsBy(How = How.XPath, Using = "//div[@class ='fields']//input[@name='EndTime'][@index='0']")]
        private IWebElement SundayEndTime { get; set; }

        //Select MondayEndTime 
        [FindsBy(How = How.XPath, Using = "//div[@class ='fields']//input[@name='EndTime'][@index='1']")]
        private IWebElement MondayEndTime { get; set; }

        //Select TuesdayEndTime 
        [FindsBy(How = How.XPath, Using = "//div[@class ='fields']//input[@name='EndTime'][@index='2']")]
        private IWebElement TuesdayEndTime { get; set; }

        //Select WednesdayEndTime 
        [FindsBy(How = How.XPath, Using = "//div[@class ='fields']//input[@name='EndTime'][@index='3']")]
        private IWebElement WednesdayEndTime { get; set; }





        //Click on  1st SkillTrade option
        [FindsBy(How = How.XPath, Using = "//input[@name = 'skillTrades'][@value = 'true']")]
        private IWebElement FirstSkillTradeOption { get; set; }

        //Click on  2st SkillTrade option
        [FindsBy(How = How.XPath, Using = "//input[@name = 'skillTrades'][@value = 'false']")]
        private IWebElement SecondkillTradeOption { get; set; }

        //Enter Skill Exchange
        [FindsBy(How = How.XPath, Using = "//div[@class='form-wrapper']//input[@placeholder='Add new tag']")]
        private IWebElement SkillExchange { get; set; }

        //Enter the amount for Credit
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Amount']")]
        private IWebElement CreditAmount { get; set; }

        //Enter WorkSample
        [FindsBy(How = How.XPath, Using = "//i[@Class = 'huge plus circle icon padding-25']")]
        private IWebElement FileUpload { get; set; }


        //Click on Active option
        [FindsBy(How = How.XPath, Using = "//input[@name = 'isActive'][@value = 'true']")]
        private IWebElement ActiveOption { get; set; }

        //Click on Hidden option
        [FindsBy(How = How.XPath, Using = "//input[@name = 'isActive'][@value = 'false']")]
        private IWebElement HiddenOption { get; set; }


        //Click on Save button
        [FindsBy(How = How.XPath, Using = "//input[@value='Save']")]
        private IWebElement Save { get; set; }

        internal void EnterShareSkill()
        {
            //GlobalDefinitions.WaitForElement(driver, By.,20)
            GlobalDefinitions.wait(10);
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ShareSkill");
            //clcik on Shareskill button
            ShareSkillButton.Click();
            //Click on Title text box
            Title.SendKeys(ExcelLib.ReadData(2, "Title"));
            //Enter Description in Title
            Description.SendKeys(ExcelLib.ReadData(2, "Description"));
            //CLick on dropdown
            CategoryDropDown.Click();
            //Thread.Sleep(5000);
            //Selecting option from Categorydropdown
            SelectElement oselect = new SelectElement(SelectSubDropdown);
            oselect.SelectByText(ExcelLib.ReadData(2, "Category"));

            //Click on SubCategory
            SubCategoryDropDown.Click();

            //Selecting option from SubCategorydropdown
            SelectElement subCategory = new SelectElement(SelectDropdown);
            subCategory.SelectByValue(ExcelLib.ReadData(2, "SubCategory"));

            //Enter Tags
            Tags.SendKeys(ExcelLib.ReadData(2, "Tags"));
            Tags.SendKeys(Keys.Enter);
            //Select Service Type(Radio buttons)
            switch (ExcelLib.ReadData(2, "ServiceType"))
            {
                case "One-off service":
                    OneOffType.Click();
                    break;
                case "Hourly basis service":
                    HourlyType.Click();
                    break;
            }
            //Select Location Type (Radio buttons)
            switch (ExcelLib.ReadData(2, "LocationType"))
            {
                case "On-site":
                    OnSiteLocationTypeOption.Click();
                    break;
                case "Online":
                    OnlineLocationTypeOption.Click();
                    break;
            }

            GlobalDefinitions.WaitForElement(driver, By.XPath("//div[3]/div[2]/input[1]"), 10);

            //Select Start Date 
            StartDateDropDown.Click();
            Thread.Sleep(5000);
            StartDateDropDown.SendKeys(ExcelLib.ReadData(2, "Startdate"));

            GlobalDefinitions.WaitForElement(driver, By.Name("endDate"), 10);
            //Select End Date
            EndDateDropDown.Click();
            EndDateDropDown.SendKeys(ExcelLib.ReadData(2, "Enddate"));

            //DayAvailability
            switch (ExcelLib.ReadData(2, "Selectday"))
            {
                case "Sun":
                    Sunday.Click();
                    SundayTime.SendKeys(ExcelLib.ReadData(2, "Starttime"));
                    SundayEndTime.SendKeys(ExcelLib.ReadData(2, "Endtime"));
                    break;

                case "Mon":
                    Monday.Click();
                    MondayTime.SendKeys(ExcelLib.ReadData(2, "Starttime"));
                    MondayEndTime.SendKeys(ExcelLib.ReadData(2, "Endtime"));
                    break;

                case "Tue":
                    Tuesday.Click();
                    TuesdayTime.SendKeys(ExcelLib.ReadData(2, "Starttime"));
                    TuesdayEndTime.SendKeys(ExcelLib.ReadData(2, "Endtime"));
                    break;

                case "Wed":
                    Wednesday.Click();
                    WednesdayTime.SendKeys(ExcelLib.ReadData(2, "Starttime"));
                    WednesdayEndTime.SendKeys(ExcelLib.ReadData(2, "Endtime"));
                    break;

                case "Thu":
                    Thursday.Click();
                    ThursdayTime.SendKeys(ExcelLib.ReadData(2, "Starttime"));
                    //MondayEndTime.SendKeys(ExcelLib.ReadData(2, "Endtime"));
                    break;

            }
            //Select Skill Trade Radio buttons)
            switch (ExcelLib.ReadData(2, "SkillTrade"))
            {
                case "Skill-exchange":
                    FirstSkillTradeOption.Click();
                    break;
                case "Credit":
                    SecondkillTradeOption.Click();
                    break;
            }
            //Enter Skill-Exchange
            SkillExchange.SendKeys(ExcelLib.ReadData(2, "Skill-Exchange"));
            SkillExchange.SendKeys(Keys.Enter);
            //Enter WorkSample
            //FileUpload.SendKeys(@"C:\Users\.txt");
            GlobalDefinitions.WaitForElement(driver, By.XPath("//i[@Class = 'huge plus circle icon padding-25']"), 10);
            FileUpload.Click();
            AutoItX3 autoIt = new AutoItX3();
            autoIt.WinActivate("Open");
            Thread.Sleep(5000);
            autoIt.Send(@"C:\Users\Mukesh\Desktop\selenium.jpg");
            Thread.Sleep(5000);
            autoIt.Send("{ENTER}");
            //Thread.Sleep(5000);
            ////WorkSample.Click();


            //Select ACtive/Hidden Options ( Radio Buttons)
            switch (ExcelLib.ReadData(2, "Active"))
            {
                case "Active":
                    ActiveOption.Click();
                    break;
                case "Hidden":
                    HiddenOption.Click();
                    break;
            }

            //Click on Save
            Save.Click();
            // Assert.IsTrue("Service Listing Saved Successfully".Exist, "OK");
        }

        internal void EditShareSkill()
        {

        }
    }
}
