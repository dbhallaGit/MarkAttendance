using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MarkAttendance.PageObjects
{
    class TimesheetPageObjects:BaseClass
    {

        TimesheetPageObjects() {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How =How.XPath,Using = "//a[text()='Web Timesheet']")]
        public IWebElement WebTimeSheetPageBtn { get; private set; }

        [FindsBy(How=How.XPath,Using = "//li[@id='workTimeLi']/a")]
        public IWebElement ProhenceWebTimeListBtn { get; private set; }

        [FindsBy(How=How.XPath,Using = "//a[text()='TIMESHEET']")]
        public IWebElement ProhenceWebTimeList_TimeSheetBtn { get; private set; }

        [FindsBy(How =How.XPath,Using = "(//*[text()='Custom'][contains(@class,'customTdId')])[1]")            ]
        public IWebElement CustomBtn { get; private set; }

        [FindsBy(How=How.Id,Using = "selectedWeek")]
        public IWebElement SelectWeekOfTheYear { get; private set; }        

        [FindsBy(How =How.Id,Using = "selectedWeekYear")]
        public IWebElement SelectYear { get; private set; }

        [FindsBy(How =How.CssSelector,Using = "#dateSpan_CustomWeekLabel")]
        public IWebElement SelectWeek { get; private set; }

        [FindsBy(How =How.Id,Using = "start_Hour")]
        public IWebElement StartHour { get; private set; }

        [FindsBy(How = How.Id, Using = "end_Hour")]
        public IWebElement EndHour { get; private set; }

        [FindsBy(How = How.Id, Using = "idleTime_Activity")]
        public IWebElement Activity { get; private set; }

        [FindsBy(How = How.Id, Using = "idle_description")] 
        public IWebElement Description { get; private set; }

        [FindsBy(How =How.XPath,Using = "//*[@value='SUBMIT'][@id='aafsSubmitBtn']")]
        public IWebElement SubmitTimeSheetBtn { get; set; }

        [FindsBy(How =How.XPath,Using = "//*[@value='CLOSE']")]
        public IWebElement CloseTimeSheetBtn { get; private set; }

        public void GoToWebTimeSheetPage()  
        {
           WebTimeSheetPageBtn.Click();
        }

        internal void OpenProhenceTimeSheet()
        {
            Thread.Sleep(5000);
            ClickElementWithJS(ProhenceWebTimeListBtn);
            ClickElementWithJS(ProhenceWebTimeList_TimeSheetBtn);            

        }

        internal void CheckShiftAndCurrentTime()
        {
            if (Convert.ToInt32(getCurrenthour()) < Convert.ToInt32(ConfigurationManager.AppSettings["ShiftEndTime"]))
            {
                Console.WriteLine("TimeSheet Filling time can not be earlier than shift end time");
               throw new Exception("Try logging after shift");
            }
        }

        internal void CheckCurrentWeek()
        {
            Console.WriteLine(DateTime.Now.DayOfWeek);
            DateTimeFormatInfo format = DateTimeFormatInfo.CurrentInfo;
            Calendar cal = format.Calendar;
            int week = cal.GetWeekOfYear(DateTime.Now, format.CalendarWeekRule, format.FirstDayOfWeek);

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            ClickElementWithJS(CustomBtn);


            SelectElement selectYear = new SelectElement(SelectYear);
            selectYear.SelectByValue(DateTime.Now.Year.ToString());


            ClickElement(SelectWeekOfTheYear);
            SelectElement selectWeek = new SelectElement(SelectWeekOfTheYear);
            selectWeek.SelectByIndex(week-1);

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            ClickElement(SelectWeek);

        }

        
        internal void EnterHours()
        {
            int columnNumber;
            IWebElement ele;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            
            if (DayOfWeek().Equals("monday"))
            {
                columnNumber = 6;
                 ele= driver.FindElement(By.XPath($"(//*[contains(@class,'col-lg-1')]/*[@class='row']/div/div/div/table/tbody/tr/td[@data-backdrop='static'][@data-target='#idleActivityScreenModal'])[{columnNumber}]"));
               
                ClickElementWithJS(ele);

               
            }
            else if (DayOfWeek().Equals("tuesday"))
            {
                columnNumber = 78;
                //ele = driver.FindElement(By.XPath("(//*[contains(@class,'col-lg-1')]/*[@class='row']/div/div/div/table/tbody/tr/td[@data-backdrop='static'][@data-target='#idleActivityScreenModal'])[last()]"));
                ele = driver.FindElement(By.XPath($"(//*[contains(@class,'col-lg-1')]/*[@class='row']/div/div/div/table/tbody/tr/td[@data-backdrop='static'][@data-target='#idleActivityScreenModal'])[{columnNumber}]"));
                ClickElementWithJS(ele);
            }
            else if (DayOfWeek().Equals("wednesday"))
            {
                columnNumber = 150;
                ele = driver.FindElement(By.XPath($"(//*[contains(@class,'col-lg-1')]/*[@class='row']/div/div/div/table/tbody/tr/td[@data-backdrop='static'][@data-target='#idleActivityScreenModal'])[{columnNumber}]"));
                ClickElementWithJS(ele);
            }
            else if (DayOfWeek().Equals("thrusday"))
            {
                columnNumber = 222;
                ele = driver.FindElement(By.XPath($"(//*[contains(@class,'col-lg-1')]/*[@class='row']/div/div/div/table/tbody/tr/td[@data-backdrop='static'][@data-target='#idleActivityScreenModal'])[{columnNumber}]"));
                ClickElementWithJS(ele);
            }
            else if (DayOfWeek().Equals("friday"))
            {
                columnNumber = 294;
                ele = driver.FindElement(By.XPath($"(//*[contains(@class,'col-lg-1')]/*[@class='row']/div/div/div/table/tbody/tr/td[@data-backdrop='static'][@data-target='#idleActivityScreenModal'])[{columnNumber}]"));
                ClickElementWithJS(ele);
            }
            else if (DayOfWeek().Equals("saturday"))
                Console.WriteLine("Saturday");
            else if (DayOfWeek().Equals("sunday"))
                Console.WriteLine("Sunday");
                      
            



        }

        internal void selectTimeAndRemark()
        {
            SelectElement selectStartHour = new SelectElement(StartHour);
            selectStartHour.SelectByIndex(Convert.ToInt32(ConfigurationManager.AppSettings["ShiftStartTime"]));

            SelectElement selectEndHour = new SelectElement(EndHour);
            selectEndHour.SelectByIndex(Convert.ToInt32(ConfigurationManager.AppSettings["ShiftEndTime"]));

            SelectElement selectActivity = new SelectElement(Activity);
            selectActivity.SelectByText("Working/Testing on Other Devices");

            Description.SendKeys("WFH");

            ClickElement(SubmitTimeSheetBtn);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            ClickElement(CloseTimeSheetBtn);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);

        }

       
    }
}
