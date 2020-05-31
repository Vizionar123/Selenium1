using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Collections.ObjectModel;
using OpenQA.Selenium.Firefox;
using EC = SeleniumExtras.WaitHelpers.ExpectedConditions;
using System.Runtime.CompilerServices;


namespace ProbniTest.PageObject
{
    class HomePage
    {
       private IWebDriver driver;
       private WebDriverWait wait;
        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        }
        public void GoToPage()
        {
            this.driver.Navigate().GoToUrl("http://shop.qa.rs/");
           

        }
        public IWebElement SignIn
        {
            get
           {
               IWebElement element = null;
                try
                {
                    wait.Until(EC.ElementIsVisible(By.XPath("//a[@href='/login']")));
                    element = this.driver.FindElement(By.XPath("//a[@href='/login']"));
                }
                catch (Exception)
                { 
                    element = null; 
                }

                return element;
            }


        }
       
           
        public IWebElement Logaut
        {
            get
            {
                IWebElement element = null;
                try
                {
                    wait.Until(EC.ElementIsVisible(By.XPath(" //a[@href='/logout']")));
                    element = driver.FindElement(By.XPath(" //a[@href='/logout']"));
                }
                catch (Exception)
                {
                    element = null;
                }
                return element;

            }
        }
        public IWebElement Welcome
        {
            get
            {
                IWebElement element = null;
                try
                {
                   wait.Until(EC.ElementIsVisible(By.XPath("//h2[contains(text(),'Welcome')]")));
                    element = driver.FindElement(By.XPath("//h2[contains(text(),'Welcome')]"));
                }
                catch (Exception)
                {
                    element = null;
                }
                return element;

            }
        }
        public LogPage ClickOnSignIn()
            {
            this.SignIn.Click();
            wait.Until(EC.ElementIsVisible(By.XPath("//a[contains(text(),'QA')]")));
            //System.Threading.Thread.Sleep(1000);
            return new LogPage(this.driver);
            }
        
    public HomePage LC()
    {
            this.Logaut?.Click();
            wait.Until(EC.ElementIsVisible(By.XPath("//a[@href='/login']")));
            //System.Threading.Thread.Sleep(1000);
            return new HomePage(this.driver);
    }
     public HomePage BackToHome()
        {
            this.driver.Navigate().GoToUrl("http://shop.qa.rs/");
           // wait.Until(EC.ElementIsVisible(By.XPath("//a[@href='/login']")));
            return new HomePage(this.driver);
    }


    //}
}
}

