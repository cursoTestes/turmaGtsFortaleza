package br.com.k21;

import java.util.List;

import br.com.k21.dao.VendaRepository;
import br.com.k21.modelo.Venda;

public class CalculadoraRoyalties {

	private VendaRepository vendaRepository;
	private Calculadora calculadora;

	public CalculadoraRoyalties(VendaRepository vendaRepository, Calculadora calculadora) {
		this.vendaRepository = vendaRepository;
		this.calculadora = calculadora;
	}

	public double calcula(int mes, int ano) {
		List<Venda> vendas = vendaRepository.obterVendasPorMesEAno(ano, mes);
		double faturamentoLiquido = 0 ; 
		
		for(Venda venda: vendas)
		{
			double valorVenda = venda.getValor();
			faturamentoLiquido += valorVenda - calculadora.comissao(valorVenda);
		}
		
		return faturamentoLiquido * 0.2;
	}

}
