package br.com.k21;

public class Calculadora {

	public double comissao(double valor_venda) {
		if (valor_venda<=10000)
		{
			return valor_venda*0.05;
		}
		else
		{
			return valor_venda*0.06;
		}
			

	}


}
