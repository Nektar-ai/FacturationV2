using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Facturation.Shared
{
    public interface IBusinessData
    {
        IEnumerable<Facture> Factures { get; }
        IEnumerable<FactureDTO> FacturesDTO { get; }
        IEnumerable<ChiffreAffaire> CAs { get; }
        void AddFac(FactureDTO f, SqlDbContext d);
        public void addAllFac(List<Facture> facList, SqlDbContext dbContext);
        public void deleteFac(FactureDTO f, SqlDbContext dbContext);
        /*public void addAllCas(List<ChiffreAffaire> caList, SqlDbContext dbContext);*/
    }
}
