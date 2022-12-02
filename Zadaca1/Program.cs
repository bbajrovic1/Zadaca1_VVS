using System;
using System.Collections.Generic;

namespace Zadaca1
{
    internal class Program
    {
        static Izbori napuni() //Merjem
        {
            
           Stranka stranka1 = new Stranka("SDA");
           Stranka stranka2 = new Stranka("SDP");
           Stranka stranka3 = new Stranka("NIP");
           Stranka stranka4 = new Stranka("DF");

           Kandidat kandidat1_1 = new Kandidat("Elma", "Elmic", "1112967", stranka1);
           Kandidat kandidat1_2 = new Kandidat("Husein", "Husic", "2102991", stranka1);
           Kandidat kandidat2_1 = new Kandidat("Bakir", "Semic", "3109001", stranka2);
           Kandidat kandidat2_2 = new Kandidat("Selma", "Suljic", "4109977", stranka2);
           Kandidat kandidat3_1 = new Kandidat("Adnan", "Adic", "5107967", stranka3);
           Kandidat kandidat3_2 = new Kandidat("Toni", "Senic", "6106997", stranka3);
           Kandidat kandidat4_1 = new Kandidat("Mia", "Santic", "7105957", stranka4);
           Kandidat kandidat4_2 = new Kandidat("Mijo", "Mijic", "8104937", stranka4);

           stranka1.Kandidati = new List<Kandidat>{ kandidat1_1, kandidat1_2};
           stranka2.Kandidati = new List<Kandidat>{ kandidat2_1, kandidat2_2};
           stranka3.Kandidati = new List<Kandidat>{ kandidat3_1, kandidat3_2};
           stranka4.Kandidati = new List<Kandidat>{ kandidat4_1, kandidat4_2};
           List<Stranka> stranke = new List<Stranka>{ stranka1, stranka2, stranka3, stranka4};
           List<Kandidat> nezavisniKandidati = new List<Kandidat>{ 
                                                new Kandidat("Samir", "Prusac", "9"),
                                                new Kandidat("Sanela", "Emic", "10"),
                                                new Kandidat("Antonela", "Maric", "11")};
           
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

            do//resolved issue - Bakir
            {
                Console.WriteLine("Odaberi opciju:\n1. glasaj\n2. prikazi rezultate\n0 za kraj");
                odabir = Convert.ToInt32(Console.ReadLine());
                if (odabir == 1)
                {
                    string kod;
                    do                         //resolved issue - Bakir
                    {
                        Console.WriteLine("Unesi identifikacijski kod: ");
                        kod = Console.ReadLine();
                        if (!izbori.identificirajGlasaca(kod))
                            Console.WriteLine("Identifikacija glasaca nije uspjesna, pokusajte ponovo\n");
                        else
                        {   

                            //Stefani
                            //pošto nije prava greška funkcionalnosti, da druge kolege ne bih remetila, neću mijenjati if else u switch case
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
                                    izbori.glasajZaStranku(odabirStranke);
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
                                            odabraniKandidati.Add(noviKandidat);

                                    } while (noviKandidat != 0);
                                    izbori.glasajZaKandidateIzStranke(odabirStranke, odabraniKandidati);
                                    glasao = true;

                                }
                                else if (opcijaGlasanja == 3)
                                {
                                    Console.WriteLine("Odaberite jednog nezavisnog kandidata: ");
                                    izbori.prikaziNezavisneKandidate();
                                    int odabraniNezavisni = Convert.ToInt32(Console.ReadLine());
                                    izbori.glasajZaNezavisnog(odabraniNezavisni);
                                    glasao = true;
                                }
                                else
                                {
                                    Console.WriteLine("Izabrali ste nepostojecu opciju, pokusajte ponovo"); //resolved - Mirza
                                }
                            } while (!glasao);
                        }
                    } while (izbori.identificirajGlasaca(kod)); // resolved - Mirza


                }
                else if (odabir == 2)
                {
                    Console.WriteLine("Izlaznost na izborima je " + izbori.izracunajIzlaznost() + " %.\n");
                    Console.WriteLine("Trenutne mandatorne stranke su:\n");
                    izbori.ispisiMandatorneStranke();
                    Console.WriteLine("Trenutni kandidati sa mandatima su:\n");
                    izbori.ispisiKandidateSaMandatima();

                }
                else if(odabir != 0)
                {
                    Console.WriteLine("Neispravna opcija, unesite ponovo\n");     //resolved issue - Ema
                }
                
                

            } while (odabir != 0);





        }
    }
}
