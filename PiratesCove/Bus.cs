namespace PiratesCove {
    internal class Bus {
        int nummer;
        bool tuerkaputt;
        Queue<Golfer> schlange = new Queue<Golfer>();
        Random random = new Random();
        public Bus(int nummer, bool tuer) {
            this.nummer = nummer;
            this.tuerkaputt = tuer;
        }
        public void Einsteigen(BusStation station) {
            foreach (Golfer item in station.GetGolfers()) {
                if (schlange.Count() >= 30) {
                    Console.WriteLine("Sorry, der bus ist voll.");
                }
                else {
                    schlange.Enqueue(item);
                }
            }
        }
        public List<Golfer> GetGolfers() {
            return schlange.ToList();
        }
        public void Austeigen(BusStation station) {
            tuerkaputt = Convert.ToBoolean(random.Next(0, 2));
            if (tuerkaputt) {
                Console.WriteLine("Die Tür ist mal wieder kaputt.");
                schlange.Reverse();
            }
            while (schlange.Count > 0) {
                Golfer golfer = schlange.Dequeue();
                if (golfer.GetZiel() != station.GetName()) {
                    station.InsertGolfer(golfer);
                } else {
                    Console.WriteLine($"Der Passagier {golfer.GetName()} mit dem Ziel {golfer.GetZiel()} ist an Station {station.GetName()} ausgestiegen");
                }
            }
        }
        public void PrintGolfer() {
            List<Golfer> golfer = schlange.ToList();
            foreach (Golfer item in golfer) {
                Console.WriteLine($"Passagier: {item.GetName()} Ziel: {item.GetZiel()}");
            }
        }
        public void Tour (List<BusStation> route) {
            foreach (BusStation item in route) {
                this.Austeigen(item);
                this.Einsteigen(item);
                Console.WriteLine($"Nach der Station {item.GetName()} sind folgende {schlange.Count()} Passagiere im Bus.");
                this.PrintGolfer();
            }
        }
    }
}
