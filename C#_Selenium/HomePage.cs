using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Threading;

namespace TCGPlayer
{
    internal class HomePage
    {
        static String price;
        static String confirmPrice;

        private IWebDriver driver;
        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        internal void GoTo()
        {
            driver.Navigate().GoToUrl("https://www.tcgplayer.com/search/magic/product?productLineName=magic&page=1");
            driver.Manage().Window.Maximize();
        }

        internal void Search(string itemToSearchFor)
        {
            driver.FindElement(By.Id("autocomplete-input")).SendKeys(itemToSearchFor);
            driver.FindElement(By.CssSelector("[value='conduct product search']")).Click();
            Thread.Sleep(1000);
               
        }

        internal void verifyNumResults()
        {
            String resultCount = driver.FindElement(By.CssSelector("[class='results']")).Text;
            Console.WriteLine(resultCount);
            String[] splitResultCount1 = resultCount.Split(new string[] { "of " }, StringSplitOptions.None);
            String[] splitResultCount2 = splitResultCount1[1].Split(new string[] { " results" }, StringSplitOptions.None);
            int resultsCountInt = Int32.Parse(splitResultCount2[0]);

            IList<IWebElement> resultElements = driver.FindElements(By.CssSelector("[class='search-result']"));
            int resultElementsInt = resultElements.Count;

            if (resultElementsInt == resultsCountInt)
            {
                Console.WriteLine("result count and elements on page match");
            }
            else
            {
                Console.WriteLine("result count and elements on page DONT match");
            }
        }

        internal void filterResults()
        {
            driver.FindElement(By.Id("FinalFantasyTCG-filter-label")).Click();
            Thread.Sleep(1000);
            IList<IWebElement> resultElements2 = driver.FindElements(By.CssSelector("[class='inventory__price-with-shipping']"));

            //grab price of first item on page
            foreach (IWebElement iwebElement in resultElements2)
            {
                price = iwebElement.Text;
                Console.WriteLine("Price: " + price);
                break;
            }

            IList<IWebElement> resultElements3 = driver.FindElements(By.CssSelector("[class='search-result']"));
            foreach (IWebElement iwebElement in resultElements3)
            {
                iwebElement.Click();
                break;
            }

            Thread.Sleep(2000);
            

        }

        internal void verifyPrice()
        {
            confirmPrice = driver.FindElement(By.XPath("//*[@class='spotlight__price']")).Text;
            Console.WriteLine("confirmPrice: "+confirmPrice);

            if (price.Equals(confirmPrice))
            {
                Console.WriteLine("Prices match");
            }
            else
            {
                Console.WriteLine("Prices DONT match");
            }

        }

        internal void addToCart()
        {
            driver.FindElement(By.XPath("//*[starts-with(@id,'btnAddToCart_FS')]")).Click();
            Thread.Sleep(1000);
        }

        internal void verifyNumItemsInCart()
        {
            String numOfItems = driver.FindElement(By.XPath("//*[@data-aid='numberOfItemsValue']")).Text;
		if(numOfItems.Equals("1")) {
			Console.WriteLine("Number of items is 1");
		}
		else {
			Console.WriteLine("Number of items is not 1");
		}
        }

        internal void clearCart()
        {
            driver.FindElement(By.CssSelector("[data-aid='editYourCart']")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//*[contains(text(),'Remove')]")).Click();

            Thread.Sleep(2000);

            driver.Quit();
        }

    }
}