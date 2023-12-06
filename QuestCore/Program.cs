using System;
using System.Collections.Generic;
using System.Linq;

namespace QuestCore
{
    internal class Program
    {
        static Dictionary<string, Player> allPlayers = new Dictionary<string, Player>();
        static string crutch = "";
        public static Player currentPlayer = new Player();
        static void Main(string[] args)
        {
            string input;
            while (true) 
            {
                Console.Write(">>");
                input = Console.ReadLine().Trim().ToLower();
                if (input.Split()[0] == "r")
                {
                    Console.WriteLine(MegaRoll(input.Split().Skip(1).ToArray()));
                    continue;
                }
                foreach (var item in allPlayers.Keys.ToArray<string>())
                    if (item == input)
                    {
                        currentPlayer = allPlayers[input]; continue;
                    }
                if (currentPlayer.realName != "idk")
                {
                    if (input.Split()[0]=="roll")
                    {
                        if (input.Split()[1] == null)
                        {
                            Console.Write("write stat(STR DEX CON INT CHA WIS): ");
                            input = Console.ReadLine().Trim().ToLower();
                        }
                        else
                        {
                            input = input.Split()[1];
                        }
                        Console.WriteLine("ur roll: " + Roll(currentPlayer.characteristics.GetInt(Characteristics.WhatStat(input))));
                    }
                    if (input.Split()[0] == "list")
                    {
                        PlayerList(currentPlayer);
                    }
                }
                else
                    switch (input)
                    {
                        case ("new player"):
                            NewPlayer();
                            break;
                        case ("list player"):
                            ListOfAllPlayer();
                            break;
                        case ("change player"):
                            ChangePlayer();
                            break;
                        default:
                            Console.WriteLine("Unknown command, try again");
                            break;
                    }
            }
        }
        static void NewPlayer()
        {
            Console.Write("Real Name: ");
            string realName = Console.ReadLine();
            Console.Write("Name In Game: ");
            string name = Console.ReadLine();
            Console.Write("Age: ");
            int age = int.Parse(Console.ReadLine());
            Console.Write("Characteristics <str> <dex> <con> <int> <cha> <wis>: ");
            int[] characteristics = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            allPlayers.Add(
                realName,
                new Player(
                    realName,
                    name,
                    age,
                    new Characteristics(
                        characteristics[0],
                        characteristics[1],
                        characteristics[2],
                        characteristics[3],
                        characteristics[4],
                        characteristics[5]
                        )
                    )
                );
        }
        static void ListOfAllPlayer()
        {
            foreach (var item in allPlayers)
            {
                PlayerList(item.Value);
            }
        }
        static void PlayerList(Player player)
        {
            Tools.PO("REAL NAME: ", Console.BackgroundColor, ConsoleColor.Yellow, false);
            Tools.PO(player.realName, Console.BackgroundColor, ConsoleColor.White, true);
            Tools.PO("NAME IN GAME: ", Console.BackgroundColor, ConsoleColor.Yellow, false);
            Tools.PO(player.name, Console.BackgroundColor, ConsoleColor.White, true);
            Console.WriteLine();
            Tools.PO("HUNGER: ", Console.BackgroundColor, ConsoleColor.Yellow, false);
            Tools.PO(player.hunger, Console.BackgroundColor, ConsoleColor.White, true);
            Tools.PO("THRIST: ", Console.BackgroundColor, ConsoleColor.Yellow, false);
            Tools.PO(player.thrist, Console.BackgroundColor, ConsoleColor.White, true);
            Tools.PO("INSANITY: ", Console.BackgroundColor, ConsoleColor.Yellow, false);
            Tools.PO(player.insanity, Console.BackgroundColor, ConsoleColor.White, true);
            Console.WriteLine();
            Tools.PO("CHARACTERISTICS: STR|DEX|CON|INT|CHA|WIS", Console.BackgroundColor, ConsoleColor.Yellow, true);
            Tools.PO($"                 {player.characteristics._str,3}|{player.characteristics._dex,3}|{player.characteristics._con,3}|{player.characteristics._int,3}|{player.characteristics._cha,3}|{player.characteristics._wis,3}", Console.BackgroundColor, ConsoleColor.White, true);
            Tools.PO($"                 {player.characteristics.STR.ToString("###"),3}|{player.characteristics.DEX.ToString("###"),3}|{player.characteristics.CON.ToString("###"),3}|{player.characteristics.INT.ToString("###"),3}|{player.characteristics.CHA.ToString("###"),3}|{player.characteristics.WIS.ToString("###"),3}", Console.BackgroundColor, ConsoleColor.White, true);
            Console.WriteLine();
            Tools.PO("DISCRIPTION: ", Console.BackgroundColor, ConsoleColor.Yellow, true);
            Tools.PO("\tAGE: ", Console.BackgroundColor, ConsoleColor.Yellow, false);
            Tools.PO($"{player.age}", Console.BackgroundColor, ConsoleColor.White, true);
            Tools.PO("\tHEIGHT: ", Console.BackgroundColor, ConsoleColor.Yellow, false);
            Tools.PO($"{player.height}", Console.BackgroundColor, ConsoleColor.White, true);
            Tools.PO("\tWEIGHT: ", Console.BackgroundColor, ConsoleColor.Yellow, false);
            Tools.PO($"{player.weight}", Console.BackgroundColor, ConsoleColor.White, true);
            Console.WriteLine();
            Tools.PO($"\t{player.discription}", Console.BackgroundColor, ConsoleColor.White, true);
            Console.WriteLine();
        }
        static void ChangePlayer()
        {
            Console.Write("Enter player real name: ");
            string key = Console.ReadLine().Trim();
            Console.WriteLine();
            PlayerList(allPlayers[key]);
            Console.Write("what u need to change?");
            Tools.PO("Real Name", Console.BackgroundColor, ConsoleColor.Yellow, false);
            Tools.PO("/", Console.BackgroundColor, ConsoleColor.DarkRed, false);
            Tools.PO("Name", Console.BackgroundColor, ConsoleColor.Yellow, false);
            Tools.PO("/", Console.BackgroundColor, ConsoleColor.DarkRed, false);
            Tools.PO("Characteristics", Console.BackgroundColor, ConsoleColor.Yellow, false);
            Tools.PO("/", Console.BackgroundColor, ConsoleColor.DarkRed, false);
            Tools.PO("Age", Console.BackgroundColor, ConsoleColor.Yellow, false);
            Tools.PO("/", Console.BackgroundColor, ConsoleColor.DarkRed, false);
            Tools.PO("Height", Console.BackgroundColor, ConsoleColor.Yellow, false);
            Tools.PO("/", Console.BackgroundColor, ConsoleColor.DarkRed, false);
            Tools.PO("Weight", Console.BackgroundColor, ConsoleColor.Yellow, false);
            Tools.PO("/", Console.BackgroundColor, ConsoleColor.DarkRed, false);
            Tools.PO("Discription", Console.BackgroundColor, ConsoleColor.Yellow, false);
            Tools.PO("/", Console.BackgroundColor, ConsoleColor.DarkRed, false);
            crutch = Console.ReadLine();
            bool flag = true;
            while (flag) {
                flag = false;
                switch (crutch)
                {
                    case "real name":
                        Console.Write("write new:");
                        allPlayers[key].realName = Console.ReadLine();
                        break;
                    case "name":
                        Console.Write("write new:");
                        allPlayers[key].name = Console.ReadLine();
                        break;
                    case "characteristics":
                        Console.Write("write new(STR DEX CON INT CHA WIS):");
                        int[] aboba = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                        allPlayers[key].characteristics = new Characteristics(
                        aboba[0],
                        aboba[1],
                        aboba[2],
                        aboba[3],
                        aboba[4],
                        aboba[5]
                        );
                        break;
                    case "age":
                        Console.Write("write new num:");
                        allPlayers[key].age = int.Parse(Console.ReadLine());
                        break;
                    case "height":
                        Console.Write("write new:");
                        allPlayers[key].height = int.Parse(Console.ReadLine());
                        break;
                    case "weight":
                        Console.Write("write new:");
                        allPlayers[key].weight = int.Parse(Console.ReadLine());
                        break;
                    case "discription":
                        Console.Write("write new:");
                        allPlayers[key].discription = Console.ReadLine();
                        break;
                    case "canlce":
                        Console.WriteLine();
                        break;
                    default:
                        Console.Write("Unknown Comand");
                        flag = true; break;

                }
            }
            Console.WriteLine();
        }
        static int Roll(int Bonus)
        {
            return new Random().Next(0, 20) + 1 + Bonus;
        }
        static int Roll()
        {
            return Roll(0);
        }
        static int MegaRoll(string[] args)
        {
            Random rnd = new Random();
            int output = 0;
            string buffer = string.Join("",args);
            args = buffer.Split('+');
            foreach (string arg in args) 
            {
                if (arg.Split('d').Count() == 2)
                {
                    for (int i = 0; i < int.Parse(arg.Split('d')[0]); i++)
                    {
                        output += rnd.Next(0, int.Parse(arg.Split('d')[1])) + 1;
                    }
                }
                else
                {
                    output += int.Parse(arg);
                }
            }
            return output;
        }
        static void Save()
        {

        }
    }
}
