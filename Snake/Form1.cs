﻿using System;
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

            lblScore.Text = Settings.Score.ToString();
            //Rozpoczecie generowania jedzenia
            GenerateFood();

        }
        //losowe generowanie jedzenia, musimy znac maksymalny rozmiar obszaru gry 
        private void GenerateFood()
        {
            int maxXPos = pbCanvas.Size.Width / Settings.Width;
            int maxYPos = pbCanvas.Size.Height / Settings.Height;

            //zadeklarowanie random objectu
            Random random = new Random();
            food = new Circle();
            food.X = random.Next(0, maxXPos); //losowanie od zera do max rozmiaru okienka wzgledem szerokosci
            food.Y = random.Next(0, maxYPos); //losowanie od zera do max rozmiaru okienka wzgledem wysokosci
        }
        //ta metoda bedzie sprawdzala naciskane klawisze
        private void UpdateScreen(object sender, EventArgs e)
        {
            //Sprawdzanie czy gra jeszcze trwa
            if(Settings.GameOver == true)
            {
                //Sprawdzanie czy ENTER zostal nacisniety
                if(Input.KeyPressed(Keys.Enter))
                {
                    StartGame();
                }
            }
            else
            {   //Zmiana kierunku ruchu weza  w zaleznosci ktora ze strzalek nacisniemy i jezeli waz idzie w lewo i nacisniemy prawa strzalke to zeby nie mogl tak skrecic itd
                if (Input.KeyPressed(Keys.Right) && Settings.direction != Direction.Left)
                    Settings.direction = Direction.Right;
                else if(Input.KeyPressed(Keys.Left) && Settings.direction != Direction.Right)
                    Settings.direction = Direction.Left;
                else if (Input.KeyPressed(Keys.Up) && Settings.direction != Direction.Down)
                    Settings.direction = Direction.Up;
                else if (Input.KeyPressed(Keys.Down) && Settings.direction != Direction.Up)
                    Settings.direction = Direction.Down;

            }

        }
        private void pbCanvas_Click(object sender, EventArgs e)
        {

        }
    }
}
