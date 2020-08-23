using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Runtime.InteropServices;
using Microsoft.VisualBasic.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.CompilerServices;

namespace MadKonsole {

    static class Utils {
        
        private const int MF_BYCOMMAND = 0x00000000;
        private const int SC_CLOSE = 0xF060;
        private const int SC_MINIMIZE = 0xF020;
        private const int SC_MAXIMIZE = 0xF030;
        private const int SC_SIZE = 0xF000;
        [DllImport("user32.dll")]
        public static extern int DeleteMenu(IntPtr hMenu, int nPosition, int wFlags);

        [DllImport("user32.dll")]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();


        public static void DisableServices(
            bool _DisableResize = false, 
            bool _DisableCloseBtn = false, 
            bool _DisableMinBtn = false, 
            bool _DisableMaxBtn = false) {

            IntPtr handle = GetConsoleWindow();
            IntPtr sysMenu = GetSystemMenu(handle, false);

            if (handle != IntPtr.Zero) {
                if (_DisableResize) { DeleteMenu(sysMenu, SC_SIZE, MF_BYCOMMAND); }
                if (_DisableCloseBtn) { DeleteMenu(sysMenu, SC_CLOSE, MF_BYCOMMAND); }
                if (_DisableMinBtn) { DeleteMenu(sysMenu, SC_MINIMIZE, MF_BYCOMMAND); }
                if (_DisableMaxBtn) { DeleteMenu(sysMenu, SC_MAXIMIZE, MF_BYCOMMAND); }
                
            }
            
        }
        
        public class Vector2 {
            public int X = 0;
            public int Y = 0;
            public Vector2(int _X, int _Y) {
                X = _X;
                Y = _Y;
            }
        }
    


    }


    class Kolor {
        public const char WHITE = 'w';
        public const char GRAY = 'W';
        public const char BLACK = 'd';
        public const char BLUE = 'b';
        public const char CYAN = 'c';
        public const char GREEN = 'g';
        public const char MAGENTA = 'm';
        public const char RED = 'r';
        public const char YELLOW = 'y';
        public const char DARK_GRAY = 'V';
        public const char DARK_BLUE = 'B';
        public const char DARK_CYAN = 'C';
        public const char DARK_GREEN = 'G';
        public const char DARK_MAGENTA = 'M';
        public const char DARK_RED = 'R';
        public const char DARK_YELLOW = 'Y';
        public const string VALID_COLORS = "wWdbcgmryBCGMRY";
        public static ConsoleColor GetColor(char _Color) {
            switch (_Color) {
                case 'w':
                    return ConsoleColor.White;
                case 'W':
                    return ConsoleColor.Gray;
                case 'd':
                    return ConsoleColor.Black;
                case 'b':
                    return ConsoleColor.Blue;
                case 'c':
                    return ConsoleColor.Cyan;
                case 'g':
                    return ConsoleColor.Green;
                case 'm':
                    return ConsoleColor.Magenta;
                case 'r':
                    return ConsoleColor.Red;
                case 'y':
                    return ConsoleColor.Yellow;
                case 'V':
                    return ConsoleColor.DarkGray;
                case 'B':
                    return ConsoleColor.DarkBlue;
                case 'C':
                    return ConsoleColor.DarkCyan;
                case 'G':
                    return ConsoleColor.DarkGreen;
                case 'M':
                    return ConsoleColor.DarkMagenta;
                case 'R':
                    return ConsoleColor.DarkRed;
                case 'Y':
                    return ConsoleColor.DarkYellow;
                default:
                    return ConsoleColor.White;
            }   
        }
    
    
    }




    public class KBox {

        public int PosX = 999;
        public int PosY = 999;
        public int Width = 24;
        public int Height = 6;
        public string Title = "";
        public string Text = "";
        public char BackgroundColor = '¨';
        public char LightColor = '¨';
        public char DarkColor = '¨';
        public char TopLeftCorner = '¨';
        public char TopRightCorner = '¨';
        public char BotLeftCorner = '¨';
        public char BotRightCorner = '¨';
        public char VerticalLine = '¨';
        public char HorizontalLine = '¨';
        public char ShadowChar = '¨';
        public char FillingChar = '¨';

