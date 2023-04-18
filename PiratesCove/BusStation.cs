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
        public void AddGolfer(Golfer golfer) {
            golfers.Add(golfer);
        }
        public void InsertGolfer (Golfer golfer) {
            golfers.Insert(0, golfer);
        }
        public void RemoveGolfer(Golfer golfer) {
            golfers.Remove(golfer);
        }
        public List<Golfer> GetGolfers() {
            return golfers;
        }
        public Golfer GetGolfer() {
            return golfers.First();
        }
    }
}
