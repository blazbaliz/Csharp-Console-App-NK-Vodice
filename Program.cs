using System;
using System.IO;
using System.Text;

namespace Seminarska
{
    class Program
    {
        /*"Izjavljam, da sem nalogo opravil samostojno in da sem njen avtor. Zavedam se, da v primeru, če izjava prvega stavka ni resnična, kršim disciplinska pravila."*/

        static void PrvaStran()
        {
            //prva stran
            Console.WriteLine("\n\n\n\n\n\n");
            CenterText("---------------------------------------------------------\n");
            CenterText("Dobrodošli v aplikaciji Nogometnega kluba Vodice\n");
            CenterText("     ___     ____ ");
            CenterText(" /| |   | /|    / ");
            CenterText("/ |    / / |  -/- ");
            CenterText("|   /    |  / ");
            CenterText("|  /___  | /\n");
            CenterText("Vnesite 1 za meni  ");
            CenterText("Vnesite X za izhod\n");
            CenterText("---------------------------------------------------------");
        }

        static void Izpis(Igralec[] igralci)
        {
            Console.WriteLine("Izbris igralcev");
            Console.WriteLine("-----------------");
            for (int i = 0; i < igralci.Length; i++)
            {
                Console.Write("#" + i + " ") ;
                igralci[i].IzpisIme();
                Console.WriteLine();
            }
        }

        static void IzpisClanov2(Igralec[] igralci)
        {
           Array.Sort(igralci, delegate (Igralec igralec1, Igralec igralec2) {
                return igralec1.kategorija.CompareTo(igralec2.kategorija);
            });

            for (int i = 0; i < igralci.Length; i++)
            {
                if (igralci[i].kategorija == "Člani")
                {
                    Console.Write("#" + i + " ");
                    igralci[i].IzpisIme();
                    Console.WriteLine();
                }
            }

        }

        static void IzpisKadetov2(Igralec[] igralci)
        {
            SortirajKadete(igralci);
            for (int i = 0; i <igralci.Length;i++)
            { 
                if(igralci[i].kategorija == "Kadeti")
                {
                    Console.Write("#" + i + " ");
                    igralci[i].IzpisIme();
                    Console.WriteLine();
                }
                    
                
            }
        }


        static void SortirajKadete(Igralec[] igralci)
        {
            Igralec[] sortiraj = new Igralec[igralci.Length];
            for (int i = 0; i < igralci.Length; i++)
            {
                for (int j = 0; j < igralci.Length; j++)
                {
                    if (igralci[j].kategorija == "Kadeti")
                    {
                        sortiraj[i] = igralci[j];
                        i++;
                    }
                }
                for (int j = 0; j < igralci.Length; j++)
                {
                    if (igralci[j].kategorija == "Mladinci")
                    {
                        sortiraj[i] = igralci[j];
                        i++;
                    }
                }
                for (int j = 0; j < igralci.Length; j++)
                {
                    if (igralci[j].kategorija == "Člani")
                    {
                        sortiraj[i] = igralci[j];
                        i++;
                    }
                }
            }
            for(int i = 0; i < igralci.Length; i++)
            {
                igralci[i] = sortiraj[i];
            }


        }

        static void IzpisMladincov2(Igralec[] igralci)
        {
            Array.Sort(igralci, delegate (Igralec igralec1, Igralec igralec2) {
                return igralec2.kategorija.CompareTo(igralec1.kategorija);
            });

            for (int i = 0; i < igralci.Length; i++)
            {
                if (igralci[i].kategorija == "Mladinci")
                {
                    Console.Write("#" + i + " ");
                    igralci[i].IzpisIme();
                    Console.WriteLine();
                }
            }

        }

        static void IzpisLastnostiClani(Igralec[] igralci)
        {
            for (int i = 0; i < igralci.Length; i++)
            {

                if (igralci[i].kategorija == "Člani")
                {
                    Console.WriteLine("         # " + i + " #");
                    igralci[i].Izpis();
                    Console.WriteLine("---------------------");
                }

            }
        }

