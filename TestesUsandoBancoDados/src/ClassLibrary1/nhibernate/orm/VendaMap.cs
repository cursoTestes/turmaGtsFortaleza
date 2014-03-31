using FluentNHibernate.Mapping;
using SistemaVendas.Model;

namespace SistemaVendas.Negocio
{
    public class VendaMap : ClassMap<Venda>
    {
        public VendaMap()
        {
            Id(x => x.IdVenda).GeneratedBy.Identity();            
            Map(x => x.dataVenda);
            Map(x => x.valor);
        }
    }


}