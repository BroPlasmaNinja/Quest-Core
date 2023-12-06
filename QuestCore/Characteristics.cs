using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestCore
{
    public class Characteristics
    {
        public enum EnumCharacteristics
        {
            STR,
            DEX,
            CON,
            INT,
            WIS,
            CHA
        }
        public int _str;
        public int _dex;
        public int _con;
        public int _int;
        public int _wis;
        public int _cha;
        public int STR { get { return _str / 3 - 1; } }
        public int DEX { get { return _dex / 3 - 1; } }
        public int CON { get { return _con / 3 - 1; } }
        public int INT { get { return _int / 3 - 1; } }
        public int WIS { get { return _wis / 3 - 1; } }
        public int CHA { get { return _cha / 3 - 1; } }
        public int GetInt(EnumCharacteristics @char)
        {
            switch (@char)
            {
                case EnumCharacteristics.STR: return STR;
                case EnumCharacteristics.DEX: return DEX;
                case EnumCharacteristics.CON: return CON;
                case EnumCharacteristics.WIS: return WIS;
                case EnumCharacteristics.CHA: return CHA;
                case EnumCharacteristics.INT: return INT;
                default: return int.MaxValue;
            }
        }
        public Characteristics(int str, int dex, int con, int @int, int wis, int cha)
        {
            _str = str;
            _dex = dex;
            _con = con;
            _int = @int;
            _wis = wis;
            _cha = cha;
        }
        public Characteristics(Characteristics characteristics)
        {
            _str = characteristics._str;
            _dex = characteristics._dex;
            _con = characteristics._con;
            _int = characteristics._int;
            _wis = characteristics._wis;
            _cha = characteristics._cha;

        }
        public Characteristics() 
        {
            _str = 0;
            _dex = 0;
            _con = 0;
            _int = 0;
            _wis = 0;
            _cha = 0;
        }
        public static EnumCharacteristics WhatStat(string input)
        {
            input = input.ToLower().Trim();
            switch (input)
            {
                case ("str"):
                    return Characteristics.EnumCharacteristics.STR;
                case ("dex"):
                    return Characteristics.EnumCharacteristics.DEX;
                case ("con"):
                    return Characteristics.EnumCharacteristics.CON;
                case ("int"):
                    return Characteristics.EnumCharacteristics.INT;
                case ("cha"):
                    return Characteristics.EnumCharacteristics.CHA;
                case ("wis"):
                    return Characteristics.EnumCharacteristics.WIS;
                default:
                    throw new Exception("wrong input WhatStat");
            }
        }
    }
}
