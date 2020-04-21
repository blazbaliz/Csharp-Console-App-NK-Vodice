using System;
using System.Collections.Generic;
using System.Text;

namespace Seminarska
{
    class Igralec
    {
        public string ime;
        public string priimek;
        public string datumRojstva;
        public string pozicija;
        public string kategorija;
        public double placa;
        public int stOdigranihTekem;
        public int stDosezenihGolov;
        public double razmerjeTekmaGol;

        //Konstruktors
        public Igralec()
        {

        }


        public Igralec(string vrstica) //ko vnesemo vrstico podatkov iz datoteke
        {
            string[] podatki = vrstica.Split(":");
            this.ime = podatki[0];
            this.priimek = podatki[1];
            this.datumRojstva = podatki[2];
            this.pozicija = podatki[3];
            this.kategorija = podatki[4];
            this.placa = Convert.ToDouble(podatki[5]);
            this.stOdigranihTekem = Convert.ToInt32(podatki[6]);
            this.stDosezenihGolov = Convert.ToInt32(podatki[7]);
            this.razmerjeTekmaGol = Convert.ToDouble(this.stDosezenihGolov) / this.stOdigranihTekem;
        }

        public override string ToString()
        {
            return this.ime + ":" + this.priimek + ":" + this.datumRojstva + ":" + this.pozicija + ":" + this.kategorija + ":" + this.placa + ":" + this.stOdigranihTekem + ":" + this.stOdigranihTekem; ;
        }

        public void Izpis()
        {
            Console.WriteLine("Ime in priimek: " + this.ime + " " + this.priimek + "\nDatum rojstva: " + this.datumRojstva + "\nPozicija: " + this.pozicija + "\nKategorija: " + this.kategorija + "\nPlača: " + string.Format("{0:n0}", this.placa) + " €" + "\nŠtevilo odigranih tekem: " + this.stOdigranihTekem + "\nŠtevilo doseženih golov: " + stDosezenihGolov);
        }

        public void IzpisIme()
        {
            Console.Write(this.ime + " " + this.priimek);
        }

        public void VnosKategorija()
        {
            Console.WriteLine("Vnesi kategorijo");
            Console.WriteLine("1. Člani");
            Console.WriteLine("2. Kadeti");
            Console.WriteLine("3. Mladinci");
            Console.WriteLine();
            while (true)
            {
                string a = Console.ReadKey().KeyChar.ToString();
                if (a == "1")
                {
                    this.kategorija = "Člani";
                    break;
                }
                else if (a == "2")
                {
                    this.kategorija = "Kadeti";
                    break;
                }
                else if (a == "3")
                {
                    this.kategorija = "Mladinci";
                    break;
                }
                else
                {
                    Console.WriteLine("Neveljavna izbira");
                }
            }

            Console.WriteLine(". " + this.kategorija);
        }

        public void VnosIme()
        {
            Console.WriteLine("Vnesi Ime");

            while (true)
            {
                string a = Console.ReadLine();
                if (a.Length > 0)
                {
                    if (Crke(a) == true)
                    {
                        this.ime = a;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Neveljaven format");
                    }
                }
                else
                {
                    Console.WriteLine("Neveljavna izbira");
                }
            }
        }

        public void VnosPriimek()
        {
            Console.WriteLine("Vnesi priimek");

            while (true)
            {
                string a = Console.ReadLine();
                if (a.Length > 0)
                {
                    if(Crke(a) == true)
                    {
                        this.priimek = a;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Neveljaven format");
                    }
                }
                else
                {
                    Console.WriteLine("Neveljavna izbira");
                }
            }

          
        }
        
        public void VnosDatumRojstva()
        {
            Console.WriteLine("Datum rojstva");
            Console.WriteLine();
        abc:
            Console.WriteLine("Vnesi dan z števko");
            int dan;
            int mesec;
            int leto;
            while (true)
            {
                try
                {
                    dan = Convert.ToInt32(Console.ReadLine());
                    break;
                }
                catch
                {
                    Console.WriteLine("Napačen format, ponovi");
                    
                }
            }
            
            Console.WriteLine("Vnesic mesec s števko");
            while (true)
            {
                try
                {
                    mesec = Convert.ToInt32(Console.ReadLine());
                    break;
                }
                catch
                {
                    Console.WriteLine("Napačen format, ponovi");
                }
            }
            leto:    
            Console.WriteLine("Vnesi leto s števko");
            while (true)
            {
                try
                {
                    leto = Convert.ToInt32(Console.ReadLine());
                    break;
                }
                catch
                {
                    Console.WriteLine("Napačen format");
                }
            }
            while (true)
            {
                if (0 < dan && dan < 32 && mesec > 0 && mesec < 13)
                {
                    if (leto <= DateTime.Now.Year)
                    {
                        if (leto >= 1970) 
                        { 
                        this.datumRojstva = "" + dan + "." + mesec + "." + leto;
                        Console.WriteLine();
                        Console.WriteLine(this.datumRojstva);
                        break;
                        }
                        else
                        {
                            Console.WriteLine("Ta igralec je prestar za v naš klub");
                            goto leto;
                        }
                    }
                    else
                    {
                        Console.WriteLine("To leto ne obstaja");
                        goto leto;
                    }
                }
                else
                {
                    Console.WriteLine("Neveljaven datum");
                    goto abc;
                }
            }
            
        }

