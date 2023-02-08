using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Xml.Linq;

namespace TestProject3.Core
{
    public class DSL : GlobalVariables
    {
        #region Funções de Manipulação

        public static void Espere(int time) => Thread.Sleep(time);

        public void LimpaDados(string element) => driver.FindElement(By.XPath(element)).Clear();

        public void ClicaFora() => driver.FindElement(By.XPath("//html")).Click();

        public void EsperaElemento(string element, int seconds = 90)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
            wait.Until((d) => { return d.FindElement(By.XPath(element)); });
        }

        public void EsperaElementoSumir(string element)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(90));
            wait.Until(d => d.FindElements(By.XPath(element)).Count == 0);
        }

        public bool ValidaElementoExistente(string xPatch)
        {
            try
            { driver.FindElement(By.XPath(xPatch)); return true; }
            catch (NoSuchElementException) { return false; }
        }

        #endregion

        #region Funções de Interação
        public void EscreveTexto(string xpath, string value, [Optional] string description)
        {
            try
            {
                driver.FindElement(By.XPath(xpath)).SendKeys(value);
                if (description != null) Console.WriteLine("Preencheu" + description);
            }
            catch
            {
                if (description != null) Console.WriteLine("Erro ao preencher" + description);
                Assert.Fail();
            }
        }

        public void ClicaElemento(string element, [Optional] string description)
        {
            try
            {
                driver.FindElement(By.XPath(element)).Click(); Espere(1000);
                if (description != null) Console.WriteLine("Clicou em " + description);
            }
            catch
            {
                if (description != null) Console.WriteLine("Erro ao clicar em " + description);
                Assert.Fail();
            }
        }

        public void ValidaDados(string xpath, string value, [Optional] string description)
        {
            try
            {
                Assert.That(driver.FindElement(By.XPath(xpath)).Text, Does.Contain(value));
                if (description != null) Console.WriteLine("Validou " + description);
            }
            catch
            {
                if (description != null) Console.WriteLine("Erro ao validar " + description);
                Assert.Fail();
            }
        }

        #endregion

        #region Funções de Atribuição

        public static string GeraNomeAleatorio()
        {
            var rnd = new Random();
            string[] nome = { "Carlos", "Alexandre", "Andre", "Joana", "Carla" };
            string[] sobrenome = File.ReadAllLines(@"C:\Projects\Estudos\Selenium C\Aula YT\TestProject3\TestProject3\DataBase\sobrenome.txt");
            string nomeCompleto = nome[rnd.Next(nome.Length)] + " " + sobrenome[rnd.Next(nome.Length)];

            return nomeCompleto;
        }

        public static string GeraEmailAleatorio()
        {
            var rnd = new Random();
            string[] nome = { "Carlos", "Alexandre", "Andre", "Joana", "Carla" };
            string[] sobrenome = File.ReadAllLines(@"C:\Projects\Estudos\Selenium C\Aula YT\TestProject3\TestProject3\DataBase\sobrenome.txt");
            string[] dominio = { "gmail.com", "yahoo.com", "google.com", "email.com" };

            string email = nome[rnd.Next(nome.Length)]
                + "." + sobrenome[rnd.Next(sobrenome.Length)]
                + "@" + dominio[rnd.Next(dominio.Length)];

            return email.ToLower();
        }

        public static string GeraDataNascimento()
        {
            var rnd = new Random();
            int dia = rnd.Next(1, 28);
            int mes = rnd.Next(1, 12);
            int ano = rnd.Next(1950, 2000);

            string dataNasc = dia.ToString().PadLeft(2, '0')
                + mes.ToString().PadLeft(2, '0') + ano;

            return dataNasc;
        }

        public static string GeraCelular()
        {
            var rnd = new Random();
            string celNumber = string.Empty;

            for (int i = 0; i < 11; i++)
                celNumber = string.Concat(celNumber, rnd.Next(10));

            return celNumber;
        }

        #endregion

    }

}
