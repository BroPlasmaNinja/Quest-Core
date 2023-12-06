using System;

namespace QuestCore
{
    public class Player : Creature
    {
        public struct BodyHP
        {
            public int head;
            public int body;
            public int rhand;
            public int lhand;
            public int rleg;
            public int lleg;
            public BodyHP(int head, int body, int rhand, int lhand, int rleg, int lleg)
            {
                this.head = head;
                this.body = body;
                this.rhand = rhand; 
                this.lhand = lhand;
                this.rleg = rleg;
                this.lleg = lleg;
            }
        }
        BodyHP hp = new BodyHP(13,13,13,13,13,13);

        public string realName;

        public int age;
        public int height;
        public int weight;

        public int hunger;//2 для голодного состояния(1 за существование + 1 за работу + 2 за очень тяжёлую работу) 1/2/4/6/8/10 лёгкий голод/голод/реально голоден/очень голоден/Лёгкое истощение/Истощение
        public int thrist;// расценки как и у голода 1/2/3/5/7/9 лёгкая жажда/жажда/сильная жажда/необходимость в воде/лёгкое истощение/истощение
        public int insanity;// Безумие стакается от увиденного и способствует приобритению новых бзиков(в зависимости от тяжести)
        public Player(string realName, string name, Characteristics characteristics, BodyHP hp, int age, int height, int weight, int hunger, int thrist, int insanity, string discription)
        {
            this.realName = realName;
            this.name = name;
            this.characteristics = characteristics;
            this.hp = hp;
            this.age = age;
            this.height = height;
            this.weight = weight;
            this.hunger = hunger;
            this.thrist = thrist;
            this.insanity = insanity;
            this.discription = discription;
        }
        public Player(string realName, string name, int age, Characteristics characteristics)
        {
            this.realName = realName;
            this.name = name;
            this.age = age;
            this.characteristics = characteristics;
            hunger = 0;
            thrist = 0;
            insanity = 0;
        }
        public Player(Creature creature) : base(creature) { }
        public Player() 
        {
            realName = "idk";
            name = realName;
            age = 0;
            characteristics = new Characteristics();
            hunger = 0;
            thrist = 0;
            insanity = 0;
        }
        public void TakeDMG(int DMG, int part)
        {
            switch (part) 
            {
                case 1:
                    hp.lleg -= DMG; break;
                case 2:
                    hp.rleg -= DMG; break;
                case 3:
                    hp.lhand -= DMG; break;
                case 4:
                    hp.rhand -= DMG; break;
                case 5:
                    hp.body -= DMG; break;
                case 6:
                    hp.head -= DMG; break;
                default:
                    throw new Exception("PLayer don't have this part");
            }
        }
        public BodyHP GetBodyHP() { return hp; }
    }
}