        public void Draw() {
            //


            static void WriteShadowChar(char _DarkColor, char _LightColor, char _BackgroundColor) {
                Console.BackgroundColor = Kolor.GetColor(_DarkColor);
                Console.ForegroundColor = Kolor.GetColor(_LightColor);
                Console.Write("▒");
                Console.BackgroundColor = Kolor.GetColor(_BackgroundColor);
                Console.ForegroundColor = Kolor.GetColor(_DarkColor);
            }

            // Changes to Default Colors if not specified.
            if (BackgroundColor == '¨') {
                BackgroundColor = Konsole.Default.BoxBackgroundColor;
            }
            if (LightColor == '¨') {
                LightColor = Konsole.Default.BoxLightColor;
            }
            if (DarkColor == '¨') {
                DarkColor = Konsole.Default.BoxDarkColor;
            }

            // Changes to Default Characters if not specified.
            // Also changes to Current Position if not specidfied.
            if (TopLeftCorner == '¨') {
                TopLeftCorner = Konsole.Default.BoxTopLeftCorner;
            }
            if (TopRightCorner == '¨') {
                TopRightCorner = Konsole.Default.BoxTopRightCorner;
            }
            if (BotLeftCorner == '¨') {
                BotLeftCorner = Konsole.Default.BoxBotLeftCorner;
            }
            if (BotRightCorner == '¨') {
                BotRightCorner = Konsole.Default.BoxBotRightCorner;
            }
            if (VerticalLine == '¨') {
                VerticalLine = Konsole.Default.BoxVerticalLine;
            }
            if (HorizontalLine == '¨') {
                HorizontalLine = Konsole.Default.BoxHorizontalLine;
            }
            if (ShadowChar == '¨') {
                ShadowChar = Konsole.Default.BoxShadowChar;
            }
            if (FillingChar == '¨') {
                FillingChar = Konsole.Default.BoxFillingChar;
            }

            if (PosX == 999) {
                PosX = Console.CursorLeft;
            }
            if (PosY == 999) {
                PosY = Console.CursorTop;
            }

            // Makes sure the BOX isn't too small.
            if (Width < 1) {
                Width = 1;
            }
            if (Height < 1) {
                Height = 1;
            }


            // > DRAWS THE BOX <.

            // Moves the cursor to the specified position.
            Console.CursorLeft = PosX;
            Console.CursorTop = PosY;

            // Prints the 1 LINE of the box.        I. e..: ┌──────┐
            int _FirstLineTopPos = Console.CursorTop;       // For printing the Title
            int _FirstLineLeftPos = Console.CursorLeft;     // ^^
            Console.BackgroundColor = Kolor.GetColor(BackgroundColor);
            Console.ForegroundColor = Kolor.GetColor(LightColor);
            //Console.BackgroundColor = Kolor.GetColor(LightColor);
            Console.Write(TopLeftCorner);
            for (int i = 0; i < Width; i++) {
                if (i == Width) { Console.BackgroundColor = Kolor.GetColor(BackgroundColor); }
                Console.Write(HorizontalLine);
            }
            Console.Write(TopRightCorner);

            // Prints the SIDES of the box.         I. e..: │      │▒
            Console.CursorTop++;
            Console.CursorLeft -= Width + 2;
            for (int j = 0; j < Height; j++) {
                if (j < Height - 1) { Console.ForegroundColor = Kolor.GetColor(LightColor); }
                Console.Write(VerticalLine);
                Console.ForegroundColor = Kolor.GetColor(DarkColor);

                for (int k = 0; k < Width; k++) {
                    //Console.BackgroundColor = Kolor.GetColor('c');
                    Console.Write(FillingChar);
                }
                if (j == 0) { Console.ForegroundColor = Kolor.GetColor(LightColor); }
                Console.Write(VerticalLine);
                //Console.Write(_ShadowChar);
                WriteShadowChar(DarkColor, LightColor, BackgroundColor);
                Console.CursorTop++;
                Console.CursorLeft -= Width + 3;
            }

            // Prints the LAST LINE of the box.     I.e..: └──────┘▒
            Console.Write(BotLeftCorner);
            for (int l = 0; l < Width; l++) {
                Console.Write(HorizontalLine);
            }
            Console.Write(BotRightCorner);
            //Console.Write("▒");
            WriteShadowChar(DarkColor, LightColor, BackgroundColor);
            Console.CursorTop++;
            Console.CursorLeft -= Width + 2;

            // Prints the LAST SHADOW of the box.   I.e..:  ▒▒▒▒▒▒▒▒
            for (int i = 0; i <= Width + 1; i++) {
                //Console.Write("▒");
                WriteShadowChar(DarkColor, LightColor, BackgroundColor);
            };

            // Draws the TITLE on the 1st LINE of the box.

            int _cursPosTop = Console.CursorTop;
            int _cursPosLeft = Console.CursorLeft;

            if (Title != "") {

                Console.CursorTop = _FirstLineTopPos;
                Console.CursorLeft = _FirstLineLeftPos + ( ( Width / 2 ) - ( Title.Length / 2 ) );
                Console.ForegroundColor = Kolor.GetColor(LightColor);
                Console.Write(Title);
                Console.ForegroundColor = Kolor.GetColor(DarkColor);
                Console.CursorTop = _cursPosTop;
                Console.CursorLeft = _cursPosLeft;

            }

            // Print the CENTRAL TEXT of the BOX.
            void DrawTextOnTheBox() {

                string _Text = Text;
                StringBuilder sb = new StringBuilder();

                for (int i = 0; i < _Text.Length; i++) {
                    if (i % Width == 0) {
                        //if (i != 0) 
                        sb.Append('¨');
                    }
                    sb.Append(_Text[i]);
                }
                string _TextWithFormatting = sb.ToString();
                string[] _TextLines = _TextWithFormatting.Split('¨');

                //Console.CursorTop++;

                Console.CursorTop = PosY;
                foreach (string _Line in _TextLines) {
                    Console.CursorLeft = PosX + 1;
                    Console.Write(_Line);
                    Console.CursorTop++;
                }

                Console.CursorTop = _cursPosTop;
                Console.CursorLeft = _cursPosLeft;

            }

            DrawTextOnTheBox();
            Konsole.ResetColor();
            // END OF BOX CLASS

        }

    }





