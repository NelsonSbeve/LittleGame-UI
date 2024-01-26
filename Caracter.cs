



public class Caracter{

        public string name{get; set;}
        public string gender{get; set;}
        public int health{get; set;}
        public Caracter(string name, string gender, int health = 100){

            this.name = name;
            this.gender = gender;
            this.health = health;
        }
        public bool IsAlive()
            {
                return health > 0;
            }
}
