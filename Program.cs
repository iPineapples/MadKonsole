using System;
using System.Globalization;
using System.Linq;
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
            

            // After the Cleaning, the app should have
            // already initialized essential variables.
            // Add with caution after this message.
            Konsole.Clear();

            Konsole.CursorY = 1;
            Konsole.CursorX = 2;
            
        }

        static void Start() {

            KBox b = new KBox();
            b.Title =   " PopUp | MAIN MENU ";
            b.Text  =   "                          " +
                        "                       " +
                        "[q][Enter] for [Q]uit." +
                        "                          " +
                        "[t][Enter] for [T]ool.";
            b.PosX = 2;
            b.PosY = 1;
            b.Width = 48;
            b.Height = 6;

            KBox LeftResultBox = new KBox();
            LeftResultBox.Title = "";
            LeftResultBox.Text = " Welcome! Follow the menu above.";
            LeftResultBox.DarkColor = Kolor.DARK_GREEN;
            LeftResultBox.LightColor = Kolor.DARK_YELLOW;
            LeftResultBox.BackgroundColor = Kolor.YELLOW;
            LeftResultBox.Width = 48;
            LeftResultBox.Height = 2;
            //LeftResultBox.PosX = b.PosX + b.Width + 5;
            LeftResultBox.PosY = b.Height + b.PosY + LeftResultBox.Height + 2;


            LeftResultBox.Draw();
            b.Draw();

            string VALID_OPTIONS = "qt";
            string _Input = "";

            while (!VALID_OPTIONS.Contains(_Input) || _Input == "") {
                _Input =
                Konsole.AskLine(true, b.BotPosX, b.BotPosY,
                " >", Kolor.DARK_MAGENTA, Kolor.WHITE,
                Kolor.DARK_MAGENTA, Kolor.WHITE);

                Konsole.CursorX = b.PosX + b.Width + 6;
                Konsole.CursorY = 1;

                if (!VALID_OPTIONS.Contains(_Input) || _Input == "")
                    LeftResultBox.Text = " <|º_º|> Invalid option.";
                //Konsole.InLine("<|º_º|> Invalid option.", Kolor.DARK_GRAY);
                LeftResultBox.Draw();
                b.Draw();

            }


            switch (_Input.ToLower()) {
                case "q":
                    Konsole.Clear();
                    Konsole.AskLine(false, 1, Konsole.Height-2, 
                        " > Press [ENTER] to exit the application.",
                        Kolor.CYAN, Kolor.DARK_MAGENTA, Kolor.DARK_MAGENTA, Kolor.DARK_MAGENTA);
                    Environment.Exit(42);

                    break;
                case "t":
                    Konsole.Clear();
                    Tool();
                    break;
            }

            b = null;

        }
    
        static void Tool() {



        }
    }
}