        static void IzpisLastnostiKadeti(Igralec[] igralci)
        {
            for (int i = 0; i < igralci.Length; i++)
            {

                if (igralci[i].kategorija == "Kadeti")
                {
                    Console.WriteLine("         # " + i + " #");
                    igralci[i].Izpis();
                    Console.WriteLine("---------------------");
                }

            }
        }

        static void IzpisLastnostiMladinci(Igralec[] igralci)
        {
            for (int i = 0; i < igralci.Length; i++)
            {

                if (igralci[i].kategorija == "Mladinci")
                {
                    Console.WriteLine("         # " + i + " #");
                    igralci[i].Izpis();
                    Console.WriteLine("---------------------");
                }

            }
        }

        static void UrediIgralca(Igralec[] igralci)
        {
            Console.WriteLine(" Vnesi zaporedno številko igralca za urejanje lastnosti");
            int abc = Convert.ToInt32(Console.ReadLine());
            igralci[abc].Uredi();
        }

        static void PovprecnaStarost(Igralec[] igralci)
        {
            int sestLetnikov = 0;
            int sestLetnikovMladinci = 0;
            int sestLetnikovClani = 0;
            int sestLetnikovKadeti = 0;
            int starost;
            int x = 0; int y = 0; int z = 0;
            foreach (Igralec a in igralci)
            {
                starost = a.Starost();
                sestLetnikov += a.Starost();
                if (a.kategorija == "Mladinci")
                {
                    sestLetnikovMladinci += a.Starost();
                    x++;
                }
                else if (a.kategorija == "Kadeti")
                {
                    sestLetnikovKadeti += a.Starost();
                    y++;
                }
                else if (a.kategorija == "Člani")
                {
                    sestLetnikovClani += a.Starost();
                    z++;
                }
            }
            int povpStarost = sestLetnikov / igralci.Length;
            int povpStarostClani = sestLetnikovClani / z;
            int povpStarostKadeti = sestLetnikovKadeti / y;
            int povpStarostMladinci = sestLetnikovMladinci / x;
            Console.WriteLine("\nPovprečna starost vseh igralcev: " + povpStarost);
            Console.WriteLine("Povprečna starost članov: " + povpStarostClani);
            Console.WriteLine("Povprečna starost kadetov je: " + povpStarostKadeti);
            Console.WriteLine("Povprečna starost mladincov je: " + povpStarostMladinci);
        }

        static void PovprecjeKategorije(Igralec[] igralci)

        {
            int clani = 0;int mladinci = 0;int kadeti = 0;
            foreach (Igralec a in igralci)
            {
                if (a.kategorija == "Mladinci")
                {
                    mladinci++;
                }
                else if (a.kategorija == "Kadeti")
                {
                    kadeti++;
                }
                else if (a.kategorija == "Člani")
                {
                    clani++;
                }
            }
            Console.WriteLine(" \nPovprečno število igralcev v posamezni kategoriji:");
            Console.WriteLine("Člani: " + clani);
            Console.WriteLine("Kadeti: " + kadeti) ;
            Console.WriteLine("Mladinci: " + mladinci);
        }
        
