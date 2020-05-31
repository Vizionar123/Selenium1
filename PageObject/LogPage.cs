using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Collections.ObjectModel;
using OpenQA.Selenium.Firefox;
using EC = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace ProbniTest.PageObject
{
    class LogPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        public LogPage(IWebDriver driver)
        {
            this.driver = driver;
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        }
        public IWebElement Ik
        {
            get
            {
                IWebElement element = null;
                try
                {
                    wait.Until(EC.ElementIsVisible(By.Name("username")));
                    element = this.driver.FindElement(By.Name("username"));
                }
                catch(Exception)
                {
                    element = null;
                }
                return element;
            }

        }
        public IWebElement P
        {
            get
            {
                IWebElement element = null;
                try
                {
                    wait.Until(EC.ElementIsVisible(By.Name("password")));
                    element = this.driver.FindElement(By.Name("password"));
                }
                catch (Exception)
                {
                    element = null;
                }
                return element;
            }
        }
        public IWebElement Button
        {
            get
            {
                IWebElement element = null;
                try
                {
                    wait.Until(EC.ElementIsVisible(By.XPath("//input[@name='login']")));
                    element = this.driver.FindElement(By.XPath("//input[@name='login']"));
                }
                catch (Exception)
                {
                    element = null;
                }
                return element;
            }

        }
        public HomePage Registration(string username, string password)
        {
            this.Ik?.SendKeys(username);
            this.P?.SendKeys(password);
            this.Button?.Click();
            //wait.Until(EC.ElementIsVisible(By.XPath("//h2[contains(text(),'Welcome')]")));
            //System.Threading.Thread.Sleep(2000);
            return new HomePage(this.driver);

        }
    }
}
