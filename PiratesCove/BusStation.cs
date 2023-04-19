namespace PiratesCove {
    internal class BusStation {
        String name;
        List<Golfer> warteSchlange = new List<Golfer>();
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
            warteSchlange.Add(golfer);
        }
        public List<Golfer> GetGolfers() {
            return warteSchlange;
        }
        public void RemoveGolfer(Golfer golfer) {
            warteSchlange.Remove(golfer);
        }
        public void PrintGolfer() {
            foreach (Golfer item in warteSchlange) {
                Console.WriteLine(item.GetName());
            }
        }
    }
}
