using Raylib_cs;

partial class Game {

    static void Main() {
        

        
        float MenuScale = 1.0f;
        int mouseHit1Consumed = FALSE;

        void SetColor(int r, int g, int b) =>
            currentColor = new Color(r, g, b, 255);

        

        int Button(float x, float y, float width, float height, string txt, int disabled = FALSE)
        {
            int Pushed = FALSE;

            SetColor(50, 50, 50);
            if (disabled == FALSE)
            {
                if (MouseX() > x && MouseX() < x + width)
                {
                    if (MouseY() > y && MouseY() < y + height)
                    {
                        if (MouseDown1() == TRUE)
                        {
                            Pushed = TRUE;
                            SetColor((int)(50 * 0.6f), (int)(50 * 0.6f), (int)(50 * 0.6f));
                        }
                        else
                        {
                            SetColor((int)Min(50 * 1.2f, 255), (int)Min(50 * 1.2f, 255), (int)Min(50 * 1.2f, 255));
                        }
                    }
                }
            }

            if (Pushed == TRUE)
            {
                Rect(x, y, width, height);
                SetColor(133, 130, 125);
                Rect(x + 1 * MenuScale, y + 1 * MenuScale, width - 1 * MenuScale, height - 1 * MenuScale, FALSE);
                SetColor(10, 10, 10);
                Rect(x, y, width, height, FALSE);
                SetColor(250, 250, 250);
                Line(x, y + height - 1 * MenuScale, x + width - 1 * MenuScale, y + height - 1 * MenuScale);
                Line(x + width - 1 * MenuScale, y, x + width - 1 * MenuScale, y + height - 1 * MenuScale);
            }
            else
            {
                Rect(x, y, width, height);
                SetColor(133, 130, 125);
                Rect(x, y, width - 1 * MenuScale, height - 1 * MenuScale, FALSE);
                SetColor(250, 250, 250);
                Rect(x, y, width, height, FALSE);
                SetColor(10, 10, 10);
                Line(x, y + height - 1, x + width - 1, y + height - 1);
                Line(x + width - 1, y, x + width - 1, y + height - 1);
            }

            SetColor(255, 255, 255);
            if (disabled == TRUE) SetColor(70, 70, 70);
            Text(x + width / 2, y + height / 2 - 1 * MenuScale, txt, TRUE, TRUE);

            SetColor(0, 0, 0);

            if (Pushed == TRUE && MouseHit1() == TRUE)
                return TRUE;

            return FALSE;
        }

        Raylib.InitWindow(800, 450, "Button Test");

        while (!Raylib.WindowShouldClose())
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.RayWhite);

            Button(100, 100, 120, 30, "Click Me");
            Button(100, 150, 120, 30, "Disabled", TRUE);

            Raylib.EndDrawing();
        }

        Raylib.CloseWindow();
    }
}