package br.com.k21;

import static org.junit.Assert.assertEquals;
import static org.mockito.Mockito.*;

import java.util.Arrays;
import java.util.List;

import org.junit.Before;
import org.junit.Test;

import br.com.k21.dao.VendaRepository;
import br.com.k21.modelo.Venda;

public class TestCalculadoraRoyalties {
	VendaRepository mockVendaRepository;
	Calculadora mockComissao ;
	
	@Before
	public void preparaTeste(){
		mockVendaRepository = mock(VendaRepository.class);
		mockComissao = mock(Calculadora.class);
			
	}
	
	@Test
	public void testa_para_um_mes_sem_vendas(){
	
		int mes = 1;
		int ano = 2014;
		double esperado = 0;
		
		double resultado = new CalculadoraRoyalties(mockVendaRepository , mockComissao).calcula(mes, ano);
		
		assertEquals(esperado, resultado, 0);
	}
	
	@Test
	public void testa_para_um_mes_com_uma_venda(){
		int mes = 1;
		int ano = 2013;
		double valorVenda = 100;
		double esperado = 19;
		
		List<Venda> vendas = Arrays.asList(new Venda(1, 21, mes, ano, valorVenda));
		when(mockVendaRepository.obterVendasPorMesEAno(ano, mes)).thenReturn(vendas);
		when(mockComissao.comissao(valorVenda)).thenReturn(5.0);
	
		double resultado = new CalculadoraRoyalties(mockVendaRepository,mockComissao).calcula(mes, ano);

		assertEquals(esperado, resultado, 0);
	}
	
	@Test
	public void testa_para_um_mes_com_duas_vendas(){
		int mes = 1;
		int ano = 2013;
		double valorVenda = 100;
		double esperado = 40;
		
		List<Venda> vendas = Arrays.asList(new Venda(1, 21, mes, ano, valorVenda),new Venda(2, 11, mes, ano, valorVenda));
		when(mockVendaRepository.obterVendasPorMesEAno(ano, mes)).thenReturn(vendas);
		when(mockComissao.comissao(valorVenda)).thenReturn(0.0);
	
		double resultado = new CalculadoraRoyalties(mockVendaRepository,mockComissao).calcula(mes, ano);

		assertEquals(esperado, resultado, 0);
		
		verify(mockComissao, atLeastOnce()).comissao(valorVenda);
		
	}
}
