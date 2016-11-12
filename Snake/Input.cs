using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    class Input
    {
         //Zaladowanie listy mozliwych przyciskow wprowadzanych z klawiatury 
        private static Hashtable keyTable = new Hashtable();
        //Zainicjonowanie sprawdzenia czy jakis przycisk z klawiatury zostal nacisniety
        public static bool KeyPressed(Keys key)
        {
            if (keyTable[key] == null)
            {
                return false;
            }
            return (bool)keyTable[key];
        }
        //Sprawdzenie czy jakis pzycisk zostal nacisniety
        public static void ChangeState(Keys key, bool state)
        {
            keyTable[key] = state;
        }
    }
}
