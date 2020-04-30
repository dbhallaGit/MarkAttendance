using MarkAttendance.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using OpenQA.Selenium.Remote;

using OpenQA.Selenium.Support.UI;
using System.Globalization;

namespace MarkAttendance

{
    [Binding]
    public class BaseClass
    {
        public static IWebDriver driver { get; set; }

        public static String CurrentWindow { get; set; }

        public static WebDriverWait wait { get; set; }

        




        [After]
        public static void closeBrowser()
        {
            driver.Quit();
        }


        [Before]
        [Obsolete]
        public static void GivenInitializeDriver()
        {
           


            if (ConfigurationManager.AppSettings["Server"].ToLower().Equals("docker") && ConfigurationManager.AppSettings["Browser"].ToLower().Equals("chrome"))
            {

                ChromeOptions Options = new ChromeOptions();
                driver = new RemoteWebDriver(new Uri("http://192.168.99.100:4444/wd/hub/"), Options.ToCapabilities());
            }
            else if (ConfigurationManager.AppSettings["Browser"].ToLower().Equals("chrome"))
            {
                driver = new ChromeDriver();
                Console.WriteLine("Driver launched");
                driver.Manage().Window.Maximize();
                String URL = ConfigurationManager.AppSettings["URL"];
                driver.Navigate().GoToUrl(URL);
            }
        }



        public static IWebDriver SwitchToNextWindow()
        {
            List<String> windows = BaseClass.driver.WindowHandles.ToList();

            for (int i = 0; i < windows.Count; i++)
                BaseClass.driver.SwitchTo().Window(windows[i]);
            return driver;
        }



        public static String DayOfWeek()
        {

            DayOfWeek wk = DateTime.Today.DayOfWeek;
            Console.WriteLine("Day of the week " + wk);
            /* DateTime now = DateTime.Now;
             * Console.WriteLine("Today's date: {0}", now.Date);
             Console.WriteLine("Today is {0} day of {1}", now.Day, now.Month);
             Console.WriteLine("Today is {0} day of {1}", now.DayOfYear, now.Year);
             Console.WriteLine("Today's time: {0}", now.TimeOfDay);
             Console.WriteLine("Hour: {0}", now.Hour);
             Console.WriteLine("Minute: {0}", now.Minute);
             Console.WriteLine("Second: {0}", now.Second);
             Console.WriteLine("Millisecond: {0}", now.Millisecond);
             Console.WriteLine("The day of week: {0}", now.DayOfWeek);
             Console.WriteLine("Kind: {0}", now.Kind);  */
            return wk.ToString().ToLower();

        }

        public static String getCurrenthour()
        {
            DateTime now = DateTime.Now;
            Console.WriteLine($"Time: {now.TimeOfDay.Hours}");
            return now.TimeOfDay.Hours.ToString();
        }

        public static String getCurrentWindow()
        {
            CurrentWindow = BaseClass.driver.CurrentWindowHandle;
            return CurrentWindow;
        }

        public static void clickElementByReplaceText(IWebElement ele, String valueToBeReplaced, String text)
        {
            String newXpath = (ele.ToString().Replace(valueToBeReplaced, text)).Replace("By.XPath: ", " ");
            IWebElement newElement = driver.FindElement(By.XPath(newXpath));
            newElement.Click();
        }

        public void ClickElementWithJS(IWebElement ele)
        {
            Console.WriteLine("Element to be clicked: " + ele.ToString());
            IJavaScriptExecutor JS = (IJavaScriptExecutor)driver;
            JS.ExecuteScript("arguments[0].click(); ", ele);

        }

        public void ClickElement(IWebElement ele)
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(Convert.ToInt32(ConfigurationManager.AppSettings["TimeOut"])));
            try
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(ele)).Click();
            }
            catch (Exception e)
            {

                Console.WriteLine("Element not found");
                Console.Write(e.Message);

            }

        }
    }
}
