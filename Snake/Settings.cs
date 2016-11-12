using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{   //globalne ustawienia dla pojedynczej gry 
    public enum Direction { Up,Down,Left,Right};
    class Settings
    {
        public static int Width { get; set; }       //Do rysowania kolek
        public static int Height { get; set; }      //Do rysowania kolek
        public static int Speed { get; set; }       //Okresla jak szybko gracz sie porusza
        public static int Score  { get; set; }      //Ogolny wynik aktualnej gry
        public static int Points { get; set; }      //Aktualizuje punkty na bierzaco w trakcie gry 
        public static bool GameOver { get; set; }   //Wartosc true - gra sie konczy , false - gra dalej trwa
        public static Direction direction { get; set; } //Oczywiscie mozemy uzywac tych rzeczy z tej klasy w innych klasach bez potrzeby ponownej deklaracji ich

        public Settings() //Konstruktor
        {
            Width = 16;  // ``|
            Height = 16; //   |--- wartosci parametrow na start, jakie nam pasuja
            Speed = 16;  // __|
            Score = 0; // 0 punktow wyniku na start nowej gry 
            Points = 100; //Ile punktow dostaniemy podczas gdy jakis obiekt zostanie ,,zjedzony", tez mozemy wstawic inna wartosc
            GameOver = false; // false (jak wyzej) - czyli gra trwa dalej, poniewaz to poczatek gry 
            direction = Direction.Down; //W jakim kierunku na starcie zostanie wykonany pierwszy ruch 
        }
    }
}