        static void PovprecjePozicije(Igralec[] igralci)
        {
            int napad = 0; int sredina = 0; int obramba = 0; int golman = 0;
            int napMla, napKad, napCla, obrMla, obrCla, obrKad, sredMla, sredCla, sredKad, golMla, golCla, golKad;
            napMla = napKad = napCla = obrMla = obrCla = obrKad = sredMla = sredCla = sredKad = golMla = golCla = golKad = 0;
            foreach (Igralec a in igralci)
            {
                if (a.pozicija == "Napad")
                {
                    napad++;
                    if (a.kategorija == "Mladinci")
                    {
                        napMla++;
                    }
                    else if (a.kategorija == "Kadeti")
                    {
                        napKad++;
                    }
                    else if (a.kategorija == "Člani")
                    {
                        napCla++;
                    }
                }
                else if (a.pozicija == "Sredina")
                {
                    sredina++;
                    if (a.kategorija == "Mladinci")
                    {
                        sredMla++;
                    }
                    else if (a.kategorija == "Kadeti")
                    {
                        sredKad++;
                    }
                    else if (a.kategorija == "Člani")
                    {
                        sredCla++;
                    }
                }
                else if (a.pozicija == "Obramba")
                {
                    obramba++;
                    if (a.kategorija == "Mladinci")
                    {
                        obrMla++;
                    }
                    else if (a.kategorija == "Kadeti")
                    {
                        obrKad++;
                    }
                    else if (a.kategorija == "Člani")
                    {
                        obrCla++;
                    }
                }
                else if (a.pozicija == "Golman")
                {
                    golman++; 
                    if (a.kategorija == "Mladinci")
                    {
                        golMla++;
                    }
                    else if (a.kategorija == "Kadeti")
                    {
                        golKad++;
                    }
                    else if (a.kategorija == "Člani")
                    {
                        golCla++;
                    }
                }
            }

            Console.WriteLine("\nPovprečno število igralcev na posamezni poziciji");
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("         Skupno | Člani | Kadeti | Mladinci");
            Console.WriteLine("Napad:      " + napad + "   |   " + napCla + "   |   " + napKad + "    |     " + napMla);
            Console.WriteLine("Sredina:    " + sredina + "   |   " + sredCla + "   |   " + sredKad + "    |     " + sredMla);
            Console.WriteLine("Obramba:    " + obramba + "   |   " + obrCla + "   |   " + obrKad + "    |     " + obrMla);
            Console.WriteLine("Gol:        " + golman + "   |   " + golCla + "   |   " + golKad + "    |     " + golMla);
        }

        static void Shrani(Igralec[] igralci)
        {
            string[] igralciZaDatoteko = new string[igralci.Length];   
            for (int i = 0; i < igralci.Length; i++)
            {
                igralciZaDatoteko[i] = igralci[i].ToString();
            }
            File.WriteAllLines("datoteka.txt", igralciZaDatoteko);
        }

