﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
/*
 *  Collide
 *  Eine Simulation im 2-dimensionalen Raum
 *  Aufgabenverteilung
 *  a) Delago Aaron
 *  b) Auer Tschurtschenthaler Raphael
 *  c) Gufler Jonas
 *  d) Huetter Jonas
 * 
 * 2020 TFO-Meran
 */

namespace ConsoleApplication1
{
    class Program
    {
        const int seite = 50;
        static int[,] feld = new int[seite, seite];

        class einer
        {
            // Private Eigenschaften

            // Öffentliche Eigenschaften
            public int posx, posy;
            public ConsoleColor farbe;

            //Ramdom Generator für Position und Farbe
            Random random_pos = new Random();
            Random random_farbe = new Random();

            // Konstruktor
            public einer()
            {
                int provisionally_posx = 0;
                int provisionally_posy = 0;
                bool pos_available = false;


                //Objekte werden zeitverzögert ezeugt
                System.Threading.Thread.Sleep(20); 
                

                //die Eigenschaft "farbe" wird initialisiert
                farbe = (ConsoleColor)random_farbe.Next(0, 16);


                //Finden einer Position, welche noch frei ist
                do{                                                         
                    provisionally_posx = random_pos.Next(1, seite);
                    provisionally_posy = random_pos.Next(1, seite);

                    if (feld[provisionally_posx, provisionally_posy] == 0)
                    {
                        pos_available = true;
                    }
                } 
                while(pos_available==false);

                posx = provisionally_posx;
                posy = provisionally_posy;

                feld[provisionally_posx, provisionally_posy]=1;
              
     
            }
            //Private Methoden
            void show(int posx, int posy)
            {
                Console.SetCursorPosition(posx, posy);
                Console.Write("0");                             //Zeichnet neuen Punkt an
            }
            void hide(int XBefore, int YBefore)
            {
                Console.SetCursorPosition(XBefore, YBefore);
                Console.Write(" ");                                 //Llöscht vorherige Position
            }
            void collide(int posx, int posy, int XBefore, int YBefore)
            {
                Console.SetCursorPosition(XBefore, YBefore);
                Console.Write("X");                           //Markiert Kollision mit einem X
              
                int provisionally_posx = 0;
                int provisionally_posy = 0;
                bool pos_available = false;


                //Objekte werden zeitverzögert ezeugt
                System.Threading.Thread.Sleep(20); 
                

                //die Eigenschaft "farbe" wird initialisiert
                farbe = (ConsoleColor)random_farbe.Next(0, 16);


                //Finden einer Position, welche noch frei ist
                do{                                                         
                    provisionally_posx = random_pos.Next(1, seite);
                    provisionally_posy = random_pos.Next(1, seite);

                    if (feld[provisionally_posx, provisionally_posy] == 0)
                    {
                        pos_available = true;
                    }
                } 
                while(pos_available==false);

                posx = provisionally_posx;
                posy = provisionally_posy;

                feld[provisionally_posx, provisionally_posy]=1;
            
            
            }
            //Öffentliche Methoden
            public void Move()
            {
            }

        }

        static void Main(string[] args)
        {
            Console.WindowWidth = seite*2;
            Console.WindowHeight = seite;
            Console.Clear();
            Random ZG = new Random();
            int Anzahl=ZG.Next(1,6);
            einer[] meineEiner = new einer[Anzahl];
            for (int i = 0; i < Anzahl; i++)
            {

                meineEiner[i] = new einer();
             
            }
            Console.CursorVisible = false;
            for (int i = 0; i < 1000; i++)
            {
                for (int j = 0; j < Anzahl; j++)
                {
                    meineEiner[j].Move();
                }
                System.Threading.Thread.Sleep(10);

            }
        }
    }
}
