using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Facturation.Shared
{
    public class FactureDTO
    {
        [Required(ErrorMessage = "Code de facture requis")]
        [RegularExpression(@"^F[0-9]{3}$",
         ErrorMessage = "Format d'un code facture : F + 3 chiffres de 0 à 9")]
        public string code { get; set; }

        [Required(ErrorMessage = "Nom du client requis")]
        public string client { get; set; }

        [Required(ErrorMessage = "Date d'emission requise")]
        [DataType(DataType.DateTime)]
        public DateTime dateEmission { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime dateReglement { get; set; }

        [Required(ErrorMessage = "Montant de la facture requis")]        
        public double montantDu { get; set; }
        public double montantRegle { get; set; }
        
        public FactureDTO() 
        {
            dateEmission = DateTime.Now.Date;
            dateReglement = DateTime.Now.Date.AddDays(7);
        }

        public FactureDTO(Facture facture)
        {
            code = facture.code;
            client = facture.client;
            dateEmission = facture.dateEmission;
            dateReglement = facture.dateReglement;
            montantDu = facture.montantDu;
            montantRegle = facture.montantRegle;
        }

        public FactureDTO(string cod, string c, DateTime dateE, DateTime dateR, double montantD, double montantR)
        {
            code = cod; 
            client = c; 
            dateEmission = dateE; 
            dateReglement = dateR;
            montantDu = montantD; 
            montantRegle = montantR;
        }

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
