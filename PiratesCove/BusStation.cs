namespace PiratesCove {
    internal class BusStation {
        String name;
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
        public void AddGolfer(Golfer golfer, FBI fbi) {
            golfer.SetStart(this.name);
            golfer.SetAufenthaltsort(this.name);
            fbi.AddSuspect(golfer);
            golfers.Add(golfer);
        }
        public List<Golfer> GetGolfers() {
            return golfers;
        }
    }
}
