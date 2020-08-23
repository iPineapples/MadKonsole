# MadKonsole
MadKonsole is a simple engine for better handling Console Applications in C#.
_____

## Usage

> The files in this repository include the MadKonsole Engine and a simple example Program.
> If you intend on using only the MadKonsole Engine and to ignore the example Program, all you need is **/MadKonsole.cs**.

### Get Started

> You can quickly create a simple MadKonsoleApp by cloning master.
> This way, you can open **/MadKonsole.sln** and you're good to go!

1. Download **/MadKonsole.cs**;
2. Create a C# Console Application;
3. Add **/MadKonsole.cs** to your application's folder;
4. Add the following to your Program.cs or main file.
    
    using MadKonsole;

5. Create a method called Init(), call it from your Main() method;
6. On Init() add the following.
      
        // // Even though this two values are the default,
        // // when setting from Konsole it will also change 
        // // the Buffer so the scrollbar is not too big.
        Konsole.Width = 120;
        Konsole.Height = 30;
        
        // // this disables resizing the screen and maximizing it.
        // // only works on windows OS.
        Konsole.DisableResizing();
        
        // // Clear() will also paint your Konsole.
        // // Make sure to call it once the variables are set.
        MadKonsole.Clear();
        Konsole.CursorX = 1;
        Konsole.CursorY = 1;
