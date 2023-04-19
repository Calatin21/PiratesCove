namespace PiratesCove {
    internal class FBI {
        List<Golfer> daten = new List<Golfer>();
        public void AddSuspect(Golfer golfer) {
            daten.Add(golfer);
        }
        public void PrintWanted(String name) {
            foreach (Golfer item in daten) {
                if (item.GetName() == name) {
                    Console.WriteLine($"Name: {item.GetName()} Aufenthaltsort: {item.GetAufenthaltsort()}");
                }
            }
        }
        public void PrintAll() {
            foreach (Golfer item in daten) {
                Console.WriteLine($"Name: {item.GetName()} Aufenthaltsort: {item.GetAufenthaltsort()}");
            }
        }
        public Golfer GetGolfer(String name) {
            Golfer ergebnis = null;
            foreach (Golfer item in daten) {
                if (item.GetName() == name) {
                    ergebnis = item;
                }
            }
            return ergebnis;
        }
    }
}
