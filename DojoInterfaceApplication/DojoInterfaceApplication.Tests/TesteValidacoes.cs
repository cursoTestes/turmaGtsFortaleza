using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using DojoInterfaceApplication.Tests;

namespace SeleniumTests
{
    [TestClass]
    public class TesteValidacoes : TesteBase
    {
        [TestMethod]
        public void Retorna_Erro_quando_campos_obrigatorios_nao_sao_preenchidos()
        {
            driver.Navigate().GoToUrl(baseURL + "/Venda/Add");

            driver.FindElement(By.Id("Vendedor")).SendKeys("");
            driver.FindElement(By.Id("DataVenda")).SendKeys("");
            driver.FindElement(By.Id("Valor")).SendKeys("");

            driver.FindElement(By.CssSelector("input[type=\"submit\"]")).Click();

            String resultado = driver.FindElement(By.Id("validacaoVendedor")).Text;
            String esperado = "O campo Id Vendedor é obrigatório.";
            Assert.AreEqual(resultado, esperado);

            resultado = driver.FindElement(By.Id("validacaoDataVenda")).Text;
            esperado = "O campo Data Venda é obrigatório.";
            Assert.AreEqual(resultado, esperado);

            resultado = driver.FindElement(By.Id("validacaoValor")).Text;
            esperado = "O campo Valor é obrigatório.";
            Assert.AreEqual(resultado, esperado);

            Assert.AreEqual(baseURL + "/Venda/Add", driver.Url);

        }

        [TestMethod]
        public void inclusao_com_sucesso()
        {
            driver.Navigate().GoToUrl(baseURL + "/Venda/Add");

            driver.FindElement(By.Id("Vendedor")).SendKeys("1");
            driver.FindElement(By.Id("DataVenda")).SendKeys("12/04/2013");
            driver.FindElement(By.Id("Valor")).SendKeys("100");

            driver.FindElement(By.CssSelector("input[type=\"submit\"]")).Click();

            Assert.AreEqual(baseURL + "/Venda/Add", driver.Url);

            String resultado = driver.FindElement(By.Id("Mensagem")).Text;
            String esperado = "Cadastro com sucesso!";
            Assert.AreEqual(esperado, resultado);
            
            

        }

    }
}
