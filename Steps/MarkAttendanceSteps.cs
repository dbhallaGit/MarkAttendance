using MarkAttendance.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace MarkAttendance.Steps
{
    

    [Binding]
    public class MarkAttendanceSteps
    {      
       
        LoginPageObjects loginPage;
        DashboardPageObjects dashboardPage;
        AttendacePageObjects attendacePage;



        MarkAttendanceSteps(LoginPageObjects loginPage, DashboardPageObjects dashboardPage, AttendacePageObjects attendacePage) {
            this.loginPage = loginPage;
            this.dashboardPage = dashboardPage;
            this.attendacePage = attendacePage;

        }


        [Then(@"mark the attendance")]
        public void ThenMarkTheAttendance()
        {
            //dashboardPage.CloseStartUpPopUpDialouge();
            Console.WriteLine("Marking the attendance");

            dashboardPage.GoToAttendacePage();
            attendacePage.OpenTodayAttendance();
            attendacePage.markAttendance();

                    
            
        }

    }
}
