using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    public partial class Form1 : Form
    {
        //Deklaracja nowego gracza, jest to lista ,,kolek" z Circle class, wiec potrzebujemy zadeklarowac nowa liste 
        private List<Circle>Snake = new List<Circle>();
        //Jedzenie wyswietlane na ekranie tez bedzie w formie kolek wiec:
        private Circle food = new Circle();

        public Form1()
        {
            InitializeComponent();

            //Zainicjonowanie domyslnych ustawien gry ustalonych w klasie settings
            new Settings();
            //Zainicjonowanie szybkosci gry i stopera
            gameTimer.Interval = 1000 / Settings.Speed; // 1000ms
            gameTimer.Tick += UpdateScreen();
            gameTimer.Start();
            //Rozpoczecie nowej gry 
            StartGame();
            //To co zostalo tutaj napisane powoduje, ze za kazdym razem gdy program jest uruchamiany na nowo, zostaja zresetowane ustawienia gry do domyslnych
            // (ustalone w klasie Settings) oraz ustalenie szybkosci gry 

        }
        private void StartGame()
        {
            new Settings(); //Ponowne zresetowanie ustawien po to, aby gdy gracz zobaczy ekran koncowy (przegra) i zagra ponownie to wszystkie ustawienia zmienia sie na domyslne
            Snake.Clear(); //Wyczyszczenie ,,kolek" z poprzedniej gry (zeby nie pojawily sie w nowej grze)
            //Tworzenie nowego gracza (weza)
            Circle head = new Circle();
            head.X = 10;  //``|_____ Wspolrzedne pojawienia sie glowy 
            head.Y = 5;   //__|
            Snake.Add(head);  //mamy teraz stworzonego nowego weza o dlugosci jednego kolka



        }
        private void pbCanvas_Click(object sender, EventArgs e)
        {

        }
    }
}