        public void VnosPozicija()
        {
            Console.WriteLine("Vnesi pozicijo");
            Console.WriteLine("1. Napad ");
            Console.WriteLine("2. Sredina ");
            Console.WriteLine("3. Obramba ");
            Console.WriteLine("4. Golman");
            Console.WriteLine();
            while (true)
            {
                string a = Console.ReadKey().KeyChar.ToString();
                if (a == "1")
                {
                    this.pozicija = "Napad";
                    break;
                }
                else if (a == "2")
                {
                    this.pozicija = "Sredina";
                    break;
                }
                else if (a == "3")
                {
                    this.pozicija = "Obramba";
                    break;
                }
                else if (a == "4")
                {
                    this.pozicija = "Golman";
                    break;
                }
                else
                {
                    Console.WriteLine(" Neveljavna izbira");
                }
            }     
            Console.WriteLine(". " + this.pozicija);
        }

        public void VnosPlaca()
        {
            
            while (true)
            {
                Console.WriteLine("Vnesi plačo");
                Console.WriteLine();

                try
                {
                    Console.Write(" € ");
                    this.placa = Convert.ToInt32(Console.ReadLine());
                    break;
                }
                catch
                {
                    Console.WriteLine("Neveljavna izbira");
                }

            }
        }

        public void VnosStOdigranihTekem()
        {
            while (true)
            {
                Console.WriteLine("Vnesi število odigranih tekem");
                Console.WriteLine();
                try
                {
                    this.stOdigranihTekem = Convert.ToInt32(Console.ReadLine());
                    break;
                }
                catch
                {
                    Console.WriteLine("Neveljavna izbira");
                }
            }
        }

        public void VnosStDosezenihGolov()
        {
            while (true)
            {
                Console.WriteLine("Vnesi število doseženih golov");
                Console.WriteLine();
                try
                {
                    this.stDosezenihGolov = Convert.ToInt32(Console.ReadLine());
                    break;
                }
                catch
                {
                    Console.WriteLine("Neveljavna izbira");
                }
            }
        }

        public void Vnos()
        {
            Console.WriteLine("Dodajanje igralca");
            
                VnosKategorija();
                Console.WriteLine();
                VnosIme();
                Console.WriteLine();
                VnosPriimek();
                Console.WriteLine();
                VnosDatumRojstva();
                Console.WriteLine();
                VnosPozicija();
                Console.WriteLine();
                VnosPlaca();
                Console.WriteLine();
                VnosStOdigranihTekem();
                Console.WriteLine();
                VnosStDosezenihGolov();
                Console.WriteLine();
        }

        public void Uredi()
        {
            while (true)
            {

           
                Console.Clear();
                Console.WriteLine("Urejanje igralca: ");
                Console.WriteLine("---------------------------------");
                Izpis();
                Console.WriteLine("---------------------------------");
                Console.WriteLine("Za urejanje imena pritisnite 1");
                Console.WriteLine("Za urejanje priimka pritisnite 2");
                Console.WriteLine("Za urejanje kategorije pritisnite pritisnite 3");
                Console.WriteLine("Za urejanje datuma rojstva pritisnite 4");
                Console.WriteLine("Za urejanje pozicije pritisnite 5");
                Console.WriteLine("Za urejanje plače pritisnite 6");
                Console.WriteLine("Za urejanje števila odigranih tekem pritisnite 7");
                Console.WriteLine("Za urejanje števila doseženih golov pritisnite 8");
                Console.WriteLine("Za nazaj pritisnite X");

            
           
                string izbira = Console.ReadKey().KeyChar.ToString();
                switch (izbira)
                {
                    case "1":
                        VnosIme();
                        break;
                    case "2":
                        VnosPriimek();
                        break;
                    case "3":
                        VnosKategorija();
                        break;
                    case "4":
                        VnosDatumRojstva();
                        break;
                    case "5":
                        VnosPozicija();
                        break;
                    case "6":
                        VnosPlaca();
                        break;
                    case "7":
                        VnosStOdigranihTekem();
                        break;
                    case "8":
                        VnosStDosezenihGolov();
                        break;
                    case "x":
                        goto end;
                    case "X":
                        goto end;
                    default:
                        Console.WriteLine("Neveljavna izbira1");
                        break;
                }
            }
        end:;
        }

        public int Starost()
        {
            int starost;
            string[] leto = this.datumRojstva.Split(".");
            return starost = DateTime.Now.Year - Convert.ToInt32(leto[2]);
        }

        public bool Crke(string a)
        {
            for(int i = 0; i < a.Length; i++)
            {
                if (Char.IsLetter(a[i]))
                {
                    continue;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
    }
}
