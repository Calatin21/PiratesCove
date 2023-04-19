namespace PiratesCove {
    internal class Golfer {
        String name;
        String ziel;
        String start;
        String aufenthaltsort;
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
        public void SetStart(String start) {
            this.start = start;
        }
        public String GetStart() {
            return start;
        }
        public void SetAufenthaltsort(String ort) {
            aufenthaltsort = ort;
        }
        public String GetAufenthaltsort() {
            return aufenthaltsort;
        }
    }
}
