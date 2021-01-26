using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Facturation.Shared
{
    public class BusinessData : IBusinessData
    {
        List<Facture> listeFactures;
        List<FactureDTO> listeFacturesDTO;
        List<ChiffreAffaire> listeCas;
        public BusinessData()
        {
            listeFactures = new List<Facture>();
            LoadFactures();
            listeCas = new List<ChiffreAffaire>();
            listeFacturesDTO = new List<FactureDTO>();
            MakeListFacDTO();
            LoadCAs();       
        }

        public void MakeListFacDTO()
        {
            listeFacturesDTO = new List<FactureDTO>();
            foreach(Facture f in this.listeFactures)
            {
                FactureDTO facDTO = new FactureDTO(f);
                this.listeFacturesDTO.Add(facDTO);
            }            
        }
        public List<ChiffreAffaire> GetListCas()
        {
            return this.listeCas;
        }
        public List<Facture> GetListFac()
        {
            return this.listeFactures;
        }
        public void LoadFactures()
        {
            Facture f11 = new Facture("F011", "Laurent Varden", new DateTime(2020, 12, 01), new DateTime(2020, 12, 10), 15000, 0);
            Facture f10 = new Facture("F010", "John Doe", new DateTime(2020, 11, 2), new DateTime(2020, 12, 2), 37575, 37575);
            Facture f9 = new Facture("F009", "Gil Pybert", new DateTime(2020, 10, 15), new DateTime(2020, 11, 25), 7950, 7950);
            Facture f8 = new Facture("F008", "Gil Pybert", new DateTime(2020, 05, 15), new DateTime(2020, 07, 25), 9522, 9522);
            Facture f7 = new Facture("F007", "John Cologne", new DateTime(2020, 12, 10), new DateTime(), 4550, 0);
            Facture f6 = new Facture("F006", "Floyd Jenkins", new DateTime(2019, 05, 2), new DateTime(2019, 6, 18), 6253, 6253);
            Facture f5 = new Facture("F005", "Luis Juarez", new DateTime(2019, 05, 2), new DateTime(2019, 6, 18), 23517, 23517);
            Facture f4 = new Facture("F004", "Franz Helke", new DateTime(2019, 01, 17), new DateTime(2019, 02, 5), 6253, 6253);
            Facture f3 = new Facture("F003", "Jean Fonce", new DateTime(2019, 02, 15), new DateTime(2019, 5, 3), 17523, 17523);
            Facture f2 = new Facture("F002", "John Cologne", new DateTime(2018, 09, 10), new DateTime(2018, 10, 25), 12578, 12578);
            Facture f1 = new Facture("F001", "John Cologne", new DateTime(2018, 02, 10), new DateTime(2018, 04, 25), 15535, 15535);

            this.listeFactures.Add(f1);
            this.listeFactures.Add(f2);
            this.listeFactures.Add(f3);
            this.listeFactures.Add(f4);
            this.listeFactures.Add(f5);
            this.listeFactures.Add(f6);
            this.listeFactures.Add(f7);
            this.listeFactures.Add(f8);
            this.listeFactures.Add(f9);
            this.listeFactures.Add(f10);
            this.listeFactures.Add(f11);
        }

        // Je suis partis sur un Chiffre d'Affaire annuel plûtôt que Mensuel (pas par rébellion, je n'avais pas vu qu'il fallait le faire en mensuel.. j'ai 
        // pensé mettre une valeur ajoutée en faisant le projet sur plusieurs années, puis vers la fin, j'ai réalisé que vous demandiez un mensuel..)

        public void LoadCAs()
        {
            ChiffreAffaire ca2018 = new ChiffreAffaire("2018");
            ChiffreAffaire ca2019 = new ChiffreAffaire("2019");
            ChiffreAffaire ca2020 = new ChiffreAffaire("2020");            

            this.listeCas.Add(ca2018);
            this.listeCas.Add(ca2019);
            this.listeCas.Add(ca2020);            

            foreach (Facture f in listeFactures)
            {
                
                foreach (ChiffreAffaire ca in this.listeCas)
                {
                    if (f.dateEmission.Year == Int32.Parse(ca.year))
                    {
                        ca.chiffreAffairesDu += f.montantDu;
                        ca.chiffreAffairesReel += f.montantRegle;
                    }
                }

                /*if (f.dateEmission.Year == 2018)
                {
                    ca2018.chiffreAffairesDu += f.montantDu;
                    ca2018.chiffreAffairesReel += f.montantRegle;
                    *//*ca2018.listFac.Add(f);*//*
                }
                else if (f.dateEmission.Year == 2019)
                {
                    ca2019.chiffreAffairesDu += f.montantDu;
                    ca2019.chiffreAffairesReel += f.montantRegle;
                    *//*ca2019.listFac.Add(f);*//*
                }
                else if (f.dateEmission.Year == 2020)
                {
                    ca2020.chiffreAffairesDu += f.montantDu;
                    ca2020.chiffreAffairesReel += f.montantRegle;
                    *//*ca2020.listFac.Add(f);*//*
                }
                else if (f.dateEmission.Year == 2021)
                {
                    ca2021.chiffreAffairesDu += f.montantDu;
                    ca2021.chiffreAffairesReel += f.montantRegle;
                    *//*ca2021.listFac.Add(f);*//*
                }*/
            }


        }

        public void AddFac(FactureDTO factureDTO)
        {
            Facture fac = new Facture(factureDTO);
            this.listeFactures.Add(fac);
            foreach (var f in listeFactures)
            {
                Console.WriteLine(f.code);
            }
        }

        public void AddFac(FactureDTO f, SqlDbContext d)
        {
            throw new NotImplementedException();
        }

        public void addAllFac(List<Facture> facList, SqlDbContext dbContext)
        {
            throw new NotImplementedException();
        }

        public void addAllCas(List<ChiffreAffaire> caList, SqlDbContext dbContext)
        {
            throw new NotImplementedException();
        }

        /*public IEnumerable<Facture> Factures => listeFactures;*/
        public IEnumerable<FactureDTO> FacturesDTO => listeFacturesDTO;
        public IEnumerable<ChiffreAffaire> CAs => listeCas;

        public IEnumerable<Facture> Factures => listeFactures;
    }

}

// J'ai Passé des heures à essayer de fonctionner par Dictionnaire
// Malheureusement, je n'ai jamais vu la notion, il est maintenant 1h du mat, j'abandonne
// (Je voulais créer des objets ChiffreAffaire dynamiques suivant la valeur année dans la Date de Facture
// Je me rabats donc sur des objets ChiffreAffaire instanciés en Dur..



/*       public List<ChiffreAffaire> GenerateCAs(List<Facture> fL)
       {
           Dictionary<string, ChiffreAffaire> dicoCA = new Dictionary<string, ChiffreAffaire>();
           List<ChiffreAffaire> listCA = new List<ChiffreAffaire>();

           foreach (Facture facture in fL)
           {
               string year = facture.getDateR().Substring(facture.getDateR().Length - 4);

               if (!dicoCA.ContainsKey("ca" + year))
               {
                   dicoCA.Add("ca" + year, new ChiffreAffaire(year));
               }
               ChiffreAffaire ca = dicoCA.GetValueOrDefault("ca" + year);
               ca.listFac.Add(facture);
           }

           foreach (KeyValuePair<string, ChiffreAffaire> ca in dicoCA)
           {
               listCA.Add(ca.Value);
           }

           return listCA;
       }*/