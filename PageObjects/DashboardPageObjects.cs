using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
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

        [FindsBy(How =How.Id,Using = "RequestTypeR1")]
        public IWebElement WFHradiobutton { get; private set; }

        [FindsBy(How = How.Id, Using = "RequestTypeR2")]
        public IWebElement WFOffice { get; private set; }

        [FindsBy(How =How.Id,Using = "btnsubmit")]
        public IWebElement SubmitButton { get; set; }

        public void CloseStartUpPopUpDialouge() {

            try
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
                ClickElement(CloseStartUpPopBtn);
            }
            catch (Exception e)
            {

                Console.WriteLine("Close dialouge button not found");
            }
        }

        internal void DeclareWFH(string v)
        {
            try {
                if (IsElementVisible(WFHradiobutton)) {
                    if (v.ToLower().Equals("yes"))

                        ClickElement(WFHradiobutton);
                    else
                        ClickElement(WFOffice);

                        ClickElement(SubmitButton);
                    IAlert alert = driver.SwitchTo().Alert();
                    alert.Accept();



                }
            
            } catch (Exception e) {
                Console.WriteLine("Element not visible: " + e.Message);
            }
            try
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
                ClickElement(CloseStartUpPopBtn);
            }
            catch (Exception e)
            {

                Console.WriteLine("Close dialouge button not found");
            }
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
