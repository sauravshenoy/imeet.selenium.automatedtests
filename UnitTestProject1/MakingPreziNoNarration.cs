using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Interactions;
using NUnit.Framework;
using System.Linq;
using System.Runtime;
using Toolkit.Core.Utils;

namespace Dude
{
    [TestClass]
    public class FirstSeleniumTesting
    {
        IWebDriver driver;
        IWebElement prezititle;
        IWebElement upload;

        [TestInitialize]
        public void TestSetup()
       {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://goo.gl/aSY89E");
            Thread.Sleep(2000);
            driver.FindElement(By.CssSelector("body > div.container > div > form > button")).Click();
            Thread.Sleep(2000);
            driver.Navigate().GoToUrl("http://sales.imeet.com/my-channel/Presentations/New");
            Thread.Sleep(2000);
        }
        [TestCleanup]
        public void Cleanup()
        {
            driver.Quit();
        }

        [TestMethod]
        public void NoNarrationPreziUpload()
        {
            driver.FindElement(By.CssSelector("#upload-slides-container")).Click();
            Thread.Sleep(3000);
            prezititle = driver.FindElement(By.CssSelector("#presoTitle"));
            prezititle.Click();
            prezititle.SendKeys("My Computer Made This!!");
            Thread.Sleep(3000);

            //from here there are two possible paths

            driver.FindElement(By.CssSelector("#slide-upload > div > form > div:nth-child(4) > label")).Click();
            driver.FindElement(By.CssSelector("#slide-upload-container > p > a")).SendKeys("C: \\Users\\Saurav\\Downloads\\GGPrezi.pptx"); 
            Thread.Sleep(5000);
        }
        [TestMethod]
        public void VideoUpload()
        {
            driver.FindElement(By.CssSelector("#tool-selection > div:nth-child(2) > div:nth-child(2) > div > h3")).Click();
            Thread.Sleep(2000);
            prezititle= driver.FindElement(By.CssSelector("# presoTitle"));
            prezititle.Click();
            prezititle.SendKeys("ComputerVidUpload");

        }
        [TestMethod]
        public void PreziUploadWithNarration()
        {

        }
        [TestMethod]
        public void RandomTest()
        {
            driver.Navigate().GoToUrl("http://www.megafileupload.com/");
            Thread.Sleep(3000);
            upload = driver.FindElement(By.CssSelector(".slider-btn"));
            upload.SendKeys("C: \\Users\\Saurav\\Downloads\\GGPrezi.pptx");
            Thread.Sleep(10000);
           
        }
    }
}