    class Konsole {
        
        // DEFAULT initiates colors and common variables.
        public static class Default {

            public static string Margin = "  ";
            public static string Indent = "    ";
            public static string AskLinePrefix = "  > ";
            public static char GlyphColor = Kolor.WHITE;
            public static char CellColor = Kolor.DARK_MAGENTA;
            public static char AskLineGlyphColor = Kolor.WHITE;
            public static char AskLineCellColor = Kolor.DARK_GREEN;
            public static char AnnounceGlyphColor = Kolor.RED;
            public static char AnnounceCellColor = Kolor.WHITE;

            // BOX DRAWING
            public static char BoxBackgroundColor = Kolor.WHITE;
            public static char BoxLightColor = Kolor.DARK_CYAN;
            public static char BoxDarkColor = Kolor.DARK_GRAY;
            public static char BoxTopLeftCorner = '╔';
            public static char BoxTopRightCorner = '╗';
            public static char BoxBotLeftCorner = '╚';
            public static char BoxBotRightCorner = '╝';
            public static char BoxVerticalLine = '║';
            public static char BoxHorizontalLine = '═';
            public static char BoxShadowChar = '▒';
            public static char BoxFillingChar = ' ';
        }


        // Create aliases for normal Console parameters.
        // Create new methods for Konsole applications.
        public static int CursorX {
            get => Console.CursorLeft;

            set {
                Console.CursorLeft = value;
            }
        }
        public static int CursorY {
            get => Console.CursorTop;

            set {
                Console.CursorTop = value;
            }
        }
        public static bool CursorVisible {
            get => Console.CursorVisible;

            set {
                Console.CursorVisible = value;
            }
        }
        public static int Width {
            get => Console.WindowWidth;
            set {
                Console.WindowWidth = value;
                //Console.BufferWidth = value;
            }
        }
        public static int Height {
            get => Console.WindowHeight;
            set {
                Console.WindowHeight = value;
                Console.BufferHeight = value;

            }
        }
        public static int MiddleWidth {
            get => (Console.WindowWidth/2);
        }
        public static int MiddleHeight {
            get => (Console.WindowHeight/2);
        }
        public static void DisableResizing() {
            Utils.DisableServices(true, false, false, true); }
        

