using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;

namespace SistemaVendas.Negocio
{
    public class RelatorioVendasRepository
    {
        private ISession _session;

        public RelatorioVendasRepository(ISession _session)
        {
            this._session = _session;
        }

        public decimal ObterVendaAnualVendedor(int idVendedor, int ano)
        {
            var query = @"select sum(vv.valor)  from venda v inner join VendaVendedor vv on 
        vv.IdVenda = v.IdVenda where vv.IdVendedor = :idVendedor and year(v.dataVenda)= :ano";
            
            double valorVendasAno = 
                _session.CreateSQLQuery(query)
                .SetParameter("idVendedor", idVendedor)
                .SetParameter("ano", ano)
                .UniqueResult<double>();

            return (decimal)valorVendasAno;
        }
    }
}
