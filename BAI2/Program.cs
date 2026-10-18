using System;
using System.Collections.Generic;


namespace BAI
{
    public partial class BAI_Afteken2
    {
        public static bool Vooruit(uint b)
        {
            // *** IMPLEMENTATION HERE *** //
            return false;
        }
        public static uint Vermogen(uint b)
        {
            // *** IMPLEMENTATION HERE *** //
            return 0;
        }
        public static bool Wagon(uint b)
        {
            // *** IMPLEMENTATION HERE *** //
            return false;
        }
        public static bool Licht(uint b)
        {
            // *** IMPLEMENTATION HERE *** //
            return false;
        }
        public static uint ID(uint b)
        {
            // *** IMPLEMENTATION HERE *** //
            return 0;
        }

        public static HashSet<uint> Alle(List<uint> inputStroom)
        {
            HashSet<uint> set = new HashSet<uint>();
            // Door alle elementen van de inputlijst lopen
            foreach (uint b in inputStroom)
            {
                // Elk element toevoegen aan de HashSet
                set.Add(b);
            } 
            return set;
        }
        public static HashSet<uint> ZonderLicht(List<uint> inputStroom)
        {
            HashSet<uint> set = new HashSet<uint>();
            // Door alle elementen van de inputlijst lopen
            foreach (uint b in inputStroom)
            {
                // Controleren of het licht uit staat
                if (!Licht(b))
                {
                    // Alleen treinen zonder licht toevoegen
                    set.Add(b);
                }
            }
            return set;
        }
        public static HashSet<uint> MetWagon(List<uint> inputStroom)
        {
            HashSet<uint> set = new HashSet<uint>();
            // Door alle elementen van de inputlijst lopen
            foreach (uint b in inputStroom)
            {
                // Controleren of er een wagon gekoppeld is
                if (Wagon(b))
                {
                    // Alleen treinen met wagon toevoegen
                    set.Add(b);
                }
            }
            return set;
        }
        public static HashSet<uint> SelecteerID(List<uint> inputStroom, uint lower, uint upper)
        {
            HashSet<uint> set = new HashSet<uint>();
            // Door alle elementen van de inputlijst lopen
            foreach (uint b in inputStroom)
            {
                // Het trein-ID uit het element halen
                uint id = ID(b);
                // Controleren of het ID binnen de grenzen valt
                if (id >= lower && id <= upper)
                {
                    set.Add(b);
                }
            }
            return set;
        }

        public static HashSet<uint> Opdr3a(List<uint> inputStroom)
        {
            HashSet<uint> set = new HashSet<uint>();
            // *** IMPLEMENTATION HERE *** //
            return set;
        }

        public static HashSet<uint> Opdr3b(List<uint> inputStroom)
        // bruce
        {
            HashSet<uint> set = Alle(inputStroom);
            // Verwijder alle treinen die in opdracht 3a zitten
            // 3a bevat: ID lager dan 3 EN zonder licht
            // Wat overblijft is dus: ID hoger dan 2 OF met licht
            set.ExceptWith(Opdr3a(inputStroom));
            return set;
        }

        public static void ToonInfo(uint b)
        {
            Console.WriteLine($"ID {ID(b)}, Licht {Licht(b)}, Wagon {Wagon(b)}, Vermogen {Vermogen(b)}, Vooruit {Vooruit(b)}");
        }

        public static List<uint> GetInputStroom()
        {
            List<uint> inputStream = new List<uint>();
            for (uint i = 0; i < 256; i++)
            {
                inputStream.Add(i);
            }
            return inputStream;
        }

        public static void PrintSet(HashSet<uint> x)
        {
            Console.Write("{");
            foreach (uint i in x)
                Console.Write($" {i}");
            Console.WriteLine($" }} ({x.Count} elementen)");
        }


        static void Main(string[] args)
        {
            Console.WriteLine("=== Opgave 1 ===");
            ToonInfo(210);
            Console.WriteLine();

            List<uint> inputStroom = GetInputStroom();

            Console.WriteLine("=== Opgave 2 ===");
            HashSet<uint> alle = Alle(inputStroom);
            PrintSet(alle);
            HashSet<uint> zonderLicht = ZonderLicht(inputStroom);
            PrintSet(zonderLicht);
            HashSet<uint> metWagon = MetWagon(inputStroom);
            PrintSet(metWagon);
            HashSet<uint> groter6 = SelecteerID(inputStroom, 6, 7);
            PrintSet(groter6);
            Console.WriteLine();

            Console.WriteLine("=== Opgave 3a ===");
            HashSet<uint> opg3a = Opdr3a(inputStroom);
            PrintSet(opg3a);
            foreach (uint b in opg3a)
            {
                ToonInfo(b);
            }
            Console.WriteLine();

            Console.WriteLine("=== Opgave 3b ===");
            HashSet<uint> opg3b = Opdr3b(inputStroom);
            PrintSet(opg3b);
            foreach (uint b in opg3b)
            {
                ToonInfo(b);
            }
            Console.WriteLine();
        }
    }
}
