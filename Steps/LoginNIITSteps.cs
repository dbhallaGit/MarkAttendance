using MarkAttendance.PageObjects;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace MarkAttendance.Steps
{   
    [Binding]
    class LoginNIITSteps:BaseClass
    {
        LoginPageObjects loginPage;
        DashboardPageObjects dashboardPage;

        LoginNIITSteps(LoginPageObjects loginPage, DashboardPageObjects dashboardPage) {
            this.loginPage = loginPage;
            this.dashboardPage = dashboardPage;
        }

       

        [Given(@"login into portal")]
        public void GivenLoginIntoPortal()
        {
            loginPage.LoginWithId.Click();
            loginPage.Login(ConfigurationManager.AppSettings["Username"], ConfigurationManager.AppSettings["Password"]);
            dashboardPage.DeclareWFH(ConfigurationManager.AppSettings["WFH"]);
            dashboardPage.CloseStartUpPopUpDialouge();
        }

    }
}
