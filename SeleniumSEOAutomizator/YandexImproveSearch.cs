using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SeleniumSEOAutomizator
{
    class YandexImproveSearch:AbstractWebSite
    {

        public String testableURL { get; set; }
        public int count { get; set; }


        public YandexImproveSearch(String testableURL)
        {
            this.init("http://yandex.ru/search/advanced?&lr=213");
            this.testableURL = testableURL;
        }

        public override void run()
        {
            this.run("");
        }

        public void run(String keyword)
        {
            this.driver.FindElement(By.CssSelector(".b-form-input__input.b-settings__query")).SendKeys("\""+keyword+"\"");
            this.driver.FindElement(By.CssSelector(".b-form-input__input.b-settings__site")).SendKeys(this.testableURL);  
            Actions actions = new Actions(this.driver);
            actions.MoveToElement(
                driver.FindElement(By.CssSelector(".b-settings__submit > .b-form-button__input"))
                ).Click().Perform();

            if (this.isSelectorExist(By.CssSelector(".serp-adv__found")))
            {
                string pattern = @"\d+";
                Regex r = new Regex(pattern);
                Match m = r.Match(this.driver.FindElement(By.CssSelector(".serp-adv__found")).Text);

                count = int.Parse(m.Groups[0].Value);
                Console.WriteLine(count);
                Console.WriteLine("Найдено:" + this.driver.FindElement(By.CssSelector(".serp-adv__found")).Text);
            }
            else
            {
                Console.WriteLine("Найдено нифига");
            }
          //  this.driver.FindElement(By.CssSelector(".b-form-button__input")).SendKeys(OpenQA.Selenium.Keys.Enter);
        }

        public int getResultCount()
        {
            return this.count;
        }

        public bool isSelectorExist(By selector)
        {
            return driver.FindElements(selector).Count != 0;
        }

    }
}
