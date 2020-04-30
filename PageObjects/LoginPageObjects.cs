using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkAttendance.PageObjects
{
    public class LoginPageObjects:BaseClass
    {
        [Obsolete]
        public LoginPageObjects() {
            PageFactory.InitElements(driver, this); 
        }

        [FindsBy(How=How.XPath,Using = "//input[@id='btnLogin']")]
        public IWebElement LoginWithId { get; set; }

        [FindsBy(How = How.XPath,Using = "//input[@name='txtEmpCode']")]
        public IWebElement EnterEmail { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@name='txtPassword']")]
        public IWebElement EnterPassword { get; set; }

        
        [FindsBy(How = How.XPath, Using = "//input[@name='imgBtnOK']")]
        public IWebElement LoginBtn { get; set; }

        public void Login(String username, String password)
        {
            EnterEmail.SendKeys(username);
            EnterPassword.SendKeys(password);
            LoginBtn.Click();

        }



    }
}
