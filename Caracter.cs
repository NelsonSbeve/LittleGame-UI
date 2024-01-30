



public class Caracter{

        public string name{get; set;}
        public int health{get; set;}
        public Caracter(string name, int health = 100){
            this.name = name;
            this.health = health;
        }
        public bool IsAlive()
            {
                return health > 0;
            }
}
