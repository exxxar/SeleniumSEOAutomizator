using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SeleniumSEOAutomizator
{
    class Whois:AbstractWebSite
    {
        private class Param
        {
            public String param { set; get; }
            public String arg { get; set; }
        }
        private String testableURL;
        private List<Param> data;

        public Whois(String testableURL)
        {
            this.init("http://nic.ru/whois");
            this.testableURL = testableURL;
            this.data = new List<Param>();
        }

        public override void run()
        {    
           
            this.driver.FindElement(By.CssSelector(".b-whois-search__input")).SendKeys(this.testableURL);
            this.driver.FindElement(By.CssSelector(".b-whois-search__input")).SendKeys(OpenQA.Selenium.Keys.Enter);
            //Console.WriteLine(this.driver.FindElement(By.CssSelector(".b-whois-info__info")).Text);
            string pattern = @"(\w+\s\w+|\w+): ([0-9]{4}-[0-9]{2}-[0-9]{2})T([0-9]{2}:[0-9]{2}:[0-9]{2})Z";
            string input = this.driver.FindElement(By.CssSelector(".b-whois-info__info")).Text;
            foreach (Match match in Regex.Matches(input, pattern, RegexOptions.IgnoreCase))
            {
                Param p = new Param();
                p.param = match.Groups[1].Value;
                p.arg = match.Groups[2].Value + " " + match.Groups[3].Value;
                Console.WriteLine("whois->{0} {1}", p.param,p.arg);
                this.data.Add(p);
            }

             
        }
    

      
    }
}
