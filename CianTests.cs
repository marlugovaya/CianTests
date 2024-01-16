using System;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

using PageObjectModel.Source.Pages;

namespace PageObjectModel.Tests
{

    public class CianTests
    {
        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new OpenQA.Selenium.Chrome.ChromeDriver();
            driver.Navigate().GoToUrl("https://www.cian.ru/");
            driver.Manage().Window.Maximize();

        }

        [Test]
        public void CheapestIsmailovoSearch()
        {
            CianHomePage homepage = new CianHomePage(driver);

            //homepage.ChangeToMoscow(); 
            //homepage.Wait(2);

            homepage.MoveToRent();

            homepage.SearchDistrictToRent("Измайлово");

            SearchResultPage search = new SearchResultPage(driver);

            //search.SortByLowPrice();

            for (int i = 0; i < 3; i++)
                search.GetCardInfo(i);


            Assert.Pass();
        }



        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}