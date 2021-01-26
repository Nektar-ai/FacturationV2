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
        public BusinessDataRepository(string cnxString)
        {
            cnx = new SqlConnection(cnxString);
        }
        public BusinessDataRepository(string cnxString, SqlDbContext dbContext)
        {
            cnx = new SqlConnection(cnxString);
            this._dbContext = dbContext;
        }

        public IEnumerable<Facture> Factures
            => cnx.Query<Facture>("SELECT * FROM Facture ORDER BY code DESC");

        public IEnumerable<ChiffreAffaire> CAs
            => cnx.Query<ChiffreAffaire>("SELECT * FROM ChiffreAffaire ORDER BY year DESC");

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
                /*cnx.Query<Facture>("INSERT " + f + " INTO Facture");*/
                /*f.id = 1;*/
                dbContext.Add(f);
                /*Console.WriteLine("C'EST L'ID MAN : "+f.id);*/
            }
            dbContext.SaveChanges();
        }

        public void addAllCas(List<ChiffreAffaire> caList, SqlDbContext dbContext)
        {
            foreach (ChiffreAffaire ca in caList)
            {
                /*cnx.Query<Facture>("INSERT " + f + " INTO Facture");*/
                /*f.id = 1;*/
                dbContext.Add(ca);
                /*Console.WriteLine("C'EST L'ID MAN : "+f.id);*/
            }
            dbContext.SaveChanges();
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
