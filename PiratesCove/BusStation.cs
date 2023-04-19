namespace PiratesCove {
    internal class BusStation {
        String name;
        Bus bus;
        List<Golfer> golfers = new List<Golfer>();
        public BusStation(String name) {
            this.name = name;
        }
        public void SetName(String name) {
            this.name = name;
        }
        public String GetName() {
            return this.name;
        }
        public void Einfahren(Bus bus) {
            this.bus = bus;
        }
        public void Ausfahren() {
            this.bus = null;
        }
        public void AddGolfer(Golfer golfer, FBI fbi) {
            golfer.SetStart(this.name);
            golfer.SetAufenthaltsort(this.name);
            fbi.AddSuspect(golfer);
            golfers.Add(golfer);
        }
        public void InsertGolfer(List<Golfer> golfer) {
            List<Golfer> liste = new List<Golfer>();
            foreach (Golfer item in golfers) {
                Console.WriteLine($"Passagier: {item.GetName()} mit Ziel: {item.GetZiel()} ist zugestiegen."); }
            liste.AddRange(golfer);
            liste.AddRange(golfers);
            golfers = liste;
        }
        public void RemoveGolfer(Golfer golfer) {
            golfers.Remove(golfer);
        }
        public List<Golfer> GetGolfers() {
            return golfers;
        }
    }
}
