using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using MbUnit.Framework;
using SistemaVendas.Negocio;
using NHibernate;

namespace TestProject1.Testes
{
    [TestFixture]
    public class TesteRelatorioDeVenda : TesteBase
    {

        private RelatorioVendasRepository relatorioVendas;

        [SetUp]
        public void start()
        {
            ISession session = Contexto.SessionFactory.OpenSession();
            relatorioVendas = new RelatorioVendasRepository(session);
        }

        [Test]
        public void teste_consulta_vendedor_inexistente()
        {
            
            decimal valorEsperado = 0;
            int idVendedor = 9999;
            int ano = 2011;

            decimal valorAnual = relatorioVendas.ObterVendaAnualVendedor(idVendedor, ano);

            Assert.AreEqual(valorEsperado, valorAnual);
        }

        [Test]
        public void teste_um_vendedor_com_uma_venda_no_ano()
        {
            
            decimal valorEsperado = 100;
            int idVendedor = 1;
            int ano = 2011;

            decimal valorAnual = relatorioVendas.ObterVendaAnualVendedor(idVendedor, ano);

            Assert.AreEqual(valorEsperado, valorAnual);
        }

        [Test]
        public void teste_um_vendedor_com_duas_vendas_no_mesmo_ano()
        {
            
            decimal valorEsperado = 200;
            int idVendedor = 2;
            int ano = 2012;

            decimal valorAnual = relatorioVendas.ObterVendaAnualVendedor(idVendedor, ano);

            Assert.AreEqual(valorEsperado, valorAnual);
        }

        [Test]
        public void teste_um_vendedor_com_uma_venda_em_anos_distintos()
        {

            decimal valorEsperado = 80;
            int idVendedor = 3;
            int ano = 2010;

            decimal valorAnual = relatorioVendas.ObterVendaAnualVendedor(idVendedor, ano);

            Assert.AreEqual(valorEsperado, valorAnual);
        }

        [Test]
        public void teste_venda_compartilhada_entre_dois_vendedores()
        {
            decimal valorEsperado = 150;
            int idVendedor = 4;
            int ano = 2014;

            decimal valorAnual = relatorioVendas.ObterVendaAnualVendedor(idVendedor, ano);

            Assert.AreEqual(valorEsperado, valorAnual);
        }
    }
}
