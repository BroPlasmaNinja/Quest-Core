using System;
using System.CodeDom;

namespace QuestCore
{
    static class Сhronicler
    {
        public static string PreparingForSave<T>(T obj)
        {
            string output = "";
            switch (typeof(T).Name)
            {
                case "Player":
                    output =
                        ((char)0).ToString() +
                        (obj as Player).realName +
                        ((char)0).ToString() +
                        (obj as Player).name +
                        ((char)0).ToString() +
                        (obj as Player).characteristics._str +
                        ((char)0).ToString() +
                        (obj as Player).characteristics._dex +
                        ((char)0).ToString() +
                        (obj as Player).characteristics._con +
                        ((char)0).ToString() +
                        (obj as Player).characteristics._int +
                        ((char)0).ToString() +
                        (obj as Player).characteristics._cha +
                        ((char)0).ToString() +
                        (obj as Player).characteristics._wis +
                        ((char)0).ToString() +
                        (obj as Player).GetBodyHP().head +
                        ((char)0).ToString() +
                        (obj as Player).GetBodyHP().body +
                        ((char)0).ToString() +
                        (obj as Player).GetBodyHP().rhand +
                        ((char)0).ToString() +
                        (obj as Player).GetBodyHP().lhand +
                        ((char)0).ToString() +
                        (obj as Player).GetBodyHP().rleg +
                        ((char)0).ToString() +
                        (obj as Player).GetBodyHP().lleg +
                        ((char)0).ToString() +
                        (obj as Player).age +
                        ((char)0).ToString() +
                        (obj as Player).height +
                        ((char)0).ToString() +
                        (obj as Player).weight +
                        ((char)0).ToString() +
                        (obj as Player).hunger +
                        ((char)0).ToString() +
                        (obj as Player).thrist +
                        ((char)0).ToString() +
                        (obj as Player).insanity +
                        ((char)0).ToString() +
                        (obj as Player).discription;
                    break;
                default:
                    throw new Exception("Some errors in Chronicler");
            }
            return output;
        }
        public static Player PlayerConvert(string @string) 
        {
            string[] input = @string.Split((char)0);
            return new Player(input[0], input[1], new Characteristics(int.Parse(input[2]), int.Parse(input[3]), int.Parse(input[4]), int.Parse(input[5]), int.Parse(input[6]), int.Parse(input[7])),new Player.BodyHP(int.Parse(input[8]), int.Parse(input[9]), int.Parse(input[10]), int.Parse(input[11]), int.Parse(input[12]), int.Parse(input[13])), int.Parse(input[14]), int.Parse(input[15]), int.Parse(input[16]), int.Parse(input[17]), int.Parse(input[18]), int.Parse(input[19]), input[20]);
            throw new Exception("Some wrong");
        }
    }
}
