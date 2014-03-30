package br.com.k21;

import static org.junit.Assert.assertEquals;

import org.junit.Test;
import org.junit.experimental.categories.Category;

public class TestCalculadoraComissao {

	@Test
	public void calcula_comissao_uma_venda_de_cem_retornando_cinco_reais() {
		double valor_venda = 100;
		double resultado_esperado = 5;
		
		double resposta = new Calculadora().comissao(valor_venda);
		
		assertEquals(resultado_esperado, resposta, 0.0000001);
	}

	@Test
	public void calcula_comissao_uma_venda_dez_mil_retornando_quinhentos_reais() {
		double valor_venda = 10000;
		double resultado_esperado = 500;
		
		double resposta = new Calculadora().comissao(valor_venda);
		
		assertEquals(resultado_esperado, resposta, 0.0000001);
	}
	
	@Test
	public void calcula_comissao_uma_venda_de_um_real_retornando_5_centavos() {
		double valor_venda = 1;
		double resultado_esperado = 0.05;
		
		double resposta = new Calculadora().comissao(valor_venda);
		
		assertEquals(resultado_esperado, resposta, 0.0000001);

	}
	
	@Test
	public void calcula_comissao_uma_venda_cem_mil_retornando_seis_mil_reais() {
		double valor_venda = 100000;
		double resultado_esperado = 6000;
		
		double resposta = new Calculadora().comissao(valor_venda);
		
		assertEquals(resultado_esperado, resposta, 0.0000001);
	}
	
	@Test
	public void calcula_comissao_uma_venda_duzento_mil_retornando_doze_mil_reais() {
		double valor_venda = 200000;
		double resultado_esperado = 12000;
		
		double resposta = new Calculadora().comissao(valor_venda);
		
		assertEquals(resultado_esperado, resposta, 0.0000001);
	}
}