        //  METHODS
        public static void ResetColor() {
            Console.ForegroundColor = Kolor.GetColor(Default.GlyphColor);
            Console.BackgroundColor = Kolor.GetColor(Default.CellColor);
        }

        private static string CleanScreen;
        public static void Clear() {


            Console.ResetColor();
            for (int i = 0; i < Console.WindowHeight; i++) {

                for (int j = 0; j < Console.WindowWidth; j++) {
                
                    CleanScreen = (CleanScreen + " ");
                }

                CleanScreen = (CleanScreen + "\n");
            }
            
            Console.ForegroundColor = Kolor.GetColor(Default.GlyphColor);
            Console.BackgroundColor = Kolor.GetColor(Default.CellColor);
            Console.Write(CleanScreen);
            Console.CursorLeft = 0;
            Console.CursorTop = 0;
            Console.Write("\n" + Default.Margin);
        }

        public static void ClearLine(int _Line) {
            int _oldTop = Console.CursorTop;
            int _oldLeft = Console.CursorLeft;
            Console.CursorLeft = 0;
            Console.CursorTop = _Line;
            for (int i = 1; i <= Console.WindowWidth; i++) {
                Console.ForegroundColor = Kolor.GetColor(Default.GlyphColor);
                Console.BackgroundColor = Kolor.GetColor(Default.CellColor);
                Console.Write(" ");
            }
            Console.CursorTop = _oldTop;
            Console.CursorLeft = _oldLeft;
        }

        public static void ChangeCell(int _PosX, int _PosY, 
            char _Glyph, char _GlyphColor, char _CellColor) {

            int _oldLeft = Console.CursorLeft;
            int _oldTop = Console.CursorTop;
            Console.CursorLeft = _PosX;
            Console.CursorTop = _PosY;
            Console.ForegroundColor = Kolor.GetColor(_GlyphColor);
            Console.BackgroundColor = Kolor.GetColor(_CellColor);
            Console.Write(_Glyph);
            Console.ResetColor();
            Console.CursorLeft = _oldLeft;
            Console.CursorTop = _oldTop;
        }

        public static void InLine(string _Text, 
            char _GlyphColor = '.', char _CellColor = '.') {

            Console.ForegroundColor = 
                Kolor.VALID_COLORS.Contains(_GlyphColor) 
                ? Kolor.GetColor(_GlyphColor) 
                : Kolor.GetColor(Default.GlyphColor);

            Console.BackgroundColor = 
                Kolor.VALID_COLORS.Contains(_CellColor) 
                ? Kolor.GetColor(_CellColor) 
                : Kolor.GetColor(Default.CellColor);

            Console.Write(_Text);
            Console.ResetColor();
        }

        public static void InLine(bool _RepositionCursor, 
            int _PosX = 999, int _PosY = 999, string _Text = "", 
            char _GlyphColor = '.', char _CellColor = '.') {

            int _oldLeft = Console.CursorLeft;
            int _oldTop = Console.CursorTop;

            if (_PosX != 999) {
                Console.CursorLeft = _PosX;
            }
            if (_PosY != 999) {
                Console.CursorTop = _PosY;
            }

            Console.ForegroundColor = 
                Kolor.VALID_COLORS.Contains(_GlyphColor) 
                ? Kolor.GetColor(_GlyphColor) 
                : Kolor.GetColor(Default.GlyphColor);

            Console.BackgroundColor = 
                Kolor.VALID_COLORS.Contains(_CellColor) 
                ? Kolor.GetColor(_CellColor) 
                : Kolor.GetColor(Default.CellColor);

            Console.Write(_Text);
            Konsole.ResetColor();

            if (_RepositionCursor) {
                Console.CursorLeft = _oldLeft;
                Console.CursorTop = _oldTop;
            }
        }

        public static void NewLine(string _Text = "",
            char _GlyphColor = '.', 
            char _CellColor = '.', 
            bool _WithMargin = true) {
            //

            Console.CursorLeft = 0;
            
            if (Kolor.VALID_COLORS.Contains(_GlyphColor)) {
                Console.ForegroundColor = Kolor.GetColor(_GlyphColor);
            } else {
                Console.ForegroundColor = Kolor.GetColor(Default.GlyphColor);
            }

            if (Kolor.VALID_COLORS.Contains(_CellColor)) {
                Console.BackgroundColor = Kolor.GetColor(_CellColor);
            } else {
                Console.BackgroundColor = Kolor.GetColor(Default.CellColor);
            }

            if (_WithMargin) {
                _Text = _Text.Replace("\n", "\n" + Konsole.Default.Margin);
                Console.WriteLine(Konsole.Default.Margin + _Text);
            } else {
                Console.WriteLine(_Text);
            }
            Konsole.ResetColor();

        }

