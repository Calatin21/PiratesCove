namespace PiratesCove {
    internal class Bus {
        int nummer;
        bool tuerkaputt;
        Queue<Golfer> schlange = new Queue<Golfer>();
        Random random = new Random();
        public Bus(int nummer) {
            this.nummer = nummer;
        }
        public void Einsteigen(BusStation station) {
            foreach (Golfer item in station.GetGolfers()) {
                if (schlange.Count() >= 30) {
                    Console.WriteLine("Sorry, der bus ist voll.");
                }
                else {
                    item.SetAufenthaltsort("Bus");
                    schlange.Enqueue(item);

                }
            }
        }
        public List<Golfer> GetGolfers() {
            return schlange.ToList();
        }
        public void Austeigen(BusStation station, FBI fbi, BusStation rueck) {
            tuerkaputt = Convert.ToBoolean(random.Next(0, 2));
            List<Golfer> liste = new List<Golfer>();
            if (tuerkaputt) {
                Console.WriteLine("Die Tür ist mal wieder kaputt.");
                schlange = new Queue<Golfer>(schlange.Reverse());
            }
            while (schlange.Count > 0) {
                Golfer golfer = schlange.Dequeue();
                if (golfer.GetZiel() != station.GetName()) {
                    liste.Add(golfer);
                }
                else {
                    fbi.GetGolfer(golfer.GetName()).SetAufenthaltsort(station.GetName());
                    Console.WriteLine($"Der Passagier {golfer.GetName()} mit dem Ziel {golfer.GetZiel()} ist an Station {station.GetName()} ausgestiegen");
                    golfer.SetZiel(golfer.GetStart());
                    rueck.AddGolfer(golfer, fbi);
                }
            }
            station.InsertGolfer(liste);
        }
        public void PrintGolfer() {
            foreach (Golfer item in schlange.Reverse()) {
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
                    Console.WriteLine($"Nach der Station {item.GetName()} sind folgende {schlange.Count()} Passagiere im Bus.");
                    this.PrintGolfer();
                
            }
        }
    }
}
