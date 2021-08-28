using AutomationResources;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;

namespace TCGPlayer
{
    [TestClass]
    public class TCGApplication
    {
        public IWebDriver Driver { get; private set; }


        [TestInitialize]
        public void SetupForWebDriver()
        {
            var factory = new WebDriverFactory();
            Driver = factory.Create(BrowserType.Chrome);

        }

        [TestMethod]
        public void TestMethod1()
        {
            HomePage homePage = new HomePage(Driver);
            homePage.GoTo();
            homePage.Search("Squall");

            homePage.verifyNumResults();
            homePage.filterResults();
            homePage.verifyPrice();
            homePage.addToCart();
            homePage.verifyNumItemsInCart();
            homePage.clearCart();


            

        }


    }
}
