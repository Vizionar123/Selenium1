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
using ProbniTest.PageObject;
using Excel = Microsoft.Office.Interop.Excel;
using ProbniTest.Libraries;
using System.CodeDom;

namespace ProbniTest
{
    class Test
    {
        IWebDriver driver;
     [Test] 
     [Category("IQTest")]
     //[TestCase("aaa","aaa")]
     //[TestCase("aaas","aaas")]
     public void TestQa()
     {
            //HomePage naslovna = new HomePage(driver);
           // naslovna.GoToPage();
            //LogPage L;
            //L = naslovna.ClickOnSignIn();
            //naslovna = L.Registration("aaa","aaa");
            //if (naslovna.Welcome !=null)
            //Assert.Pass(); }
            //else { Assert.Fail("nije ispravan unos"); }
            CSVHandler CSV = new CSVHandler();
            Excel.Worksheet Sheet = CSV.OpenCSV(@"C:\Users\Milijana\Desktop\ddt1.csv");
            int rows = Sheet.UsedRange.Rows.Count;
            int columns = Sheet.UsedRange.Columns.Count;
            //TestContext.WriteLine("Redova je:{0}, Kolona je:{1}", rows, columns);
            string username, password,description,expected;
            bool IsExpected = true;
            int pass = 0;
            int fail = 0;
            for(int i=2;i<=rows;i++)
            {
                //TestContext.Write("{0} {1}", Sheet.Cells[i, 1].Value, Sheet.Cells[i, 2].Value);
                username = Sheet.Cells[i, 1].Value;
                password= Sheet.Cells[i, 2].Value;
                expected = Sheet.Cells[i, 3].Value;
                description = Sheet.Cells[i, 4].Value;
                TestContext.Write("{0} expected:({1})",description,expected);
                HomePage naslovna = new HomePage(driver);
                naslovna.GoToPage();
                LogPage L;
                L = naslovna.ClickOnSignIn();
                naslovna = L.Registration(username, password);
                if (naslovna.Welcome !=null)
                {
                    if (expected=="pass")
                    {
                        IsExpected = true;
                        TestContext.Write(" Test is ok!");
                    }
                    else
                    {
                        IsExpected = false;
                        TestContext.Write("Test is not ok!");
                    }
                    naslovna.LC();    
                }
                else
                {
                    if (expected == "fail")
                    {
                        IsExpected = true;
                        TestContext.Write(" Test is ok!");
                    }
                    else
                    {
                        IsExpected = false;
                        TestContext.Write(" Test is not ok!");
                    }
                  
                }
                TestContext.WriteLine();
                TestContext.WriteLine("-----------------------------------------------------------------------------------");
            }

            if (IsExpected ==true)
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail("Some test have unespected results");
            }
                CSV.Close();

     }
           

        
     [SetUp]  
     public void SetUp()
        {
            driver = new FirefoxDriver();
            driver.Manage().Window.Maximize();
        }
    [TearDown]
    public void TearDown()
        {
            driver.Close();
        }
    }
}
