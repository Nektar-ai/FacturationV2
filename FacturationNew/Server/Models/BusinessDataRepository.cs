using Facturation.Shared;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Facturation.Server.Models
{
    public class BusinessDataRepository : IBusinessData, IDisposable
    {
        private readonly SqlConnection cnx;
        private readonly SqlDbContext _dbContext;
        private Dictionary<string, ChiffreAffaire> dicoCa = new Dictionary<string, ChiffreAffaire>();
        public BusinessDataRepository(string cnxString)
        {
            cnx = new SqlConnection(cnxString);
            makeDicoCas();
        }
        public BusinessDataRepository(string cnxString, SqlDbContext dbContext)
        {
            cnx = new SqlConnection(cnxString);
            this._dbContext = dbContext;
            makeDicoCas();
        }

        public IEnumerable<Facture> Factures
            => cnx.Query<Facture>("SELECT * FROM Facture ORDER BY code DESC");

        public IEnumerable<ChiffreAffaire> CAs
            /*=> cnx.Query<ChiffreAffaire>("SELECT * FROM ChiffreAffaire ORDER BY year DESC");*/
            => dicoCa.Values.ToList();

        public IEnumerable<FactureDTO> FacturesDTO 
            => cnx.Query<FactureDTO>("SELECT * FROM Facture ORDER BY code DESC");

        public void AddFac(FactureDTO f, SqlDbContext dbContext)
        {
            Facture fac = new Facture(f);
            dbContext.Add(fac);
            dbContext.SaveChanges();
        }

        public void addAllFac(List<Facture> facList, SqlDbContext dbContext)
        {
            foreach (Facture f in facList)
            {
                dbContext.Add(f);
            }
            dbContext.SaveChanges();
        }

        public void addAllCas(List<ChiffreAffaire> caList, SqlDbContext dbContext)
        {
            foreach (ChiffreAffaire ca in caList)
            {
                dbContext.Add(ca);
            }
            dbContext.SaveChanges();
        }

        public void makeDicoCas()
        {
            foreach (Facture f in Factures)
            {
                string facYear = f.dateEmission.Year.ToString();
                if (!dicoCa.ContainsKey(facYear))
                {
                    dicoCa.Add(facYear, new ChiffreAffaire(facYear));
                }
                if (dicoCa.ContainsKey(facYear))
                {
                    dicoCa[facYear].chiffreAffairesReel += f.montantRegle;
                    dicoCa[facYear].chiffreAffairesDu += f.montantDu;
                }
            }
            foreach (KeyValuePair<string, ChiffreAffaire> kvp in dicoCa)
            {
                Console.WriteLine("(Cle Dico) Chiffre d'Affaire : {0}", kvp.Key);
                Console.WriteLine("(Attr Objet CA Year) Chiffre d'Affaire : {0}", kvp.Value.year);
                Console.WriteLine("(Attr Objet CA Du) Chiffre d'Affaire : {0}", kvp.Value.chiffreAffairesDu);
                Console.WriteLine("(Attr Objet CA Reel) Chiffre d'Affaire : {0}", kvp.Value.chiffreAffairesReel);
            }
            Console.WriteLine("Nombre d'éléments dans Dico : " + dicoCa.Count);
        }

        public void addCa (ChiffreAffaire ca, SqlDbContext dbContext)
        {
            /*cnx.Query<ChiffreAffaire>("INSERT " + ca + " INTO ChiffreAffaire");*/
            dbContext.Add(ca);
            dbContext.SaveChanges();
        }

        public void Dispose()
        {
            cnx.Dispose();
        }

        public void AddFac(FactureDTO f)
        {
            throw new NotImplementedException();
        }
    }
}
