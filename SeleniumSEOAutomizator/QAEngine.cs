using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumSEOAutomizator
{
    class QAEngine : iQAEngine
    {
        public class WebSiteInfo
        {
            public enum SiteInfoType
            {
                YANDEX_WEBMASTER = 0,
                YANDEX_METRIKA = 1,
                FTP = 2,
                SSH = 3,
                CMS = 4
            }
            public String host { get; set; }
            public String login { get; set; }
            public String password { get; set; }
            public String description { get; set; }
            public SiteInfoType type { get; set; }
        }

        public String testableUrl { get; set; }
        public List<String> testableWords { get; set; }
        public List<WebSiteInfo> clientAccountsInfo { get; set; }
        public PDFReport report { get; set; }

        public QAEngine()
        {
            this.report = new PDFReport();
            this.doStep01();
            this.doStep02();
        }

       
        public void doStep01()
        {
            Whois whois = new Whois("ecodal.ru");
            whois.run();
            whois.close();
           // report.add(whois.results().ToString());
           
        }

        public void doStep02()
        {
            YandexImproveSearch yis = new YandexImproveSearch("ecodal.ru");
            yis.run("аренда биотуалетов");
            Console.WriteLine("Количество найденных результатов->"+yis.getResultCount());
            yis.close();
        }

        public void doStep03()
        {
            throw new NotImplementedException();
        }

        public void doStep04()
        {
            throw new NotImplementedException();
        }

        public void doStep05()
        {
            throw new NotImplementedException();
        }

        public void doStep06()
        {
            throw new NotImplementedException();
        }

        public void doStep07()
        {
            throw new NotImplementedException();
        }

        public void doStep08()
        {
            throw new NotImplementedException();
        }

        public void doStep09()
        {
            throw new NotImplementedException();
        }

        public void doStep10()
        {
            throw new NotImplementedException();
        }

        public void doStep11()
        {
            throw new NotImplementedException();
        }

        public void doStep12()
        {
            throw new NotImplementedException();
        }

        public void doStep13()
        {
            throw new NotImplementedException();
        }

        public void doStep14()
        {
            throw new NotImplementedException();
        }

        public void doStep15()
        {
            throw new NotImplementedException();
        }

        public void doStep16()
        {
            throw new NotImplementedException();
        }

        public void doStep17()
        {
            throw new NotImplementedException();
        }

        public void doStep18()
        {
            throw new NotImplementedException();
        }

        public void doStep19()
        {
            throw new NotImplementedException();
        }

        public void doStep20()
        {
            throw new NotImplementedException();
        }

        public void doStep21()
        {
            throw new NotImplementedException();
        }

        public void doStep22()
        {
            throw new NotImplementedException();
        }
    }
}