        static void NajbolsiStrelci(Igralec[] igralci)
        {
            Array.Sort(igralci, delegate (Igralec igralec1, Igralec igralec2) {
                return igralec2.stDosezenihGolov.CompareTo(igralec1.stDosezenihGolov);
            });
            Console.WriteLine(" Najbolši strelci");
            Console.WriteLine("---------------");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i + 1 + ") " + igralci[i].ime + " " + igralci[i].priimek + " " + igralci[i].stDosezenihGolov + " golov");
            }
        }

        static void NajvecOdigranihTekem(Igralec[] igralci)
        {
            Array.Sort(igralci, delegate (Igralec igralec1, Igralec igralec2) {
                return igralec2.stOdigranihTekem.CompareTo(igralec1.stOdigranihTekem);
            });
            Console.WriteLine(" Odigrane tekme");
            Console.WriteLine("---------------");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i + 1 + ") " + igralci[i].ime + " " + igralci[i].priimek + ": " + igralci[i].stOdigranihTekem + " tekem");
            }
        }

        static void razmerjeTekmaGol(Igralec[] igralci)
        {
            foreach(Igralec a in igralci)
            {
                if (Convert.ToInt32(a.razmerjeTekmaGol) == 0)
                {
                    a.razmerjeTekmaGol = (Convert.ToDouble(a.stDosezenihGolov) / a.stOdigranihTekem);
                }
            }
            Array.Sort(igralci, delegate (Igralec igralec1, Igralec igralec2) {
                return igralec2.razmerjeTekmaGol.CompareTo(igralec1.razmerjeTekmaGol);
            });
            Console.WriteLine("Razmerje tekma/gol");
            Console.Write("--------------------");
            for(int i = 0; i < 10; i++)
            {
                Console.WriteLine();
                Console.Write(i + 1 + ") ");
                igralci[i].IzpisIme();
                Console.Write(" " + String.Format("{0:0.00}", igralci[i].razmerjeTekmaGol) + " golov na tekmo");
            }
            Console.WriteLine();
           

        }

        static void NajboljsaPlaca(Igralec[] igralci)
        {
            Array.Sort(igralci, delegate (Igralec igralec1, Igralec igralec2) {
                return igralec2.placa.CompareTo(igralec1.placa);
            });
            Console.WriteLine(" Najbolje plačani igralci");
            Console.WriteLine("------------------------");
            for(int i = 0; i < 10; i++)
            {
                if(igralci[i].placa != 0)
                {
                    Console.WriteLine(i + 1 + ") " + igralci[i].ime + " " + igralci[i].priimek + " " + string.Format("{0:n0}", igralci[i].placa) + " €") ;
                }
            }
        }

        static void CenterText(string text)
        {
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (text.Length / 2)) + "}", text));
        } 
        
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            string[] tabela = File.ReadAllLines("datoteka.txt");

            Igralec[] igralci = new Igralec[tabela.Length];

            for(int i = 0; i < tabela.Length; i++)
            {
                igralci[i] = new Igralec(tabela[i]);
            }

            PrvaStran();

            //meni 
            
            while (true)
            {
                string vnos = Console.ReadKey().KeyChar.ToString();
                if (vnos == "1")
                {
                    
                    while (true)
                    {   
                        //MENI GLAVNI
                        Console.Clear();
                        Console.WriteLine("Vnesite 1 za izpis ekip");
                        Console.WriteLine("Vnesite 2 za dodajanje igralcev");
                        Console.WriteLine("Vnesite 3 za izbris igralcev");
                        Console.WriteLine("Vnesite 4 za statistike");
                        Console.WriteLine("Vnesite X za izhod");

                       
                        
                        while (true)
                        {
                            string izbira = Console.ReadKey().KeyChar.ToString();
                            //izpis ekip
                            if (izbira == "1")
                            {
                            label2:
                            Console.Clear();
                            Console.WriteLine("Vnesite 1 za izpis članov");
                            Console.WriteLine("Vnesite 2 za izpis kadetov");
                            Console.WriteLine("Vnesite 3 za izpis mladincov");
                            Console.WriteLine("Vnesite X za začetni meni");
                                while (true)
                                {
                                    string ekipe = Console.ReadKey().KeyChar.ToString();
                                    //izpis clanov
                                    if (ekipe == "1")
                                    {
                                        clani:
                                        Console.Clear();
                                        IzpisClanov2(igralci);
                                        Console.WriteLine();
                                        Console.WriteLine("Vnesite 1 za prikaz lastnosti");
                                        Console.WriteLine("Vnesite 2 za urejanje igralca");
                                        Console.WriteLine("Vnesite X za nazaj");
                                            
                                        while (true)
                                        {
                                            string a = Console.ReadKey().KeyChar.ToString();
                                            if (a == "1")
                                            {
                                                Console.Clear();
                                                IzpisLastnostiClani(igralci);
                                                Console.WriteLine("Pritisni katerokoli tipko za nazaj");
                                                Console.ReadKey().KeyChar.ToString();
                                                goto clani;
                                            }
                                            else if (a == "2")
                                            {
                                                Console.WriteLine(" Vnesi zaporedno številko igralca za urejanje lastnosti");
                                                while (true)
                                                {
                                                    int abc;
                                                    try
                                                    {
                                                         abc = Convert.ToInt32(Console.ReadLine());
                                                    }
                                                    catch
                                                    {
                                                        Console.WriteLine("Napačen format");
                                                        continue;
                                                    }
                                                    if(abc < igralci.Length &&igralci[abc].kategorija == "Člani")
                                                    {                                                      
                                                        igralci[abc].Uredi();
                                                        Shrani(igralci);
                                                        goto clani;
                                                    }                                                 
                                                    else
                                                    {
                                                        Console.WriteLine("Ta igralec ne obstaja.");
                                                    }
                                                }                                                
                                            }

                                            else if (a == "x" || a == "X")
                                            {
                                                goto label2;
                                            }
                                            else
                                            {
                                                Console.WriteLine(" Neveljavna izbira");
                                                //Console.ReadKey();
                                            }
                                        }
                                
                            }
                                    //izpis kadetov
                                    else if (ekipe == "2")
                                    {       
                                        kadeti:
                                        Console.Clear();                                           
                                        IzpisKadetov2(igralci);                                            
                                        Console.WriteLine();
                                        Console.WriteLine("Vnesite 1 za prikaz lastnosti");
                                        Console.WriteLine("Vnesite 2 za urejanje igralca");
                                        Console.WriteLine("Vnesite X za nazaj");
                                        while(true)
                                        {
                                                string a = Console.ReadKey().KeyChar.ToString();
                                                if (a == "1")
                                                {
                                                    Console.Clear();
                                                    IzpisLastnostiKadeti(igralci);
                                                    Console.WriteLine("Pritisni katerokoli tipko za nazaj");
                                                    Console.ReadKey().KeyChar.ToString();
                                                    goto kadeti;
                                                }

                                            else if (a == "2")
                                            {
                                                Console.WriteLine(" Vnesi zaporedno številko igralca za urejanje lastnosti");
                                                while (true)
                                                {
                                                    int abc;
                                                    try
                                                    {
                                                        abc = Convert.ToInt32(Console.ReadLine());
                                                    }
                                                    catch
                                                    {
                                                        Console.WriteLine("Napačen format");
                                                        continue;
                                                    }
                                                    if (abc < igralci.Length && igralci[abc].kategorija == "Kadeti")
                                                    {
                                                        igralci[abc].Uredi();
                                                        Shrani(igralci);
                                                        goto kadeti;
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Ta igralec ne obstaja.");
                                                    }
                                                }
                                            }

                                            else if (a == "x" || a == "X")
                                            {
                                                goto label2;
                                            }
                                            else
                                            {
                                                Console.WriteLine(" Neveljavna izbira");
                                            }
                                        }   
                                    }
                                        
                                    
                                    //izpis mladincov
                                    else if (ekipe == "3")
                                    {   
                                        mladinci:
                                        Console.Clear();
                                        IzpisMladincov2(igralci);
                                        Console.WriteLine();
                                        Console.WriteLine("Vnesite 1 za prikaz lastnosti");
                                        Console.WriteLine("Vnesite 2 za urejanje igralca");
                                        Console.WriteLine("Vnesite X za nazaj");
                                        while (true)
                                        {
                                            string a = Console.ReadKey().KeyChar.ToString();
                                            if (a == "1")
                                            {
                                                Console.Clear();
                                                IzpisLastnostiMladinci(igralci);
                                                Console.WriteLine("Pritisni katerokoli tipko za nazaj");
                                                Console.ReadKey().KeyChar.ToString();
                                                goto mladinci;
                                            }
                                            else if (a == "2")
                                            {
                                                Console.WriteLine(" Vnesi zaporedno številko igralca za urejanje lastnosti");
                                                while (true)
                                                {
                                                    int abc;
                                                    try
                                                    {
                                                        abc = Convert.ToInt32(Console.ReadLine());
                                                    }
                                                    catch
                                                    {
                                                        Console.WriteLine("Napačen format");
                                                        continue;
                                                    }
                                                    if (abc < igralci.Length && igralci[abc].kategorija == "Mladinci")
                                                    {
                                                        igralci[abc].Uredi();
                                                        Shrani(igralci);
                                                        goto mladinci;
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Ta igralec ne obstaja.");
                                                    }
                                                }
                                            }

                                            else if (a == "x" || a == "X")
                                            {
                                                goto label2;
                                            }
                                            else
                                            {
                                                Console.WriteLine(" Neveljavna izbira");
                                            }
                                        }
                                       
                                    }


                                    else if (ekipe == "X" || ekipe == "x")
                                    {
                                        goto  konec;
                                    }
                                    else
                                    {
                                        Console.WriteLine(" Neveljavna Izbira");
                                    }
                                }
                            }
                            //dodajanje igralcev
                            else if(izbira == "2")
                            {
                                Console.Clear();
                                Igralec NovIgralec = new Igralec();
                                NovIgralec.Vnos();
                                // naredimo prostor v tabeli za še en avto:
                                Array.Resize(ref igralci, igralci.Length + 1);

                                // parkiramo nov avto na novo (zadnje) mesto
                                igralci[igralci.Length - 1] = NovIgralec;
                                Shrani(igralci);
                                break;
                            }
                            //izbris igralcev
                            else if(izbira == "3")
                            {
                            izbris:
                                Console.Clear();
                                Izpis(igralci);
                                Console.WriteLine("\nVnesite 1 za izbris igralca");
                                Console.WriteLine("Vnesite x za izhod");

                                while (true)
                                {
                                    string a = Console.ReadKey().KeyChar.ToString();
                                    if (a == "1")
                                    {
                                        Console.WriteLine("\nVnesite zaporedno številko igralca za izbris.");
                                        int indeksZaIzbris;
                                        while (true)
                                        {
                                            while (true)
                                            {
                                                try
                                                {
                                                    indeksZaIzbris = Convert.ToInt32(Console.ReadLine());
                                                    break;
                                                }
                                                catch
                                                {
                                                    Console.WriteLine("Napačen indeks.");
                                                    continue;
                                                }
                                            }

                                            if (indeksZaIzbris < 0 || indeksZaIzbris >= igralci.Length)
                                            {
                                                Console.WriteLine("Ta igralec ne obstaja.");
                                                continue;
                                            }
                                            else
                                            {
                                                break;
                                            }
                                        }
                                        Console.WriteLine("Izbrisali ste igralca " + igralci[indeksZaIzbris].ime + " " + igralci[indeksZaIzbris].priimek);
                                        for (int i = indeksZaIzbris + 1; i < igralci.Length; i++)
                                        {
                                            // premakniti element na indeksu i na indeks i - 1
                                            igralci[i - 1] = igralci[i];
                                        }
                                        // zmanjšamo array za 1
                                        Array.Resize(ref igralci, igralci.Length - 1);
                                        Console.WriteLine("Pritisnite katerokoli tipko za naprej");
                                        Console.ReadKey().KeyChar.ToString();
                                        Shrani(igralci);
                                        goto izbris;
                                    }
                                    else if (a == "X" || a == "x")
                                    {
                                        goto konec;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Neveljavna izbira");
                                    }
                                }
                                
                               
                               
                            }
                            //statistike
                            else if(izbira == "4")
                            {
                                Console.Clear();
                                Console.WriteLine("Statistike");
                                Console.WriteLine("-----------");
                                Console.WriteLine("Vnesite 1 za izračun povprečnih starosti igralcev");
                                Console.WriteLine("Vnesite 2 za izračun števila igralcev v posamezni kategoriji");
                                Console.WriteLine("Vnesite 3 za izpis števila igralcev glede na pozicijo");
                                Console.WriteLine("Vnesite 4 za izpis najbolših strelcev");
                                Console.WriteLine("Vnesite 5 za izpis najbolje plačanih igralcev");
                                Console.WriteLine("Vnesite 6 za izpis igralcev z največ odigranimi tekmami");
                                Console.WriteLine("Vnesite 7 za izpis igralcev z najbolšim razmerjem tekma/gol");
                                Console.WriteLine("Vnesite X za izhod");
                                while (true)
                                {
                                    string statistike = Console.ReadKey().KeyChar.ToString();
                                    if(statistike == "1")
                                    {
                                        PovprecnaStarost(igralci);
                                    }
                                    else if(statistike == "2")
                                    {
                                        PovprecjeKategorije(igralci);
                                    }
                                    else if(statistike == "3")
                                    {
                                        PovprecjePozicije(igralci);
                                    }
                                    else if (statistike == "4")
                                    {
                                        NajbolsiStrelci(igralci);
                                    }
                                    else if (statistike == "5")
                                    {
                                        NajboljsaPlaca(igralci);
                                    }
                                    else if(statistike == "6")
                                    {
                                        NajvecOdigranihTekem(igralci);
                                    }
                                    else if(statistike == "7")
                                    {
                                        razmerjeTekmaGol(igralci);
                                    }
                                    else if (statistike == "X" || statistike == "x")
                                    {
                                        goto konec;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Neveljavna izbira");
                                    }
                                }
                            }
                            //izhod
                            else if(izbira == "x" || izbira == "X")
                            {
                                Environment.Exit(0);
                            }
                            else
                            {
                                Console.WriteLine(" Neveljavna izbira");
                            }
                        }
                    konec:;
                    }
                }
            
                else if(vnos == "X" || vnos == "x")
                {
                break;  //izhod
                }

                else
                {
                    Console.WriteLine(" Neveljavna izbira");
                }
            }
           
        }
    }
}
