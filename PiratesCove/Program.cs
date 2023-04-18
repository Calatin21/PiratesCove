namespace PiratesCove {
    internal class Program {
        static void Main(string[] args) {
            Bus bus1 = new Bus(1, false);
            BusStation station1 = new BusStation("Great Yarmouth");
            BusStation station2 = new BusStation("Greenhithe");
            BusStation station3 = new BusStation("Shanklin");
            BusStation station4 = new BusStation("Wexford");
            List<BusStation> route = new List<BusStation>();
            route.Add(station1);
            route.Add(station2);
            route.Add(station3);
            route.Add(station4);

            for (int i = 0; i < 10; i++) {
                station1.AddGolfer(new Golfer($"{i}", "egal"));
            }
            for (int i = 10; i < 20; i++) {
                station1.AddGolfer(new Golfer($"{i}", "Greenhithe"));
            }
            for (int i = 20; i < 30; i++) {
                station1.AddGolfer(new Golfer($"{i}", "egal"));
            }
            for (int i = 30; i < 45; i++) {
                station2.AddGolfer(new Golfer($"{i}", "Shanklin"));
            }
            for (int i = 50; i < 65; i++) {
                station3.AddGolfer(new Golfer($"{i}", "Wexford"));
            }
            for (int i = 80; i < 75; i++) {
                station4.AddGolfer(new Golfer($"{i}", "Great Yarkmouth"));
            }

            bus1.Tour(route);
            //Console.WriteLine("Ausgabe Bus leer:");
            //bus1.PrintGolfer();
            //Console.WriteLine("");

            //station1.Einfahren(bus1);
            //bus1.Austeigen(station1);
            //bus1.Einsteigen(station1);
            //Console.WriteLine("Ausgabe nach Station 1:");
            //bus1.PrintGolfer();
            //Console.WriteLine("");
            //station1.Ausfahren();

            //station2.Einfahren(bus1);
            //bus1.Austeigen(station2);
            //bus1.Einsteigen(station2);
            //Console.WriteLine("Ausgabe nach Station 2:");
            //bus1.PrintGolfer();
            //Console.WriteLine("");

            //station3.Einfahren(bus1);
            //bus1.Austeigen(station3);
            //bus1.Einsteigen(station3);
            //Console.WriteLine("Ausgabe nach Station 3:");
            //bus1.PrintGolfer();
            //Console.WriteLine("");

            //station4.Einfahren(bus1);
            //bus1.Austeigen(station4);
            //bus1.Einsteigen(station4);
            //Console.WriteLine("Ausgabe nach Station 4:");
            //bus1.PrintGolfer();
            //Console.WriteLine("");

        }
    }
}