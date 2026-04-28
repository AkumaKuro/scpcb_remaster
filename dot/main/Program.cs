using rl = Raylib_cs;

partial class Game {

    static void Main() {
        

        
        float MenuScale = 1.0f;
        int mouseHit1Consumed = FALSE;

        

        

        int Button(float x, float y, float width, float height, string txt, int disabled = FALSE)
        {
            int Pushed = FALSE;

            Color(50, 50, 50);
            if (disabled == FALSE)
            {
                if (MouseX() > x && MouseX() < x + width)
                {
                    if (MouseY() > y && MouseY() < y + height)
                    {
                        if (MouseDown1() == TRUE)
                        {
                            Pushed = TRUE;
                            Color((int)(50 * 0.6f), (int)(50 * 0.6f), (int)(50 * 0.6f));
                        }
                        else
                        {
                            Color((int)Min(50 * 1.2f, 255), (int)Min(50 * 1.2f, 255), (int)Min(50 * 1.2f, 255));
                        }
                    }
                }
            }

            if (Pushed == TRUE)
            {
                Rect(x, y, width, height);
                Color(133, 130, 125);
                Rect(x + 1 * MenuScale, y + 1 * MenuScale, width - 1 * MenuScale, height - 1 * MenuScale, FALSE);
                Color(10, 10, 10);
                Rect(x, y, width, height, FALSE);
                Color(250, 250, 250);
                Line(x, y + height - 1 * MenuScale, x + width - 1 * MenuScale, y + height - 1 * MenuScale);
                Line(x + width - 1 * MenuScale, y, x + width - 1 * MenuScale, y + height - 1 * MenuScale);
            }
            else
            {
                Rect(x, y, width, height);
                Color(133, 130, 125);
                Rect(x, y, width - 1 * MenuScale, height - 1 * MenuScale, FALSE);
                Color(250, 250, 250);
                Rect(x, y, width, height, FALSE);
                Color(10, 10, 10);
                Line(x, y + height - 1, x + width - 1, y + height - 1);
                Line(x + width - 1, y, x + width - 1, y + height - 1);
            }

            Color(255, 255, 255);
            if (disabled == TRUE) Color(70, 70, 70);
            Text(x + width / 2, y + height / 2 - 1 * MenuScale, txt, TRUE, TRUE);

            Color(0, 0, 0);

            if (Pushed == TRUE && MouseHit1() == TRUE)
                return TRUE;

            return FALSE;
        }

        Graphics(800, 450, 0, GraphicsMode.WINDOWED);

        while (!(KeyHit(rl.KeyboardKey.Escape) != 0))
        {
            ClsColor(200, 200, 200);
            Cls();

            Button(100, 100, 120, 30, "Click Me");
            Button(100, 150, 120, 30, "Disabled", TRUE);

            Flip();
        }

        End();
    }
}