        public static void NewLine(bool _WithMargin, 
            int _PosX = 999, int _PosY = 999, 
            string _Text = "", char _GlyphColor = '.', 
            char _CellColor = '.') {
            //

            if (_PosX != 999) {
                Console.CursorLeft = _PosX;
            } else {
                Console.CursorLeft = 0;
            }

            if (_PosY != 999) {
                Console.CursorTop = _PosY;
            }

            if (Kolor.VALID_COLORS.Contains(_GlyphColor)) {
                Console.ForegroundColor = Kolor.GetColor(_GlyphColor);
            } else {
                Console.ForegroundColor = Kolor.GetColor(Default.GlyphColor);
            }

            if (Kolor.VALID_COLORS.Contains(_CellColor)) {
                Console.BackgroundColor = Kolor.GetColor(_CellColor);
            } else {
                Console.BackgroundColor = Kolor.GetColor(Default.CellColor);
            }

            if (_WithMargin) {
                _Text = _Text.Replace("\n", "\n" + Konsole.Default.Margin);
                Console.WriteLine(Konsole.Default.Margin + _Text);
            } else {
                Console.WriteLine(_Text);
            }
            Konsole.ResetColor();
            
        }

        public static string AskLine(string _Prefix = "¨¨&42&¨¨", 
            char _GlyphColor = '.', char _CellColor = '.') {
            //

            if (Kolor.VALID_COLORS.Contains(_GlyphColor)) {
                Console.ForegroundColor = Kolor.GetColor(_GlyphColor);
            } else {
                Console.ForegroundColor = Kolor.GetColor(Default.AskLineGlyphColor);
            }

            if (Kolor.VALID_COLORS.Contains(_CellColor)) {
                Console.BackgroundColor = Kolor.GetColor(_CellColor);
            } else {
                Console.BackgroundColor = Kolor.GetColor(Default.AskLineCellColor);
            }

            if (_Prefix == "¨¨&42&¨¨") {
                Console.Write(Konsole.Default.AskLinePrefix);
            } else {
                Console.Write(_Prefix);
            }

            Konsole.ResetColor();

            Console.Write(" ");

            string _Input = Console.ReadLine();

            return _Input;

        }

        public static string AskLine(bool _RepositionCursor, 
            int _PosX = 999, int _PosY = 999,
            string _Prefix = "¨¨&42&¨¨", char _GlyphColor = '.', 
            char _CellColor = '.') {
            //

            int _oldLeft = Console.CursorLeft;
            int _oldTop = Console.CursorTop;

            if (_PosX != 999) {
                Console.CursorLeft = _PosX;
            }
            if (_PosY != 999) {
                Console.CursorTop = _PosY;
            }

            if (Kolor.VALID_COLORS.Contains(_GlyphColor)) {
                Console.ForegroundColor = Kolor.GetColor(_GlyphColor);
            } else {
                Console.ForegroundColor = Kolor.GetColor(Default.AskLineGlyphColor);
            }

            if (Kolor.VALID_COLORS.Contains(_CellColor)) {
                Console.BackgroundColor = Kolor.GetColor(_CellColor);
            } else {
                Console.BackgroundColor = Kolor.GetColor(Default.AskLineCellColor);
            }

            if (_Prefix == "¨¨&42&¨¨") {
                Console.Write(Konsole.Default.AskLinePrefix);
            } else {
                Console.Write(_Prefix);
            }
            
            Konsole.ResetColor();

            Console.Write(" ");

            string _Input = Console.ReadLine();
            
            if (_RepositionCursor) {
                Console.CursorLeft = _oldLeft;
                Console.CursorTop = _oldTop;
            }

            return _Input;
        
        }



        public static int PopUp(string _Message, string _OptionOne, 
            string _OptionTwo = "", string _OptionThree = "") {
        //
        

            
            return 42;
        }

    }

}