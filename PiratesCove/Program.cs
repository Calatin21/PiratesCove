﻿namespace PiratesCove {
    internal class Program {
        static String Zielsuche(int zahl) {
            String ziel = "kein Ziel";
            Random random = new Random();
            int x = random.Next(zahl, 5);
            switch (x) {
                case 1:
                ziel = "Great Yarmouth";
                break;
                case 2:
                ziel = "Greenhithe";
                break;
                case 3:
                ziel = "Shanklin";
                break;
                case 4:
                ziel = "Wexford";
                break;
                default:
                ziel = "kein Ziel";
                break;
            }
            return ziel;
        }
        static void Main(string[] args) {
            FBI fBI = new FBI();
            Bus bus1 = new Bus();
            BusStation station1 = new BusStation("Great Yarmouth");
            BusStation station1r = new BusStation("Great Yarmouth");
            BusStation station2 = new BusStation("Greenhithe");
            BusStation station2r = new BusStation("Greenhithe");
            BusStation station3 = new BusStation("Shanklin");
            BusStation station3r = new BusStation("Shanklin");
            BusStation station4 = new BusStation("Wexford");
            BusStation station4r = new BusStation("Wexford");
            List<BusStation> route = new List<BusStation>();
            List<BusStation> routeR = new List<BusStation>();
            route.Add(station1);
            route.Add(station2);
            route.Add(station3);
            route.Add(station4);
            routeR.Add(station4r);
            routeR.Add(station3r);
            routeR.Add(station2r);
            routeR.Add(station1r);
            Random random = new Random();
            int x = 1;
            String ziel;
            for (int i = 0; i <= random.Next(10, 50); i++) {
                ziel = Zielsuche(2);
                station1.AddGolfer(new Golfer($"{x}", $"{ziel}"), fBI);
                x++;
            }
            for (int i = 0; i <= random.Next(10, 50); i++) {
                ziel = Zielsuche(3);
                station2.AddGolfer(new Golfer($"{x}", $"{ziel}"), fBI);
                x++;
            }
            for (int i = 0; i <= random.Next(10, 50); i++) {
                ziel = Zielsuche(4);
                station3.AddGolfer(new Golfer($"{x}", $"{ziel}"), fBI);
                x++;
            }
            for (int i = 0; i < 5; i++) {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Hinfahrt:");
                bus1.Tour(route, fBI, routeR);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Aufenthaltsort der Verdächtigen:");
                fBI.PrintAll();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Rückfahrt:");
                bus1.Tour(routeR, fBI, route);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Aufenthaltsort der Verdächtigen:");
                fBI.PrintAll(); }
        }
    }
}