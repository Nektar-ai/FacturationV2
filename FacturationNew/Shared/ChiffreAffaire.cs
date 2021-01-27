using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturation.Shared
{
    public class ChiffreAffaire
    {
        [Key]
        public int? id { get; set; }
        public double chiffreAffairesDu { get; set; }
        public double chiffreAffairesReel { get; set; }
        public List<Facture> listFac { set; get; }
        public string year { get; set; }

        public ChiffreAffaire() { }

        public ChiffreAffaire(string y, List<Facture> listF)
        {
            this.year = y;
            listFac = listF;                                    
        }

        public ChiffreAffaire(List<Facture> listF)
        {
            listFac = listF;
            
        }

        public ChiffreAffaire (string y)
        {
            this.year = y;
        }

        public string GetYear()
        {
            return this.year;
        }

        public double GetCAD()
        {
            return this.chiffreAffairesDu;
        }

        public double GetCAR()
        {
            return this.chiffreAffairesReel;
        }
    }
}
