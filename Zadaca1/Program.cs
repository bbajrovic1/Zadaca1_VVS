using System;
using System.Collections.Generic;

namespace Zadaca1
{
    internal class Program
    {
        static Izbori napuni()
        {
            
           Stranka stranka1 = new Stranka("SDA");
           Stranka stranka2 = new Stranka("SDP");
           Stranka stranka3 = new Stranka("NIP");
           Stranka stranka4 = new Stranka("DF");
           
           Kandidat kandidat1_1 = new Kandidat("Elma", "Elmic", "adresa4", new DateTime(1990, 5, 3), "111J967", "0305990000000", stranka1, true);
           Kandidat kandidat1_2 = new Kandidat("Husein", "Husic", "adresa5", new DateTime(1997, 6, 23), "345K907", "2306997000000", stranka1, false);
           Kandidat kandidat2_1 = new Kandidat("Bakir", "Semic", "adresa6", new DateTime(1990, 5, 3), "111J967", "0305990000000", stranka2, true);
           Kandidat kandidat2_2 = new Kandidat("Selma", "Suljic", "adresa7", new DateTime(1991, 1, 3), "111J967", "0301991000000", stranka2, false);
           Kandidat kandidat3_1 = new Kandidat("Adnan", "Adic", "adresa8", new DateTime(1992, 2, 5), "987K543", "0502992000000", stranka3, true);
           Kandidat kandidat3_2 = new Kandidat("Toni", "Senic", "adresa9", new DateTime(1993, 3, 6), "111J961", "0603993000000", stranka3, false);
           Kandidat kandidat4_1 = new Kandidat("Mia", "Santic", "adresa10", new DateTime(1994, 11, 6), "111J962", "0611994000000", stranka4, true);
           Kandidat kandidat4_2 = new Kandidat("Mijo", "Mijic", "adresa11", new DateTime(1995, 12, 14), "111J963", "1412995000000", stranka4, false);



           
           stranka1.Kandidati = new List<Kandidat>{ kandidat1_1, kandidat1_2};
           stranka2.Kandidati = new List<Kandidat>{ kandidat2_1, kandidat2_2};
           stranka3.Kandidati = new List<Kandidat>{ kandidat3_1, kandidat3_2};
           stranka4.Kandidati = new List<Kandidat>{ kandidat4_1, kandidat4_2};
           List<Stranka> stranke = new List<Stranka>{ stranka1, stranka2, stranka3, stranka4};
           List<Kandidat> nezavisniKandidati = new List<Kandidat>{ 
                                                new Kandidat("Samir", "Prusac", "adresa12", new DateTime(1995, 5, 8), "111J967", "0805995000000"),
                                                new Kandidat("Sanela", "Emic", "adresa13", new DateTime(1996, 8, 10), "112K967", "1008996000000"),
                                                new Kandidat("Antonela", "Maric", "adresa14", new DateTime(1997, 9, 9), "114M967", "0909997000000")};

            kandidat1_1.ProsleStranke = new List<Tuple<Stranka, DateTime, DateTime>> 
            { new Tuple<Stranka, DateTime, DateTime>(stranka3, new DateTime(2000, 3, 1), new DateTime(2004, 4, 2)),
                new Tuple<Stranka, DateTime, DateTime>(stranka2, new DateTime(2005, 3, 1), new DateTime(2007, 4, 2))
            };


           List<Glasac> glasaci = new List<Glasac>{ 
               new Glasac("Dino", "Dinic", "adresa1", new DateTime(1988, 12, 4), "111E222", "0412988000000"),
               new Glasac("Anela", "Anic", "adresa2", new DateTime(1990, 4, 2), "123E222", "0204990111111"),
               new Glasac("Sabina", "Sabic", "adresa3", new DateTime(1979, 2, 8), "333E222", "0802979333333")
           };

            Izbori izbori = new Izbori(stranke, nezavisniKandidati, glasaci);
            return izbori;

        }
        
