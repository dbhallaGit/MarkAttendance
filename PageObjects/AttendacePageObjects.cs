using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;


namespace MarkAttendance.PageObjects
{
    class AttendacePageObjects:BaseClass
    {
       



        By dayLocator = By.XPath("//a[@style='color:Black'][text()='value']");

        [FindsBy(How =How.XPath,Using = "//*[contains(@name,'Remarks')]")]
        public IWebElement RemarkTextBoxk { get; set; }

        [FindsBy(How =How.XPath,Using = "//*[@value='Mark Attendance']")]
        public IWebElement MarkAttendanceBtn { get; set; }


        public AttendacePageObjects() {
            PageFactory.InitElements(driver, this);
        }

       

       
        public void OpenTodayAttendance() {

            if (!BaseClass.DayOfWeek().Equals("saturday") && !BaseClass.DayOfWeek().Equals("sunday"))
            {

                driver.FindElement(By.XPath($"//a[@style='color:Black'][text()='{DateTime.Now.Day}']")).Click();


            }
            else
                throw new Exception("Today is holiday");
        }

        internal void markAttendance()
        {   
            
            RemarkTextBoxk.SendKeys("WFH");
            MarkAttendanceBtn.Click();
        }
    }
}
