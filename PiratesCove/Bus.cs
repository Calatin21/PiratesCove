namespace PiratesCove {
    internal class Bus {
        bool tuerkaputt;
        Queue<Golfer> passagiere = new Queue<Golfer>();
        Random random = new Random();
        public void Einsteigen(BusStation station) {
            List<Golfer> liste = new List<Golfer>();
            foreach (Golfer item in station.GetGolfers()) {
                if (passagiere.Count() >= 30) {
                    Console.WriteLine($"Sorry Passagier {item.GetName()}, der bus ist voll.");
                }
                else {
                    Console.WriteLine($"Passagier: {item.GetName()} mit Ziel: {item.GetZiel()} ist zugestiegen.");
                    item.SetAufenthaltsort("Bus");
                    passagiere.Enqueue(item);
                    liste.Add(item);
                }
            }
            station.AddGolfers(station.GetGolfers().Except(liste).ToList());
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
                Console.WriteLine($"Bevor der Bus kommt warten diese Passagiere an Busstation: {item.GetName()}");
                item.PrintGolfer();
                this.Austeigen(item, fbi, gegen);
                this.Einsteigen(item);
                Console.WriteLine($"Nachdem der Bus abgefahren ist, warten diese Passagiere an Busstation: {item.GetName()}");
                item.PrintGolfer();
                Console.WriteLine($"Nach der Station {item.GetName()} sind folgende {passagiere.Count()} Passagiere im Bus.");
                this.PrintGolfer();

            }
        }
    }
}
