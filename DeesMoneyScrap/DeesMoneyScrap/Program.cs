﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace DeesMoneyScrap
{
    class Program
    {
        static void Main(string[] args)
        {
            var options = new ChromeOptions();
            options.AddArgument("--disable-gpu");

            var chromeDriver = new ChromeDriver(options);
            
            chromeDriver.Navigate()
                .GoToUrl(
                    "https://login.yahoo.com/?.src=fpctx&.intl=us&.lang=en-US&authMechanism=primary&yid=&done=https%3A%2F%2Fwww.yahoo.com%2F&eid=100&add=1");
            var username = chromeDriver.FindElementById("login-username") ;
            username.SendKeys("jayd9817");
            var nextButton = chromeDriver.FindElementById("login-signin");
            nextButton.Click();

            WebDriverWait wait = new WebDriverWait(chromeDriver, TimeSpan.FromSeconds(10));
            var pswd = wait.Until(d => d.FindElement(By.Id("login-passwd")));


            //var pswd = wait.Until(d => d.FindElementById("login-passwd"));
            pswd.SendKeys("ICG9817#");
            var sign = chromeDriver.FindElementById("login-signin");
            sign.Click();


            chromeDriver.Navigate().GoToUrl("https://finance.yahoo.com/portfolio/p_1/view/v1");
            //var mytable = wait.Until(d => d.FindElement(By.ClassName("gIc8M")));
            var mytable = wait.Until(d => d.FindElement(By.XPath("//table[@data-test='contentTable']/tbody")));
            
            var rowXpath = "//tr[@data-index='0']";
            var symb = mytable.FindElement(By.XPath(rowXpath + "//a[contains(@href,'/quote/')]")).Text;
            var lastP = chromeDriver.FindElementByXPath(rowXpath + "//span[@class='_3Bucv']").Text;
            var change = chromeDriver.FindElementByXPath(rowXpath + "//span[contains(@class,'_2ZN-S')]").Text;
            var changePerc = chromeDriver.FindElementByXPath(rowXpath + "/td[4]/span").Text;
            //var volume = chromeDriver.FindElementByXPath(rowXpath + "/td[7]/span").Text;
            var volume = mytable.FindElement(By.XPath(rowXpath + "/td[7]/span")).Text;
                




            Console.WriteLine($"Dee's table : {symb} {lastP} {change} {changePerc} {volume}");

            //use xpath to target an element
            //var mytable = chromeDriver.FindElementById("main");

            //get 1st row

            //print the first symbol



        }
    }
}