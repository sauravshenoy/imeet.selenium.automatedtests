using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Interactions;
using NUnit.Framework;
namespace Dude
{
    [TestClass]
    public class Yo
    {
        IWebDriver driver;
        IWebElement ss9;
        IWebElement omg;
        IWebElement upload;
        IWebElement qq;
        IWebElement passforemail;
        string url = "https://accounts.google.com/ServiceLogin?service=mail&passive=true&rm=false&continue=https://mail.google.com/mail/&ss=1&scc=1&ltmpl=default&ltmplcache=2&emr=1&osid=1#identifierm";
        [TestInitialize]
        public void TestSetup()
        {

            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(url);
        }
        [TestCleanup]
        public void Cleanup()
        {
            driver.Quit();
        }

        [TestMethod]
        public void GoogleSignIn()
        {

            ss9 = driver.FindElement(By.CssSelector("#Email"));
            ss9.Click();
            ss9.SendKeys("saurav@looplogic.com");
            driver.FindElement(By.CssSelector("#next")).Click();
            Thread.Sleep(9000);
            passforemail = driver.FindElement(By.CssSelector("#user_email"));
            passforemail.Click();
            passforemail.SendKeys("saurav@looplogic.com");
            passforemail = driver.FindElement(By.CssSelector("#user_password"));
            passforemail.Click();
            passforemail.SendKeys("Ilovecollege1");
            driver.FindElement(By.CssSelector("#user_submit")).Click();
            Thread.Sleep(5000);       
        }
        [TestMethod]
        public void MakingPrezi()
        {
            driver.Navigate().GoToUrl("http://goo.gl/aSY89E");
            Thread.Sleep(5000);
            driver.FindElement(By.CssSelector("body > div.container > div > form > button")).Click();
            Thread.Sleep(5000);
           driver.Navigate().GoToUrl("http://sales.imeet.com/my-channel/Presentations/New");
            Thread.Sleep(8000);
            driver.FindElement(By.CssSelector("#upload-slides-container")).Click();
            Thread.Sleep(5000);
            omg = driver.FindElement(By.CssSelector("#presoTitle"));
            omg.Click();
            omg.SendKeys("My Computer Made This!!");
            Thread.Sleep(7000);
            driver.FindElement(By.CssSelector("#slide-upload > div > form > div:nth-child(4) > label")).Click();
            upload = driver.FindElement(By.CssSelector("#slide-upload-container > p > a"));
            upload.Click();
            upload.SendKeys("C: /Users/Saurav/Downloads/Gauss Gun Presentation.pptx");
            

        }
        [TestMethod]
        public void Amazon()
        {
            driver.Navigate().GoToUrl("http://amazon.com");
            qq = driver.FindElement(By.CssSelector("#twotabsearchtextbox"));
            qq.Click();
            qq.SendKeys("Coding is Fun!");
            Thread.Sleep(1000);
            driver.FindElement(By.CssSelector("#nav-search > form > div.nav-right > div > input")).Click();


        }
    }
}
