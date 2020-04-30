using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkAttendance.PageObjects
{
    class DashboardPageObjects:BaseClass
    {

        
        public DashboardPageObjects() {
            PageFactory.InitElements(BaseClass.driver, this);
        }


        [FindsBy(How = How.XPath, Using = "(//div[@class='modal-footer']/button[text()='Close'])[1]")]
        public IWebElement CloseStartUpPopBtn { get; set; }


        [FindsBy(How =How.Id,Using = "Attendance")]
        public  IWebElement AttendaceBtn { get; set; }

        [FindsBy(How =How.Id,Using = "TimeSheet")]
        public IWebElement TimeSheetBtn { get;  set; }

        public void CloseStartUpPopUpDialouge() {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            ClickElement(CloseStartUpPopBtn);
        }

        public void GoToAttendacePage() {
            AttendaceBtn.Click();

           driver=SwitchToNextWindow();
                            

        }

        public void GoToTimeSheetPage() {
            ClickElement(TimeSheetBtn);

        }



    }
}
