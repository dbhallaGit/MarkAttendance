using MarkAttendance.PageObjects;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace MarkAttendance.Steps
{
    [Binding]
    class FillTimeSheetSteps:BaseClass
    {

       
        LoginPageObjects loginPage;
        DashboardPageObjects dashboardPage;
        AttendacePageObjects attendacePage;
        TimesheetPageObjects timesheetPage;


        FillTimeSheetSteps(DashboardPageObjects dashboardPage, LoginPageObjects loginPage, AttendacePageObjects attendacePage, TimesheetPageObjects timesheetPage) {
            this.dashboardPage = dashboardPage;
            this.timesheetPage = timesheetPage;


        }
        
        [Then(@"Fill timesheet")]
        public void ThenFillTimesheet()
        {   

            dashboardPage.GoToTimeSheetPage();
            SwitchToNextWindow();
            timesheetPage.GoToWebTimeSheetPage();
            SwitchToNextWindow();
            timesheetPage.OpenProhenceTimeSheet();
            timesheetPage.CheckCurrentWeek();
            timesheetPage.CheckShiftAndCurrentTime();
            timesheetPage.EnterHours();
            timesheetPage.selectTimeAndRemark();


            

        }

        [Given(@"check if timesheet is not present")]
        public void GivenCheckIfTimesheetIsNotPresent()
        {
            dashboardPage.GoToTimeSheetPage();
            SwitchToNextWindow();
            timesheetPage.GoToWebTimeSheetPage();
            SwitchToNextWindow();
            timesheetPage.OpenProhenceTimeSheet();
            timesheetPage.CheckCurrentWeek();
            timesheetPage.CheckYesterdayTimesheetIsFilled();
        }

        [Then(@"Fill yesterday timesheet")]
        public void ThenFillYesterdayTimesheet()
        {
            timesheetPage.selectTimeAndRemark();
        }


    }
}
