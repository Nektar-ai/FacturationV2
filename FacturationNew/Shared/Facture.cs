using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Facturation.Shared
{
    public class Facture
    {
        // Exemple de Validation par Annotation
        /*[Required(ErrorMessage = "Code de facture requis")]*/
        
        [Key]
        public int id { get; set; }
        public string code { get; set; }
        public string client { get; set; }
        public DateTime dateEmission { get; set; }
        public DateTime dateReglement { get; set; }
        public double montantDu { get; set; }
        public double montantRegle { get; set; }

        public Facture() { }

        public Facture(FactureDTO factureDTO)
        {
            code = factureDTO.code;
            client = factureDTO.client;
            dateEmission = factureDTO.dateEmission;
            dateReglement = factureDTO.dateReglement;
            montantDu = factureDTO.montantDu;
            montantRegle = factureDTO.montantRegle;
        }

        public Facture(string cod, string c, DateTime dateE, DateTime dateR, double montantD, double montantR)
        {        
            code = cod;
            client = c;
            dateEmission = dateE;
            dateReglement = dateR;
            montantDu = montantD;
            montantRegle = montantR;
        }

/*        public Facture(int id, string cod, string c, DateTime dateE, DateTime dateR, double montantD, double montantR)
        {
            this.id = id;
            code = cod;
            client = c; 
            dateEmission = dateE; 
            dateReglement = dateR;
            montantDu = montantD; 
            montantRegle = montantR;
        }*/
        
/*        public string getCode()
        {
            return code;
        }

        public double getMontantR()
        {
            return montantRegle;
        }

        public double getMontantD()
        {
            return montantDu;
        }*/
        public string GetDateR()
        {
            return dateReglement.Date.ToString("dd-MM-yyyy");
        }

        public string GetDateE()
        {
            return dateEmission.Date.ToString("dd-MM-yyyy");
        }
    }
}
