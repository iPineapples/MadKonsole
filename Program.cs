using System;
using System.Globalization;
using System.Runtime.InteropServices.ComTypes;
using MadKonsole;

namespace MadKonsoleApp
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Init();
            Start();   
        }

        static void Init() {

            Konsole.Width = 120;
            Konsole.Height = 30;
            Konsole.DisableResizing();

            Konsole.Clear();

            KBox myBox = new KBox();

            myBox.Title = "Magrathea...";
            myBox.PosX = 20;
            myBox.PosY = 10;
            myBox.Width = 50;
            myBox.Text = "The Answer to the Ultimate Question of Life, the Universe, and Everything is...";
            myBox.Draw();
            Console.ReadKey();
            myBox.Title = "7½ Million Years Later...";
            myBox.Text = "And finally, the supercomputer Deep Thought came up with THE answer: 42!";
            myBox.Draw();
            Console.ReadKey();
            }

        static void Start() {
        
        }
    }
}
