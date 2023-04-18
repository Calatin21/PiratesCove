namespace PiratesCove {
    internal class Golfer {
        String name;
        String ziel;
        public Golfer(String name, string ziel) {
            this.name = name;
            this.ziel = ziel;
         }
        public void SetName(String name) {
            this.name = name;
        }
        public String GetName() {
            return name;
        }
        public void SetZiel(String ziel) {
            this.ziel = ziel;
        }
        public String GetZiel() {
            return ziel;
        }
    }
}