        static void Main(string[] args)
        {
            Izbori izbori = napuni();

            int odabir;

            do
            {
                Console.WriteLine("Odaberi opciju:\n1. glasaj\n2. prikazi rezultate\n3. rezultati za stranke\n4. rezultati za rukovodstva\n5. resetuj glasaca\n0 za kraj");
                odabir = Convert.ToInt32(Console.ReadLine());
                if (odabir == 1)
                {
                    string kod;
                    do                         
                    {
                        Console.WriteLine("Unesi identifikacijski kod: ");
                        kod = Console.ReadLine();
                        if (!izbori.identificirajGlasaca(kod))
                            Console.WriteLine("Identifikacija glasaca nije uspjesna, pokusajte ponovo\n");
                        else
                        {   

                            
                            bool glasao = false;
                            do
                            {
                                Console.WriteLine("Odaberi opciju glasanja: \n1. stranka\n2. kandidati iz stranke\n3. nezavisni kandidat ");
                                int opcijaGlasanja = Convert.ToInt32(Console.ReadLine());
                                if (opcijaGlasanja == 1)
                                {
                                    Console.WriteLine("Odaberite jednu stranku: ");
                                    izbori.prikaziStranke();
                                    int odabirStranke = Convert.ToInt32(Console.ReadLine());
                                    izbori.glasajZaStranku(kod, odabirStranke);
                                    glasao = true;
                                }
                                else if (opcijaGlasanja == 2)
                                {
                                    Console.WriteLine("Odaberite jednu stranku: ");
                                    izbori.prikaziStranke();
                                    int odabirStranke = Convert.ToInt32(Console.ReadLine());
                                    izbori.prikaziKandidateIzStranke(odabirStranke);
                                    Console.WriteLine("Odaberite kandidate (0 za kraj): ");
                                    List<int> odabraniKandidati = new List<int>();
                                    int noviKandidat = 0;
                                    do
                                    {
                                        noviKandidat = Convert.ToInt32(Console.ReadLine());
                                        if (noviKandidat != 0 && !odabraniKandidati.Contains(noviKandidat))
                                        {
                                            odabraniKandidati.Add(noviKandidat);
                                            Console.WriteLine("Da li zelite prikaz historije stranaka za odabranog kandidata? 1-da 0-ne");
                                            int prikaziProsleStranke = Convert.ToInt32(Console.ReadLine());
                                            if(prikaziProsleStranke == 1)
                                                izbori.prikaziProsleStrankeZaKandidata(odabirStranke, noviKandidat);
                                        }


                                    } while (noviKandidat != 0);
                                    izbori.glasajZaKandidateIzStranke(kod, odabirStranke, odabraniKandidati);
                                    glasao = true;

                                }
                                else if (opcijaGlasanja == 3)
                                {
                                    Console.WriteLine("Odaberite jednog nezavisnog kandidata: ");
                                    izbori.prikaziNezavisneKandidate();
                                    int odabraniNezavisni = Convert.ToInt32(Console.ReadLine());
                                    izbori.glasajZaNezavisnog(kod, odabraniNezavisni);
                                    glasao = true;
                                }
                                else
                                {
                                    Console.WriteLine("Izabrali ste nepostojecu opciju, pokusajte ponovo");
                                }
                            } while (!glasao);
                        }
                    } while (izbori.identificirajGlasaca(kod));


                }
                else if (odabir == 2)
                {
                    Console.WriteLine("Izlaznost na izborima je " + izbori.izracunajIzlaznost() + " %.\n");
                    Console.WriteLine("Trenutne mandatorne stranke su:\n");
                    izbori.ispisiMandatorneStranke();
                    Console.WriteLine("Trenutni kandidati sa mandatima su:\n");
                    izbori.ispisiKandidateSaMandatima();

                }
                else if (odabir == 3)
                {
                    izbori.prikaziRezultateZaSveStranke();
                }
                else if (odabir == 4)
                {
                    Console.WriteLine("Odaberite jednu stranku: ");
                    izbori.prikaziStranke();
                    int odabirStranke = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine(izbori.prikaziRezultateRukovodstvaZaStranku(odabirStranke));
                }
                //FUNKCIONALNOST 5 - EMA MEKIC
                else if (odabir == 5)
                {
                    string id;
                        Console.WriteLine("Unesi ID glasaca cije glasove zelite resetovati: ");
                        id = Console.ReadLine();
                        
                        Console.WriteLine("Unesite sifru:");
                        string sifra = Console.ReadLine();
                        int brojGresaka = 1;

                        do
                        {
                            if(sifra != "VVS20222023")
                            {
                                brojGresaka++;
                                Console.WriteLine("Neispravna sifra, unesite ponovo:");
                                sifra = Console.ReadLine();
                            }
                            else
                            {
                                break;
                            }
                        } while (brojGresaka < 3);


                        if (brojGresaka == 3)
                            return;


                        izbori.resetujGlasoveZaGlasaca(id);
                        
                    
                }
                
                else if(odabir != 0)
                {
                    Console.WriteLine("Neispravna opcija, unesite ponovo\n");
                }
                
                

            } while (odabir != 0);





        }
    }
}
