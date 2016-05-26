using System;
using System.Threading;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Interactions;
using NUnit.Framework;
using System.Linq;
using System.Runtime;
using Toolkit.Core.Utils;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Dude
{
    [TestClass]
    public class FirstSeleniumTesting
    {
        IWebDriver driver;
        IWebElement prezititle;
        IWebElement element;
        IWebElement dragndrop;
        IWebElement advancedanalytics;
        IWebElement question;
        IWebElement emailrecipient;
        String NameOfYourPresentation;
        String FBemail = "saurav@looplogic.com";
        String FBPass = "Ilovecollege1";
        String nuofseconds = "60";
        int questionnumbers = 3;
        int arewethereyet = 0;
        int ctaslidenumber = 4;
        String Cssforctaslide = "#chapter > option:nth-child(";

        [TestInitialize]
        public void TestSetup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://goo.gl/aSY89E");
            Thread.Sleep(2000);
            driver.FindElement(By.CssSelector("body > div.container > div > form > button")).Click();
            Thread.Sleep(2000);
        }
        [TestCleanup]
        public void Cleanup()
        {
            driver.Quit();
        }

        [TestMethod]
        public void CreatePrezi()
        {
            driver.Navigate().GoToUrl("http://sales.imeet.com/my-channel/Presentations/New");
            driver.FindElement(By.CssSelector("#upload-slides-container")).Click();
            Thread.Sleep(3000);
            prezititle = driver.FindElement(By.CssSelector("#presoTitle"));
            Thread.Sleep(2000);
            //pick a title for your presentation
            NameOfYourPresentation = "My Computer Made This!!";
            prezititle.SendKeys(NameOfYourPresentation);
            Thread.Sleep(3000);
            //upoad the presentation
            //SendKeys method only seems to work sometimes, but there is no work around to this, 
            //it is just a problem with Selenium Webdriver as they are not friendly to non-browser windows
            driver.FindElement(By.CssSelector("#slide-upload > div > form > div:nth-child(4) > label > input[type=\"radio\"]")).Click();
            Thread.Sleep(1350);
            IList<IWebElement> uploadbutton = driver.FindElements(By.CssSelector("#slide-upload > div > form > div:nth-child(2) > input[type=\"hidden\"]:nth-child(5)"));
            if (uploadbutton.Count > 0)
            {
                Console.WriteLine("Getting Closer Bro!");
                IWebElement almost = uploadbutton.First();
                almost.SendKeys(@"C:\Users\Saurav\Documents\hi");
            }
            else
            {
                driver.Quit();
            }
            //clicks continue

            driver.FindElement(By.CssSelector("div.actions:nth-child(7) > button:nth-child(2)")).Click();
            Thread.Sleep(40000);
            //if you want to see the preview
            driver.FindElement(By.CssSelector("body > div.body-bg > div > div.container > div.row.details-header > div > div.col-xs-12.col-sm-8 > div > p:nth-child(3) > a"));
        }
        [TestMethod]
        public void WasPreziCreated()
        {
            //based on if statement, if it does upload successful line is printed, otherwise failure is notified
            if (driver.FindElements(By.PartialLinkText(NameOfYourPresentation)).Count > 0)
            {
                Console.WriteLine("Presentation was successfully uploaded!");
            }
            else
            {
                Console.WriteLine("Presentation was not created :(");
            }
        }
        [TestMethod]
        public void EmailShare()
        {
            driver.Navigate().GoToUrl("https://sales.imeet.com/my-channel/my-computer-made-this/edit");
            Thread.Sleep(5000);
            //if you want to share the presentation
            driver.FindElement(By.CssSelector("#edit-tabs > ul > li:nth-child(3) > a")).Click();
            //Enter Your Name
            String whatsyourname = "Saurav";
            IWebElement name = driver.FindElement(By.CssSelector("#share-email > form > fieldset > div.row > div:nth-child(1) > div > input"));
            name.Clear();
            Thread.Sleep(10000);
            name.SendKeys(whatsyourname);
            //enter the email you are sending the shared presentation with
            String youremail = "saurav@looplogic.com";
            IWebElement emailshare = driver.FindElement(By.CssSelector("#share-email > form > fieldset > div.row > div:nth-child(2) > div > input"));
            emailshare.Clear();
            emailshare.SendKeys(youremail);
            emailrecipient = driver.FindElement(By.CssSelector("#share-email > form > fieldset > div.form-group > div > div > textarea"));
            //enter number of recipients you are sending email to
            int numberofrecipients = 1;
            //recipients email addresse(s)
            String recipient1 = "sauravshenoy9@gmail.com";
            String recipient2 = "Recipient2";
            String recipient3 = "Recipient3";
            String recipient4 = "Recipient4";
            String recipient5 = "Recipient5";
            String recipient6 = "Recipient6";
            String recipient7 = "Recipient7";
            String recipient8 = "Recipient8";
            String recipient9 = "Recipient9";
            String recipient10 = "Recipient10";
            switch (numberofrecipients)
            {
                case 1:
                    emailrecipient.SendKeys(recipient1);
                    emailrecipient.SendKeys(Keys.Return);
                    break;
                case 2:
                    emailrecipient.SendKeys(recipient1);
                    emailrecipient.SendKeys(Keys.Return);
                    emailrecipient.SendKeys(recipient2);
                    emailrecipient.SendKeys(Keys.Return);
                    break;
                case 3:
                    emailrecipient.SendKeys(recipient1);
                    emailrecipient.SendKeys(Keys.Return);
                    emailrecipient.SendKeys(recipient2);
                    emailrecipient.SendKeys(Keys.Return);
                    emailrecipient.SendKeys(recipient3);
                    emailrecipient.SendKeys(Keys.Return);
                    break;
                case 4:
                    emailrecipient.SendKeys(recipient1);
                    emailrecipient.SendKeys(Keys.Return);
                    emailrecipient.SendKeys(recipient2);
                    emailrecipient.SendKeys(Keys.Return);
                    emailrecipient.SendKeys(recipient3);
                    emailrecipient.SendKeys(Keys.Return);
                    emailrecipient.SendKeys(recipient4);
                    emailrecipient.SendKeys(Keys.Return);
                    break;
                case 5:
                    emailrecipient.SendKeys(recipient1);
                    emailrecipient.SendKeys(Keys.Return);
                    emailrecipient.SendKeys(recipient2);
                    emailrecipient.SendKeys(Keys.Return);
                    emailrecipient.SendKeys(recipient3);
                    emailrecipient.SendKeys(Keys.Return);
                    emailrecipient.SendKeys(recipient4);
                    emailrecipient.SendKeys(Keys.Return);
                    emailrecipient.SendKeys(recipient5);
                    emailrecipient.SendKeys(Keys.Return);
                    break;
                case 6:
                    emailrecipient.SendKeys(recipient1);
                    emailrecipient.SendKeys(Keys.Return);
                    emailrecipient.SendKeys(recipient2);
                    emailrecipient.SendKeys(Keys.Return);
                    emailrecipient.SendKeys(recipient3);
                    emailrecipient.SendKeys(Keys.Return);
                    emailrecipient.SendKeys(recipient4);
                    emailrecipient.SendKeys(Keys.Return);
                    emailrecipient.SendKeys(recipient5);
                    emailrecipient.SendKeys(Keys.Return);
                    emailrecipient.SendKeys(recipient6);
                    emailrecipient.SendKeys(Keys.Return);
                    break;
                case 7:
                    emailrecipient.SendKeys(recipient1);
                    emailrecipient.SendKeys(Keys.Return);
                    emailrecipient.SendKeys(recipient2);
                    emailrecipient.SendKeys(Keys.Return);
                    emailrecipient.SendKeys(recipient3);
                    emailrecipient.SendKeys(Keys.Return);
                    emailrecipient.SendKeys(recipient4);
                    emailrecipient.SendKeys(Keys.Return);
                    emailrecipient.SendKeys(recipient5);
                    emailrecipient.SendKeys(Keys.Return);
                    emailrecipient.SendKeys(recipient6);
                    emailrecipient.SendKeys(Keys.Return);
                    emailrecipient.SendKeys(recipient7);
                    emailrecipient.SendKeys(Keys.Return);
                    break;
                case 8:
                    emailrecipient.SendKeys(recipient1);
                    emailrecipient.SendKeys(Keys.Return);
                    emailrecipient.SendKeys(recipient2);
                    emailrecipient.SendKeys(Keys.Return);
                    emailrecipient.SendKeys(recipient3);
                    emailrecipient.SendKeys(Keys.Return);
                    emailrecipient.SendKeys(recipient4);
                    emailrecipient.SendKeys(Keys.Return);
                    emailrecipient.SendKeys(recipient5);
                    emailrecipient.SendKeys(Keys.Return);
                    emailrecipient.SendKeys(recipient6);
                    emailrecipient.SendKeys(Keys.Return);
                    emailrecipient.SendKeys(recipient7);
                    emailrecipient.SendKeys(Keys.Return);
                    emailrecipient.SendKeys(recipient8);
                    emailrecipient.SendKeys(Keys.Return);
                    break;
                case 9:
                    emailrecipient.SendKeys(recipient1);
                    emailrecipient.SendKeys(Keys.Return);
                    emailrecipient.SendKeys(recipient2);
                    emailrecipient.SendKeys(Keys.Return);
                    emailrecipient.SendKeys(recipient3);
                    emailrecipient.SendKeys(Keys.Return);
                    emailrecipient.SendKeys(recipient4);
                    emailrecipient.SendKeys(Keys.Return);
                    emailrecipient.SendKeys(recipient5);
                    emailrecipient.SendKeys(Keys.Return);
                    emailrecipient.SendKeys(recipient6);
                    emailrecipient.SendKeys(Keys.Return);
                    emailrecipient.SendKeys(recipient7);
                    emailrecipient.SendKeys(Keys.Return);
                    emailrecipient.SendKeys(recipient8);
                    emailrecipient.SendKeys(Keys.Return);
                    emailrecipient.SendKeys(recipient9);
                    emailrecipient.SendKeys(Keys.Return);
                    break;
                case 10:
                    emailrecipient.SendKeys(recipient1);
                    emailrecipient.SendKeys(Keys.Return);
                    emailrecipient.SendKeys(recipient2);
                    emailrecipient.SendKeys(Keys.Return);
                    emailrecipient.SendKeys(recipient3);
                    emailrecipient.SendKeys(Keys.Return);
                    emailrecipient.SendKeys(recipient4);
                    emailrecipient.SendKeys(Keys.Return);
                    emailrecipient.SendKeys(recipient5);
                    emailrecipient.SendKeys(Keys.Return);
                    emailrecipient.SendKeys(recipient6);
                    emailrecipient.SendKeys(Keys.Return);
                    emailrecipient.SendKeys(recipient7);
                    emailrecipient.SendKeys(Keys.Return);
                    emailrecipient.SendKeys(recipient8);
                    emailrecipient.SendKeys(Keys.Return);
                    emailrecipient.SendKeys(recipient9);
                    emailrecipient.SendKeys(Keys.Return);
                    emailrecipient.SendKeys(recipient10);
                    emailrecipient.SendKeys(Keys.Return);
                    break;
            }
            //to edit email
            driver.FindElement(By.CssSelector("#share-email > form > fieldset > div:nth-child(8) > button.btn.btn-default")).Click();
            driver.FindElement(By.CssSelector("#share-email > form > fieldset > div:nth-child(8) > button.btn.btn-primary")).SendKeys("Whatever you want to write yo");
            Thread.Sleep(10000);
            //send email with shared presentation
            driver.FindElement(By.CssSelector("#share-email > form > fieldset > div:nth-child(8) > button.btn.btn-primary")).Click();
            Thread.Sleep(15000);
            if (driver.FindElements(By.CssSelector("#share-email > form > fieldset > div.alert.alert-success.alert-dismissible > span")).Count > 0)
            {
                Console.WriteLine("Email was successfully shared!");
            }
            else
            {
                Console.WriteLine("Email was not shared!");
            }
        }
        [TestMethod]
        public void ShareThruFB()
        {
            driver.Navigate().GoToUrl("https://sales.imeet.com/my-channel/my-computer-made-this/edit");
            //if you want to share the presentation
            driver.FindElement(By.CssSelector("#edit-tabs > ul > li:nth-child(3) > a > span")).Click();
            Console.WriteLine(driver.CurrentWindowHandle);
            driver.FindElement(By.CssSelector("#partner-imeet-share > nav > ul > li:nth-child(3) > a")).Click();
            driver.FindElement(By.CssSelector("#partner-imeet-share-social > form > fieldset > div > a:nth-child(2)")).Click();
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            Thread.Sleep(5000);
           driver.FindElement(By.CssSelector("#email")).SendKeys("omgitworked!!!!");
            Console.WriteLine(driver.WindowHandles.Last());
            Thread.Sleep(10000);
        }
        [TestMethod]
        public void FBConfirm()
        {
            driver.FindElement(By.CssSelector("#share-email > form > fieldset > div:nth-child(8) > button.btn.btn-default")).Click();
            driver.FindElement(By.CssSelector("#share-email > form > fieldset > div:nth-child(8) > button.btn.btn-primary")).SendKeys("Whatever you want to write yo");
            Thread.Sleep(10000);
            //send email with shared presentation
            driver.FindElement(By.CssSelector("#share-email > form > fieldset > div:nth-child(8) > button.btn.btn-primary")).Click();
            Thread.Sleep(15000);
            if (driver.FindElements(By.CssSelector("#share-email > form > fieldset > div.alert.alert-success.alert-dismissible > span")).Count > 0)
            {
                Console.WriteLine("Email was successfully shared!");
            }
            else
            {
                Console.WriteLine("Email was not shared!");
            }
        }
        [TestMethod]
        public void ShareThruTwitter()
        {
            driver.Navigate().GoToUrl("https://sales.imeet.com/my-channel/my-computer-made-this/edit");
            //if you want to share the presentation
            driver.FindElement(By.CssSelector("#edit-tabs > ul > li:nth-child(3) > a > span")).Click();
            driver.FindElement(By.CssSelector("#partner-imeet-share > nav > ul > li:nth-child(3) > a")).Click();
            Console.WriteLine(driver.CurrentWindowHandle);
            Thread.Sleep(5000);
            driver.FindElement(By.CssSelector("#partner-imeet-share-social > form > fieldset > div > a:nth-child(1) > i")).Click();
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            //sign in
            Thread.Sleep(20000);
            driver.FindElement(By.CssSelector("#update-form > div.ft > fieldset.sign-in > div.row.user > label")).SendKeys("your username or phone number");
            driver.FindElement(By.CssSelector("#password")).SendKeys("Your Password");
            //post to Twitter
            driver.FindElement(By.CssSelector("#update-form > div.ft > fieldset.submit > input.button.selected.submit")).Click();
        }
        [TestMethod]
        public void TwitterConfirmation()
        {

        }
        [TestMethod]
        public void ShareThruGPlus()
        {
            //Google Plus
            driver.FindElement(By.CssSelector("#partner-imeet-share-social > form > fieldset > div > a:nth-child(4) > i"));
            driver.SwitchTo().ActiveElement();
            //sign in
            driver.FindElement(By.Id("Email")).SendKeys("gmail");
            driver.FindElement(By.Id("Next")).Click();
            driver.FindElement(By.Id("Passwd")).SendKeys("password");
            driver.FindElement(By.Id("SignIn")).Click();
            //post 
            driver.FindElement(By.CssSelector("body > div.ub-PNa > div.ub.zja.mh > div.cc > table > tbody > tr > td.bI > div.d-k-l.b-c.b-c-Ba.qy.jt")).Click();
        }
           [TestMethod]
            public void ShareThruLinketon()
        {
            //Linketon
            driver.FindElement(By.CssSelector("#partner-imeet-share-social > form > fieldset > div > a:nth-child(3) > i"));
            driver.SwitchTo().ActiveElement();
                //log in
                driver.FindElement(By.Id("session_key-login")).SendKeys("username");
                driver.FindElement(By.Id("session_password-login")).SendKeys("password");
                driver.FindElement(By.Id("btn-primary")).Click();
                driver.FindElement(By.CssSelector("#yui-gen4 > div.submit-container > input")).Click();
        }
        [TestMethod]
        public void CustomBasics()
        {
            driver.Navigate().GoToUrl("https://sales.imeet.com/my-channel/my-computer-made-this/edit");
            driver.FindElement(By.CssSelector("#edit-tabs > ul > li:nth-child(1) > a")).Click();
            Thread.Sleep(3000);
            //to change the name of the presentation
            IWebElement NewTitle = driver.FindElement(By.Id("videoTitleInput"));
            NewTitle.Clear();
            String Title2 = "My Computer Made This Seriously!";
            NewTitle.SendKeys(Title2);
            Thread.Sleep(3000);
            driver.FindElement(By.CssSelector("#videoDescriptionInput")).SendKeys("Desciption of Your Presentation");
            driver.FindElement(By.CssSelector("#videoTitleInput")).Click();
            Thread.Sleep(4000);
            //privacy is true if presentation is public
            bool privacy = true;
            if (privacy == false)
            {
                Console.WriteLine("Presentation remains private");
            }
            else
            {
                // NOTE TO SELF ANOTHER BUG BC PUBLIC AND PRIVATE HAVE SAME PATH(XPATH/CSS/ID)
                driver.FindElement(By.CssSelector("#PrivacyOption")).Click();
                Console.WriteLine("Presentation has been made public.");
            }
            Thread.Sleep(3000);
            if (driver.FindElements(By.PartialLinkText(Title2)).Count > 0)
            {
                Console.WriteLine("Title and Description were updated!");
            }
            else
            {
                Console.WriteLine("Title and Description were probably updated.");
            }
                 
        }
        [TestMethod]
        public void CustomAppearance()
        {
            driver.Navigate().GoToUrl("https://sales.imeet.com/my-channel/my-computer-made-this/edit");
            driver.FindElement(By.CssSelector("#edit-tabs > ul > li:nth-child(1) > a")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.CssSelector("#partner-imeet-customize > nav > ul > li:nth-child(2) > a")).Click();
            Thread.Sleep(20000); 
            //if you want to upload a thumbnail externally, make this value true, otherwise make it false and pick which one you want from the slides you have
           bool thumbnailexternal = false;
            if (thumbnailexternal == true)
            {
                driver.FindElement(By.Id("ThumbnailUpload")).SendKeys("Local Path of Picture");
            }
            else
            {
                driver.FindElement(By.CssSelector("#thumbUploadContainer > div > button")).Click();
                Thread.Sleep(5000);
                //enter number of slide you want to be the thumbnail of this presentation
                int thumbnailslidenumber = 2;
                String whichslideisthethumbnail = "#thumbUploadContainer > div > ul > li:nth-child(" + thumbnailslidenumber + ") > a > img";
                driver.FindElement(By.CssSelector(whichslideisthethumbnail)).Click();
                Thread.Sleep(5000);
            }
        }
        [TestMethod]
        public void AddAttatchments()
        {
            driver.Navigate().GoToUrl("https://sales.imeet.com/my-channel/my-computer-made-this/edit");
            driver.FindElement(By.CssSelector("#edit-tabs > ul > li:nth-child(1) > a")).Click();
            driver.FindElement(By.CssSelector("#partner-imeet-customize > nav > ul > li:nth-child(3) > a")).Click();
            //uploading an external document to go along with presentation
            driver.FindElement(By.CssSelector("#attachments > div.drag-drop > p:nth-child(1) > a")).SendKeys("Local Path of Document"); 
        }
        [TestMethod]
        public void CallsToActionLink()
        {
            driver.Navigate().GoToUrl("https://sales.imeet.com/my-channel/my-computer-made-this/edit");
            driver.FindElement(By.CssSelector("#edit-tabs > ul > li:nth-child(1) > a")).Click();
            Thread.Sleep(4000);
            driver.FindElement(By.CssSelector("#partner-imeet-customize > nav > ul > li:nth-child(4) > a")).Click();
            Thread.Sleep(3000);
            while (driver.FindElements(By.CssSelector("#cta > div > table > tbody > tr:nth-child(2) > td.type")).Count != 0)
            {
               if  (driver.FindElements(By.CssSelector("#cta > div > table > tbody > tr:nth-child(2) > td:nth-child(3) > a.delete")).Count > 0)
                {
                    driver.FindElement(By.CssSelector("#cta > div > table > tbody > tr:nth-child(2) > td:nth-child(3) > a.delete")).Click();
                }
               else
                {
                    Console.WriteLine("CTA can not currently be deleted.");
                }
            }
            Thread.Sleep(20000);
            driver.FindElement(By.CssSelector("#dropdownMenu1")).Click();
            Thread.Sleep(4000);
            driver.FindElement(By.CssSelector("#cta > div > div.heading > div.dropdown.open > ul > li:nth-child(1) > a")).Click();
            Thread.Sleep(2000);
            //If you want the user to not be able to skip the call to action you are going to make, make faoolowing value false
            bool skippable = true;
            if (skippable == false)
            {
                driver.FindElement(By.Name("isskippable")).Click();
                Console.WriteLine("Viewer Is now forced to look at CTA");
            }
            else
            {
                Console.WriteLine("CTA is still skippable");
            }
            Thread.Sleep(3000);
            driver.FindElement(By.CssSelector("#cta > div > div.item > form > div.row > div.col-sm-8 > div.cta > div:nth-child(2) > input")).SendKeys("Test Link");
            Thread.Sleep(3000);
            driver.FindElement(By.CssSelector("#cta > div > div.item > form > div.row > div.col-sm-8 > div.cta > div:nth-child(3) > input")).SendKeys("https://espn.com");
            Thread.Sleep(3000);
            driver.FindElement(By.CssSelector("#cta > div > div.item > form > div.row > div.col-sm-8 > fieldset:nth-child(5) > div > div:nth-child(1) > div > div > input")).SendKeys(nuofseconds);
            Thread.Sleep(2000);
            //if you want to add the CTA sometime during the presentation, make the following value true; if you want it at the end make it false
            bool endorduring = true;
            if (endorduring == true)
            {
                Thread.Sleep(3000);
                driver.FindElement(By.CssSelector("#cta > div > div.item > form > div.row > div.col-sm-8 > fieldset:nth-child(4) > div > div:nth-child(1)")).Click();
                Thread.Sleep(3000);
                driver.FindElement(By.CssSelector("#chapter")).Click();
                Thread.Sleep(3000);
                ctaslidenumber = ctaslidenumber++;
                Cssforctaslide = Cssforctaslide + ctaslidenumber + ")";
                driver.FindElement(By.CssSelector(Cssforctaslide)).Click();
            }
            else
            {
                Thread.Sleep(3000);
                driver.FindElement(By.PartialLinkText("completion")).Click();
            }
            Thread.Sleep(3000);
            driver.FindElement(By.CssSelector("#cta > div > div.item > form > div.actionbar > button.btn.btn-primary")).Click();
            Thread.Sleep(3000);
            if (driver.FindElements(By.CssSelector("#cta > div > table > tbody > tr:nth-child(2) > td.type")).Count > 0)
            {
                Console.WriteLine("CTA Link was successfully added!");   
            }
            else
            {
                Console.WriteLine("CTA Link was not successfully added.");
            }
        }
        [TestMethod]
        public void CallstoActionButton()
        {
            driver.Navigate().GoToUrl("https://sales.imeet.com/my-channel/my-computer-made-this/edit");
            driver.FindElement(By.CssSelector("#edit-tabs > ul > li:nth-child(1) > a")).Click();
            Thread.Sleep(4000);
            driver.FindElement(By.CssSelector("#partner-imeet-customize > nav > ul > li:nth-child(4) > a")).Click();
            Thread.Sleep(3000);
            while (driver.FindElements(By.CssSelector("#cta > div > table > tbody > tr:nth-child(2) > td.type")).Count != 0)
            {
                if (driver.FindElements(By.CssSelector("#cta > div > table > tbody > tr:nth-child(2) > td:nth-child(3) > a.delete")).Count > 0)
                {
                    driver.FindElement(By.CssSelector("#cta > div > table > tbody > tr:nth-child(2) > td:nth-child(3) > a.delete")).Click();
                }
                else
                {
                    Console.WriteLine("Either CTA can not currently be deleted or is there no CTA in this presentation yet.");
                }
            }
            Thread.Sleep(30000);
            driver.FindElement(By.CssSelector("#dropdownMenu1")).Click();
            Thread.Sleep(4000);
            driver.FindElement(By.CssSelector("#cta > div > div.heading > div.dropdown.open > ul > li:nth-child(2) > a")).Click();
            Thread.Sleep(2000);
            //To allow user to skip CTA, make this variable true
            bool skippable = true;
            if (skippable == false)
            {
                driver.FindElement(By.Name("isskippable")).Click();
                Console.WriteLine("Viewer Is now forced to look at CTA");
            }
            else
            {
                Console.WriteLine("CTA is still skippable");
            }
            Thread.Sleep(3000);
            driver.FindElement(By.CssSelector("#cta > div > div.item > form > div.row > div.col-sm-8 > div.cta > div:nth-child(2) > input")).SendKeys("Name");
            Thread.Sleep(3000);
            driver.FindElement(By.CssSelector("#cta > div > div.item > form > div.row > div.col-sm-8 > div.cta > div:nth-child(3) > input")).SendKeys("https://amazon.com");
            Thread.Sleep(3000);
            driver.FindElement(By.CssSelector("#cta > div > div.item > form > div.row > div.col-sm-8 > fieldset:nth-child(5) > div > div:nth-child(1) > div > div > input")).SendKeys(nuofseconds);
            Thread.Sleep(2000);
            //if you want to add the CTA sometime during the presentation, make the following value true; if you want it at the end make it false
            bool endorduring = true;
            if (endorduring == true)
            {
                Thread.Sleep(3000);
                driver.FindElement(By.CssSelector("#cta > div > div.item > form > div.row > div.col-sm-8 > fieldset:nth-child(4) > div > div:nth-child(1)")).Click();
                Thread.Sleep(3000);
                driver.FindElement(By.CssSelector("#chapter")).Click();
                Thread.Sleep(3000);
                ctaslidenumber = ctaslidenumber++;
                Cssforctaslide = Cssforctaslide + ctaslidenumber + ")";
                driver.FindElement(By.CssSelector(Cssforctaslide)).Click();
            }
            else
            {
                Thread.Sleep(3000);
                driver.FindElement(By.PartialLinkText("radio")).Click();
            }
            Thread.Sleep(3000);
            driver.FindElement(By.CssSelector("#cta > div > div.item > form > div.actionbar > button.btn.btn-primary")).Click();
            Thread.Sleep(3000);
            if (driver.FindElements(By.CssSelector("#cta > div > table > tbody > tr:nth-child(2) > td.type")).Count > 0)
            {
                Console.WriteLine("CTA Button was successfully added!");
            }
            else
            {
                Console.WriteLine("CTA Button was not successfully added.");
            }
        }
        [TestMethod]
        public void CallstoActionHTMLOverlay()
        {
            driver.Navigate().GoToUrl("https://sales.imeet.com/my-channel/my-computer-made-this/edit");
            driver.FindElement(By.CssSelector("#edit-tabs > ul > li:nth-child(1) > a")).Click();
            Thread.Sleep(4000);
            driver.FindElement(By.CssSelector("#partner-imeet-customize > nav > ul > li:nth-child(4) > a")).Click();
            Thread.Sleep(3000);
            while (driver.FindElements(By.CssSelector("#cta > div > table > tbody > tr:nth-child(2) > td.type")).Count != 0)
            {
                if (driver.FindElements(By.CssSelector("#cta > div > table > tbody > tr:nth-child(2) > td:nth-child(3) > a.delete")).Count > 0)
                {
                    Thread.Sleep(1000);
                    driver.FindElement(By.CssSelector("#cta > div > table > tbody > tr:nth-child(2) > td:nth-child(3) > a.delete")).Click();
                    Thread.Sleep(1000);
                }
                else
                {
                    Console.WriteLine("CTA can not currently be deleted.");
                }
            }
            Thread.Sleep(30000);
            driver.FindElement(By.CssSelector("#dropdownMenu1")).Click();
            Thread.Sleep(4000);
            driver.FindElement(By.CssSelector("#cta > div > div.heading > div.dropdown.open > ul > li:nth-child(3) > a")).Click();
            Thread.Sleep(2000);
            //If you want the user to not be able to skip the call to action you are going to make, make faoolowing value false
            bool skippable = true;
            if (skippable == false)
            {
                driver.FindElement(By.Name("isskippable")).Click();
                Console.WriteLine("Viewer Is now forced to look at CTA");
            }
            else
            {
                Console.WriteLine("CTA is still skippable");
            }
            Thread.Sleep(3000);
            driver.FindElement(By.CssSelector("#cta > div > div.item > form > div.row > div.col-sm-8 > div.cta > div:nth-child(2) > input")).SendKeys("Name");
            Thread.Sleep(3000);
            driver.FindElement(By.CssSelector("#cta > div > div.item > form > div.row > div.col-sm-8 > div.cta > div:nth-child(4) > textarea")).SendKeys("Whatever you want to write in the HTML Overlay");
            Thread.Sleep(3000);
            driver.FindElement(By.CssSelector("#cta > div > div.item > form > div.row > div.col-sm-8 > fieldset:nth-child(5) > div > div:nth-child(1) > div > div > input")).SendKeys(nuofseconds);
            Thread.Sleep(2000);
            //if you want to add the CTA sometime during the presentation, make the following value true; if you want it at the end make it false
            bool endorduring = true;
            if (endorduring == true)
            {
                Thread.Sleep(3000);
                driver.FindElement(By.CssSelector("#cta > div > div.item > form > div.row > div.col-sm-8 > fieldset:nth-child(4) > div > div:nth-child(1)")).Click();
                Thread.Sleep(3000);
                driver.FindElement(By.CssSelector("#chapter")).Click();
                Thread.Sleep(3000);
                ctaslidenumber = ctaslidenumber++;
                Cssforctaslide = Cssforctaslide + ctaslidenumber + ")";
                driver.FindElement(By.CssSelector(Cssforctaslide)).Click();
            }
            else
            {
                Thread.Sleep(3000);
                driver.FindElement(By.PartialLinkText("completion")).Click();
            }
            Thread.Sleep(3000);
            driver.FindElement(By.CssSelector("#cta > div > div.item > form > div.actionbar > button.btn.btn-primary")).Click();
            Thread.Sleep(3000);
            if (driver.FindElements(By.CssSelector("#cta > div > table > tbody > tr:nth-child(2) > td.type")).Count > 0)
            {
                Console.WriteLine("CTA HTMLOverlay was successfully added!");
            }
            else
            {
                Console.WriteLine("CTA was not successfully added.");
            }
        }
        [TestMethod]
        public void CallsToActionPoll()
        {
            driver.Navigate().GoToUrl("https://sales.imeet.com/my-channel/my-computer-made-this/edit");
            driver.FindElement(By.CssSelector("#edit-tabs > ul > li:nth-child(1) > a")).Click();
            Thread.Sleep(4000);
            driver.FindElement(By.CssSelector("#partner-imeet-customize > nav > ul > li:nth-child(4) > a")).Click();
            Thread.Sleep(3000);
            while (driver.FindElements(By.CssSelector("#cta > div > table > tbody > tr:nth-child(2) > td.type")).Count != 0)
            {
                if (driver.FindElements(By.CssSelector("#cta > div > table > tbody > tr:nth-child(2) > td:nth-child(3) > a.delete")).Count > 0)
                {
                    driver.FindElement(By.CssSelector("#cta > div > table > tbody > tr:nth-child(2) > td:nth-child(3) > a.delete")).Click();
                }
                else
                {
                    Console.WriteLine("CTA can not currently be deleted.");
                }
            }
            Thread.Sleep(20000);
            driver.FindElement(By.CssSelector("#dropdownMenu1")).Click();
            Thread.Sleep(4000);
            driver.FindElement(By.CssSelector("#cta > div > div.heading > div.dropdown.open > ul > li:nth-child(4) > a")).Click();
            Thread.Sleep(2000);
            //If you want the user to not be able to skip the call to action you are going to make, make faoolowing value false
            bool skippable = true;
            if (skippable == false)
            {
                driver.FindElement(By.Name("isskippable")).Click();
                Console.WriteLine("Viewer Is now forced to look at CTA");
            }
            else
            {
                Console.WriteLine("CTA is still skippable");
            }
            Thread.Sleep(3000);
            driver.FindElement(By.CssSelector("#cta > div > div.item > form > div.row > div.col-sm-8 > div.question > div:nth-child(1) > textarea")).SendKeys("Question");
            Thread.Sleep(3000);
            //if you want poll to have a single answer, make this true
            bool singleormultiple = true;
            if (singleormultiple == false)
            {
                driver.FindElement(By.CssSelector("#cta > div > div.item > form > div.row > div.col-sm-8 > div.question > div:nth-child(3) > select")).Click();
                driver.FindElement(By.CssSelector("#cta > div > div.item > form > div.row > div.col-sm-8 > div.question > div:nth-child(3) > select > option:nth-child(2)")).Click();
                Console.WriteLine("User can pick multiple answers for this poll.");
            }
            else
            {
                Console.WriteLine("User can pick only one answer for this poll.");
            }
            //enter number of questions to your poll
            while (arewethereyet < questionnumbers)
            {
                int clickingtherighta = arewethereyet + 1;
                if (arewethereyet == 0)
                {
                    driver.FindElement(By.CssSelector("#cta > div > div.item > form > div.row > div.col-sm-8 > div.question > fieldset > div > table > tbody > tr > td.text > input.form-control.input-sm.js-label")).SendKeys("Answer1");
                }
                else
                {
                    driver.FindElement(By.CssSelector("#cta > div > div.item > form > div.row > div.col-sm-8 > div.question > fieldset > div > p > a")).Click();
                    String correctanswernumberforpoll = "#cta > div > div.item > form > div.row > div.col-sm-8 > div.question > fieldset > div > table > tbody > tr:nth-child(" + clickingtherighta + ") > td.text > input.form-control.input-sm.js-label";
                    String qn = "Answer" + clickingtherighta;
                    driver.FindElement(By.CssSelector(correctanswernumberforpoll)).SendKeys(qn);
                }
                arewethereyet++;
            }
            Thread.Sleep(7000);
            driver.FindElement(By.CssSelector("#cta > div > div.item > form > div.row > div.col-sm-8 > fieldset:nth-child(5) > div > div:nth-child(1) > div > div > input")).SendKeys(nuofseconds);
            Thread.Sleep(2000);
            //if you want to add the CTA sometime during the presentation, make the following value true; if you want it at the end make it false
            bool endorduring = true;
            if (endorduring == true)
            {
                Thread.Sleep(3000);
                driver.FindElement(By.CssSelector("#cta > div > div.item > form > div.row > div.col-sm-8 > fieldset:nth-child(4) > div > div:nth-child(1)")).Click();
                Thread.Sleep(3000);
                driver.FindElement(By.CssSelector("#chapter")).Click();
                Thread.Sleep(3000);
                ctaslidenumber = ctaslidenumber++;
                Cssforctaslide = Cssforctaslide + ctaslidenumber + ")";
                driver.FindElement(By.CssSelector(Cssforctaslide)).Click();
            }
            else
            {
                Thread.Sleep(3000);
                driver.FindElement(By.PartialLinkText("completion")).Click();
            }
            Thread.Sleep(2000);
            driver.FindElement(By.CssSelector("#cta > div > div.item > form > div.actionbar > button.btn.btn-primary")).Click();
            Thread.Sleep(2000);
            if (driver.FindElements(By.CssSelector("#cta > div > table > tbody > tr:nth-child(2) > td.type")).Count > 0)
            {
                Console.WriteLine("CTA Poll was successfully added!");
            }
            else
            {
                Console.WriteLine("CTA was not successfully added.");
            }
        }
        [TestMethod]
        public void CallsToActionQuiz()
        {
            driver.Navigate().GoToUrl("https://sales.imeet.com/my-channel/my-computer-made-this/edit");
            driver.FindElement(By.CssSelector("#edit-tabs > ul > li:nth-child(1) > a")).Click();
            Thread.Sleep(4200);
            driver.FindElement(By.CssSelector("#partner-imeet-customize > nav > ul > li:nth-child(4) > a")).Click();
            Thread.Sleep(3000);
            while (driver.FindElements(By.CssSelector("#cta > div > table > tbody > tr:nth-child(2) > td.type")).Count != 0)
            {
                if (driver.FindElements(By.CssSelector("#cta > div > table > tbody > tr:nth-child(2) > td:nth-child(3) > a.delete")).Count > 0)
                {
                    driver.FindElement(By.CssSelector("#cta > div > table > tbody > tr:nth-child(2) > td:nth-child(3) > a.delete")).Click();
                }
                else
                {
                    Console.WriteLine("CTA can not currently be deleted.");
                }
            }
            Thread.Sleep(20000);
            driver.FindElement(By.CssSelector("#dropdownMenu1")).Click();
            Thread.Sleep(4000);
            driver.FindElement(By.CssSelector("#cta > div > div.heading > div.dropdown.open > ul > li:nth-child(5) > a")).Click();
            Thread.Sleep(2000);
            //If you want the user to not be able to skip the call to action you are going to make, make faoolowing value false
            bool skippable = true;
            if (skippable == false)
            {
                driver.FindElement(By.Name("isskippable")).Click();
                Console.WriteLine("Viewer Is now forced to look at CTA");
            }
            else
            {
                Console.WriteLine("CTA is still skippable");
            }
            Thread.Sleep(3000);
            driver.FindElement(By.CssSelector("#cta > div > div.item > form > div.row > div.col-sm-8 > div.question > div:nth-child(1) > textarea")).SendKeys("Question?");
            Thread.Sleep(1250);
            while (arewethereyet < questionnumbers)
            {
                int clickingtherighta = arewethereyet + 1;
                if (arewethereyet == 0)
                {
                    driver.FindElement(By.CssSelector("#cta > div > div.item > form > div.row > div.col-sm-8 > div.question > fieldset > div > table > tbody > tr > td.text > input.form-control.input-sm.js-label")).SendKeys("Answer1");
                }
                else
                {
                    driver.FindElement(By.CssSelector("#cta > div > div.item > form > div.row > div.col-sm-8 > div.question > fieldset > div > p > a")).Click();
                    String correctanswernumberforpoll = "#cta > div > div.item > form > div.row > div.col-sm-8 > div.question > fieldset > div > table > tbody > tr:nth-child(" + clickingtherighta + ") > td.text > input.form-control.input-sm.js-label";
                    String qn = "Answer" + clickingtherighta;
                    driver.FindElement(By.CssSelector(correctanswernumberforpoll)).SendKeys(qn);
                }
                arewethereyet++;
            }
            //if you want poll to have a single right answer, make this true
            bool singleormultiple = true;
            //which answer is correct
            int whichiscorrect = 3;
            if (singleormultiple == false)
            {
                driver.FindElement(By.CssSelector("#cta > div > div.item > form > div.row > div.col-sm-8 > div.question > div:nth-child(3) > select")).Click();
                driver.FindElement(By.CssSelector("#cta > div > div.item > form > div.row > div.col-sm-8 > div.question > div:nth-child(3) > select > option:nth-child(2)")).Click();
                Console.WriteLine("There are multiple correct answers in this quiz!");
                //pick number of right answers
                int nuofrightanswers = 2;

                int answerssofar = 1;
                while (answerssofar != nuofrightanswers)
                {
                    String correctanswer = "#cta > div > div.item > form > div.row > div.col-sm-8 > div.question > fieldset > div > table > tbody > tr:nth-child(" + whichiscorrect + ") > td.iscorrect";
                    driver.FindElement(By.CssSelector(correctanswer)).Click();
                    Console.WriteLine("One of the correct answers is Answer" + whichiscorrect);
                    //change variable to second answer
                    whichiscorrect = 1;
                    answerssofar++;
                }
            }
            else
            {
                String correctanswer = "#cta > div > div.item > form > div.row > div.col-sm-8 > div.question > fieldset > div > table > tbody > tr:nth-child(" + whichiscorrect + ") > td.iscorrect";
                driver.FindElement(By.CssSelector(correctanswer)).Click();
                Console.WriteLine("There is only one correct answer and it is answer" + whichiscorrect);
            }
            Thread.Sleep(7000);
            driver.FindElement(By.CssSelector("#cta > div > div.item > form > div.row > div.col-sm-8 > fieldset:nth-child(5) > div > div:nth-child(1) > div > div > input")).SendKeys(nuofseconds);
            Thread.Sleep(2000);
            //if you want to add the CTA sometime during the presentation, make the following value true; if you want it at the end make it false
            bool endorduring = true;
            if (endorduring == true)
            {
                Thread.Sleep(3000);
                driver.FindElement(By.CssSelector("#cta > div > div.item > form > div.row > div.col-sm-8 > fieldset:nth-child(4) > div > div:nth-child(1)")).Click();
                Thread.Sleep(3000);
                driver.FindElement(By.CssSelector("#chapter")).Click();
                Thread.Sleep(3000);
                ctaslidenumber++;
                Cssforctaslide = Cssforctaslide + ctaslidenumber + ")";
                driver.FindElement(By.CssSelector(Cssforctaslide)).Click();

            }
            else
            {
                Thread.Sleep(3000);
                driver.FindElement(By.PartialLinkText("completion")).Click();
            }
            Thread.Sleep(2000);
            driver.FindElement(By.CssSelector("#cta > div > div.item > form > div.actionbar > button.btn.btn-primary")).Click();
            Thread.Sleep(2000);
            if (driver.FindElements(By.CssSelector("#cta > div > table > tbody > tr:nth-child(2) > td.type")).Count > 0)
            {
                Console.WriteLine("CTA Quiz was successfully added!");
            }
            else
            {
                Console.WriteLine("CTA was not successfully added.");
            }
        }
        [TestMethod]
        public void HideNSeek()
        {
            driver.Navigate().GoToUrl("https://sales.imeet.com/my-channel/my-computer-made-this/edit");
            driver.FindElement(By.CssSelector("#edit-tabs > ul > li:nth-child(1) > a")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.CssSelector("#partner-imeet-customize > nav > ul > li:nth-child(5) > a")).Click();
            Thread.Sleep(6000);
            int numberofslidesyouwanttohide = 3;   
            bool Iwanttohide = true;
            if (Iwanttohide == true)
            {
                int slideyouhide = 2;
                while (arewethereyet < numberofslidesyouwanttohide)
                {
                    //enter which slide you want to hide
                    int whichslide = slideyouhide;
                    String Xpathtohide = "//*[@id=\"chapterize\"]/div[2]/div/table/tbody/tr[" + whichslide + "]/td[3]/button[1]";
                    driver.FindElement(By.XPath(Xpathtohide)).Click();
                    Thread.Sleep(4000);
                    Console.WriteLine("Slide " + whichslide + " was hidden");
                    slideyouhide++;
                    arewethereyet++;
                }
            }
            else
            {
                Console.WriteLine("No slide has been hidden!");
            }
              
            
        }
        [TestMethod]
        public void PreRoll()
        {
            //true to create new presentation for pre- roll
            bool createnew = false;
            if (createnew == true)
            {
                CreatePrezi();
                driver.Navigate().GoToUrl("https://sales.imeet.com/my-channel/my-computer-made-this/edit");
                driver.FindElement(By.CssSelector("#edit-tabs > ul > li:nth-child(1) > a")).Click();
                Thread.Sleep(2500);
                driver.FindElement(By.CssSelector("#partner-imeet-customize > nav > ul > li:nth-child(6) > a")).Click();
                Thread.Sleep(2500);
                driver.FindElement(By.CssSelector("#pre-post-rolls > div:nth-child(3) > div:nth-child(3) > div:nth-child(1) > div > a > div")).Click();
                Thread.Sleep(2500);
                int whichpreziyouwant = 1;
                String XpathforPreRoll = "//*[@id=\"prePostRollModal\"]/div/div/div[2]/div[2]/div[" + whichpreziyouwant + "]/div[3]/a";
                driver.FindElement(By.XPath(XpathforPreRoll)).Click();
                Console.WriteLine("Good Work");
            }
            else
            {
                driver.Navigate().GoToUrl("https://sales.imeet.com/my-channel/my-computer-made-this/edit");
                driver.FindElement(By.CssSelector("#edit-tabs > ul > li:nth-child(1) > a")).Click();
                Thread.Sleep(2500);
                driver.FindElement(By.CssSelector("#partner-imeet-customize > nav > ul > li:nth-child(6) > a")).Click();
                Thread.Sleep(2500);
                driver.FindElement(By.CssSelector("#pre-post-rolls > div:nth-child(3) > div:nth-child(3) > div:nth-child(1) > div > a > div")).Click();
                Thread.Sleep(2500);
                int whichpreziyouwant = 1;
                String XpathforPreRoll = "//*[@id=\"prePostRollModal\"]/div/div/div[2]/div[2]/div[" + whichpreziyouwant + "]/div[3]/a";
                driver.FindElement(By.XPath(XpathforPreRoll)).Click();
                Console.WriteLine("Good Work");
            }
        }
        [TestMethod]
        public void PostRoll()
        {
            //true to create new presentation for pre- roll
            bool createnew = false;
            if (createnew == true)
            {
                CreatePrezi();
                CustomBasics();
                driver.Navigate().GoToUrl("https://sales.imeet.com/my-channel/my-computer-made-this/edit");
                driver.FindElement(By.CssSelector("#edit-tabs > ul > li:nth-child(1) > a")).Click();
                Thread.Sleep(2500);
                driver.FindElement(By.CssSelector("#partner-imeet-customize > nav > ul > li:nth-child(6) > a")).Click();
                Thread.Sleep(2500);
                driver.FindElement(By.CssSelector("#pre-post-rolls > div:nth-child(3) > div:nth-child(3) > div:nth-child(3) > div > a > div")).Click();
                Thread.Sleep(2500);
                int whichpreziyouwant = 1;
                String XpathforPreRoll = "//*[@id=\"prePostRollModal\"]/div/div/div[2]/div[2]/div[" + whichpreziyouwant + "]/div[3]/a";
                driver.FindElement(By.XPath(XpathforPreRoll)).Click();
                Console.WriteLine("Good Work");
            }
            else
            {
                driver.Navigate().GoToUrl("https://sales.imeet.com/my-channel/my-computer-made-this/edit");
                driver.FindElement(By.CssSelector("#edit-tabs > ul > li:nth-child(1) > a")).Click();
                Thread.Sleep(2500);
                driver.FindElement(By.CssSelector("#partner-imeet-customize > nav > ul > li:nth-child(6) > a")).Click();
                Thread.Sleep(2500);
                driver.FindElement(By.CssSelector("#pre-post-rolls > div:nth-child(3) > div:nth-child(3) > div:nth-child(3) > div > a > div")).Click();
                Thread.Sleep(2500);
                int whichpreziyouwant = 1;
                String XpathforPreRoll = "//*[@id=\"prePostRollModal\"]/div/div/div[2]/div[2]/div[" + whichpreziyouwant + "]/div[3]/a";
                driver.FindElement(By.XPath(XpathforPreRoll)).Click();
                Console.WriteLine("Good Work");
            }
        }
        [TestMethod]
        public void TrackingName()
        {
            driver.Navigate().GoToUrl("https://sales.imeet.com/my-channel/my-computer-made-this/edit");
            Thread.Sleep(3500);
            driver.FindElement(By.CssSelector("#edit-tabs > ul > li:nth-child(2) > a")).Click();
            Thread.Sleep(3000);
            //true means user must take a survey before watching presentation
            bool survey = true;
            if (survey == false)
            {
                driver.FindElement(By.CssSelector("#partner-imeet-track > div > fieldset:nth-child(2) > div.checkbox > label")).Click();
                Console.WriteLine("Users do not have to register, meaning tracking information will be less accurate");
            }
            else
            {
                Console.WriteLine("User must register prior to watching presentation, meaning you will have the most accurate tracking data!");
                //to at least provide option for user to write first and last make true
                bool FirstandLast = true;
                if (FirstandLast == true)
                {
                    driver.FindElement(By.CssSelector("#LeadGen-FirstName")).Click();
                    Thread.Sleep(4400);
                    bool optional = true;
                    if (optional == true)
                    {
                        Thread.Sleep(1000);
                        driver.FindElement(By.CssSelector("#LeadGen-FirstName > option:nth-child(1)")).Click();
                        Thread.Sleep(3000);
                        Console.WriteLine("It is optional for user to give his or her name.");
                    }
                    else
                    {
                        Thread.Sleep(800);
                        driver.FindElement(By.CssSelector("#LeadGen-FirstName > option:nth-child(2)")).Click();
                        Thread.Sleep(3000);
                        Console.WriteLine("It is required for user to give his or her name.");
                    }
                    driver.FindElement(By.CssSelector("#LeadGen-LastName")).Click();
                    Thread.Sleep(3000);
                    if (optional == true)
                    {
                        driver.FindElement(By.CssSelector("#LeadGen-LastName > option:nth-child(1)")).Click();
                        Thread.Sleep(3000);
                    }
                    else
                    {
                        driver.FindElement(By.CssSelector("#LeadGen-LastName > option:nth-child(2)")).Click();
                        Thread.Sleep(3000);
                    }
                }
                else
                {
                    Console.WriteLine("User does not have the option to give his name");
                }
            }
        }
        [TestMethod]
        public void TrackingEmployment()
        {
            driver.Navigate().GoToUrl("https://sales.imeet.com/my-channel/my-computer-made-this/edit");
            driver.FindElement(By.CssSelector("#edit-tabs > ul > li:nth-child(2) > a")).Click();
            Thread.Sleep(3000);
            //true means user must take a survey before watching presentation
            bool survey = true;
            if (survey == false)
            {
                driver.FindElement(By.CssSelector("#partner-imeet-track > div > fieldset:nth-child(2) > div.checkbox > label")).Click();
                Thread.Sleep(1600);
                Console.WriteLine("Users do not have to register, meaning tracking information will be less accurate");
            }
            else
            {
                Console.WriteLine("User must register prior to watching presentation, meaning you will have the most accurate tracking data!");
                //to at least provide option for user to give employment information make this true
                bool jobornah = true;
                if (jobornah == true)
                {
                    driver.FindElement(By.CssSelector("#LeadGen-Company")).Click();
                    Thread.Sleep(4000);
                    bool optional = true;
                    if (optional == true)
                    {
                        Thread.Sleep(2900);
                        driver.FindElement(By.CssSelector("#LeadGen-Company > option:nth-child(1)")).Click();
                        Console.WriteLine("It is optional for user to give his or her employment information.");
                    }
                    else
                    {
                        Thread.Sleep(2400);
                        driver.FindElement(By.CssSelector("#LeadGen-Company > option:nth-child(2)")).Click();
                        Console.WriteLine("It is required for user to give his or her employment information.");
                    }
                    driver.FindElement(By.CssSelector("#LeadGen-Title")).Click();
                    Thread.Sleep(3200);
                    if (optional == true)
                    {
                        driver.FindElement(By.CssSelector("#LeadGen-Title > option:nth-child(1)")).Click();
                    }
                    else
                    {
                        driver.FindElement(By.CssSelector("#LeadGen-Title > option:nth-child(2)")).Click();
                    }
                }
                else
                {
                    Console.WriteLine("User does not have the option to give his or her employment information.");
                }
            }
        }
        [TestMethod]
        public void TrackingAddress()
        {
            driver.Navigate().GoToUrl("https://sales.imeet.com/my-channel/my-computer-made-this/edit");
            driver.FindElement(By.CssSelector("#edit-tabs > ul > li:nth-child(2) > a")).Click();
            Thread.Sleep(4000);
            //true means user must take a survey before watching presentation
            bool survey = true;
            if (survey == false)
            {
                driver.FindElement(By.CssSelector("#partner-imeet-track > div > fieldset:nth-child(2) > div.checkbox > label")).Click();
                Thread.Sleep(3000);
                Console.WriteLine("Users do not have to register, meaning tracking information will be less accurate");
            }
            else
            {
                Console.WriteLine("User must register prior to watching presentation, meaning you will have the most accurate tracking data!");
                //to at least provide option for user to give address proximity make this true
                bool Proximity = true;
                Thread.Sleep(3000);
                if (Proximity == true)
                {
                    driver.FindElement(By.CssSelector("#LeadGen-Country")).Click();
                    bool optional = true;
                    Thread.Sleep(3500);
                    if (optional == true)
                    {
                        Thread.Sleep(2000);
                        driver.FindElement(By.CssSelector("#LeadGen-Country > option:nth-child(1)")).Click();
                        Console.WriteLine("It is optional for user to give his or her address proximity.");
                    }
                    else
                    {
                        Thread.Sleep(1900);
                        driver.FindElement(By.CssSelector("#LeadGen-Country > option:nth-child(2)")).Click();
                        Console.WriteLine("It is required for user to give his or her address proximity.");
                    }
                    driver.FindElement(By.CssSelector("#LeadGen-State")).Click();
                    Thread.Sleep(3000);
                    if (optional == true)
                    {
                        Thread.Sleep(2500);
                        driver.FindElement(By.CssSelector("#LeadGen-State > option:nth-child(1)")).Click();
                    }
                    else
                    {
                        Thread.Sleep(2500);
                        driver.FindElement(By.CssSelector("#LeadGen-State > option:nth-child(2)")).Click();
                    }
                    driver.FindElement(By.CssSelector("#LeadGen-City")).Click();
                    Thread.Sleep(4000);
                    if (optional == true)
                    {
                        Thread.Sleep(2500);
                        driver.FindElement(By.CssSelector("#LeadGen-City > option:nth-child(1)")).Click();
                    }
                    else
                    {
                        Thread.Sleep(2500);
                        driver.FindElement(By.CssSelector("#LeadGen-City > option:nth-child(2)")).Click();
                    }
                }
                else
                {
                    Console.WriteLine("User does not have the option to give his or her address proximity.");
                }
            }
        }
        [TestMethod]
        public void Analytics()
        {
            driver.Navigate().GoToUrl("https://sales.imeet.com/my-channel/my-computer-made-this/edit");
            driver.FindElement(By.CssSelector("#edit-tabs > ul > li:nth-child(4) > a")).Click();
            Thread.Sleep(2000);
            //to see how many viewers viewed at least 25% of prezi, make it Progress25Count, for 50 Progress50Count, etc.
            String Idviewers = "Progress25Count";
            driver.FindElement(By.Id(Idviewers)).Click();
            Thread.Sleep(3000);
            //to see how much time each viewer spent looking at it
            driver.FindElement(By.Id("SessionTime")).Click();
            Thread.Sleep(3000);
            //to see viewer info
            driver.FindElement(By.CssSelector("#partner-imeet-analytics > nav > ul > li:nth-child(2) > a")).Click();
            Thread.Sleep(3000);
            //to download CTAs
            driver.FindElement(By.CssSelector("#partner-imeet-analytics > nav > ul > li:nth-child(5) > a")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.CssSelector("#partner-imeet-analytics > div.row.date-select > div > form > button.js-cta-report.btn.btn-default")).Click();
            //to view if presentation was viewed on other websites
            driver.FindElement(By.CssSelector("#partner-imeet-analytics > nav > ul > li:nth-child(6) > a")).Click();
        }
    }
}
[TestClass]
    public class BugConfirmations
    {
        IWebDriver chromey;
        IWebDriver twoatonce;
        IWebElement uploadexternaldoc;
        IWebElement plswork;
        [TestInitialize]
        public void Setoop()
        {
            chromey = new ChromeDriver();
        chromey.Navigate().GoToUrl("http://bleacherreport.com/articles/2637700-left-by-teammates-overlooked-by-fans-damian-lillard-finds-anger-is-an-energy");

    }
        [TestMethod]
        public void BRFBTEST()
        {
        Console.WriteLine(chromey.CurrentWindowHandle);
        Thread.Sleep(5000);
        chromey.FindElement(By.CssSelector("#article-slider > article > footer > ul > li.share-button.button.button--facebook.button--medium > a > span.share-text")).Click();
        chromey.SwitchTo().Window(chromey.WindowHandles.Last());
        Thread.Sleep(5000);
        chromey.FindElement(By.CssSelector("#email")).SendKeys("omgitworked!!!!");
        Console.WriteLine(chromey.WindowHandles.Last());
        Thread.Sleep(10000);
        }
    [TestMethod]
        public void UploadFirefoxTest()
    { 
        chromey.Navigate().GoToUrl("https://accounts.google.com/ServiceLogin?service=mail&passive=true&rm=false&continue=https://mail.google.com/mail/&ss=1&scc=1&ltmpl=default&ltmplcache=2&emr=1&osid=1#identifier");
        chromey.FindElement(By.CssSelector("#gmail-sign-in")).Click();
        IWebElement signin = chromey.FindElement(By.CssSelector("#Email"));
         signin.SendKeys("sauravshenoy9@gmail.com");
        chromey.FindElement(By.CssSelector("#next")).Click();
        Thread.Sleep(5000);
        chromey.FindElement(By.CssSelector("#Passwd")).SendKeys("beconfident247");
        chromey.FindElement(By.CssSelector("#signIn")).Click();
        Thread.Sleep(20000);
        chromey.FindElement(By.XPath("//*[@id=\":q7\"]")).SendKeys(@"C:\Users\Saurav\Documents\hi");
        Thread.Sleep(3000);
        }
        [TestCleanup]
        public void Closeit()
        {
            chromey.Quit();
        }
    }

    


