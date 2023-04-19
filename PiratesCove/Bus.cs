namespace PiratesCove {
    internal class Bus {
        int nummer;
        bool tuerkaputt;
        Queue<Golfer> passagiere = new Queue<Golfer>();
        Random random = new Random();
        public Bus(int nummer) {
            this.nummer = nummer;
        }
        public void Einsteigen(BusStation station) {
            foreach (Golfer item in station.GetGolfers()) {
                if (passagiere.Count() >= 30) {
                    Console.WriteLine("Sorry, der bus ist voll.");
                }
                else {
                    Console.WriteLine($"Passagier: {item.GetName()} mit Ziel: {item.GetZiel()} ist zugestiegen.");
                    item.SetAufenthaltsort("Bus");
                    passagiere.Enqueue(item);

                }
            }
        }
        public List<Golfer> GetGolfers() {
            return passagiere.ToList();
        }
        public void Austeigen(BusStation station, FBI fbi, BusStation rueck) {
            tuerkaputt = Convert.ToBoolean(random.Next(0, 2));
            Queue<Golfer> schlange = new Queue<Golfer>();
            if (tuerkaputt) {
                Console.WriteLine("Die Tür ist mal wieder kaputt.");
                passagiere = new Queue<Golfer>(passagiere.Reverse());
            }
            while (passagiere.Count > 0) {
                Golfer golfer = passagiere.Dequeue();
                if (golfer.GetZiel() != station.GetName()) {
                    schlange.Enqueue(golfer);
                }
                else {
                    fbi.GetGolfer(golfer.GetName()).SetAufenthaltsort(station.GetName());
                    Console.WriteLine($"Der Passagier {golfer.GetName()} mit dem Ziel {golfer.GetZiel()} ist an Station {station.GetName()} ausgestiegen");
                    golfer.SetZiel(golfer.GetStart());
                    rueck.AddGolfer(golfer, fbi);
                }
            }
            passagiere = schlange;
        }
        public void PrintGolfer() {
            foreach (Golfer item in passagiere.Reverse()) {
                Console.WriteLine($"Passagier: {item.GetName()} Ziel: {item.GetZiel()}");
            }
            Console.WriteLine("");
        }
        public void Tour(List<BusStation> route, FBI fbi, List<BusStation> rueck) {
            foreach (BusStation item in route) {
                BusStation gegen = null;
                foreach (BusStation station in rueck) {
                    if (station.GetName() == item.GetName()) {
                        gegen = station;
                    }
                }
                this.Austeigen(item, fbi, gegen);
                this.Einsteigen(item);
                Console.WriteLine($"Nach der Station {item.GetName()} sind folgende {passagiere.Count()} Passagiere im Bus.");
                this.PrintGolfer();

            }
        }
    }
}
