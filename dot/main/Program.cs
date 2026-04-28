using rl = Raylib_cs;

partial class Game {



    static void Main() {
        
        const int Freq		=	44100;	//Hz
        const int Channels	=	64	;	//Standartwert
        const int Flags		=	0;
        const int Mode		=	2	;	//Mode = 2 means that the sounds play in a loop
        const int F_Offset	=	0;
        const int Lenght	=	0;
        const int MaxVol	=	255;
        const int MinVol	=	0;
        const int PanLeft	=	0;
        const int PanRight	=	255;
        const int PanMid	=	-1;
        const int AllChannel=	-3;
        const int FreeChannel = -1;

        FSOUND_Init(Freq, Channels, Flags);
       
        Include "fullscreen_window_fix.bb"
        Include "KeyName.bb"

        String OptionFile = "options.ini";
        
    }
}