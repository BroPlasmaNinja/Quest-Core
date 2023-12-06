namespace QuestCore
{
    public class Creature
    {//33 очка
        public Characteristics characteristics;
        public string name;
        public string discription;
        public Creature()
        {
            name = "unnamed";
            discription = "*crickets crackling*";
            characteristics = new Characteristics();
        }
        public Creature(Creature creature)
        {
            characteristics = creature.characteristics;
            name = creature.name;
            discription = creature.discription;
        }
        public Creature(string name)
        {
            this.name = name;
        }
        public Creature(string name, Characteristics characteristics)
        {
            this.name= name;
            this.characteristics = characteristics;
        }
        public Creature(string name, Characteristics characteristics, string discription)
        {
            this.characteristics = characteristics;
            this.name = name;
            this.discription = discription;
        }
    }
}
