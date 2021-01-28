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
        private Dictionary<string, ChiffreAffaire> dicoCa = new Dictionary<string, ChiffreAffaire>();

        public BusinessDataRepository(string cnxString)
        {
            cnx = new SqlConnection(cnxString);
            makeDicoCas();
        }
        public BusinessDataRepository(string cnxString, SqlDbContext dbContext)
        {
            cnx = new SqlConnection(cnxString);            
            makeDicoCas();
        }

        public IEnumerable<Facture> Factures
            => cnx.Query<Facture>("SELECT * FROM Facture ORDER BY code DESC");

        public IEnumerable<ChiffreAffaire> CAs            
            => dicoCa.Values.ToList();

        public IEnumerable<FactureDTO> FacturesDTO 
            => cnx.Query<FactureDTO>("SELECT * FROM Facture ORDER BY code ASC");

        public void AddFac(FactureDTO f, SqlDbContext dbContext)
        {
            Facture fac = new Facture(f);
            dbContext.Add(fac);
            dbContext.SaveChanges();
        }

        // Méthode utilisée une seule fois pour injecter dans la base de donnée les factures
        // créées préalablement en dur dans le code
        public void addAllFac(List<Facture> facList, SqlDbContext dbContext)
        {
            foreach (Facture f in facList)
            {
                dbContext.Add(f);
            }
            dbContext.SaveChanges();
        }

        // Création d'un dictionnaire contenant des objets ChiffreAffaire, 
        // en fonction de l'année des factures présentes dans la base de donnée
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
        }

        public void addCa (ChiffreAffaire ca, SqlDbContext dbContext)
        {                             
            dbContext.Add(ca);
            dbContext.SaveChanges();
        }

        public void Dispose()
        {
            cnx.Dispose();
        }

        public void deleteFac(FactureDTO f, SqlDbContext dbContext)
        {            
            Facture facDel = dbContext.Facture.Where(fac => fac.code == f.code).FirstOrDefault();
            dbContext.Remove(facDel);
            dbContext.SaveChanges();
        }
    }
}
