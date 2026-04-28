using Raylib_cs;

partial class Game {
    const int TRUE = 1;
    const int FALSE = 0;

    static Color currentColor = Color.White;

    static void Rect(float x, float y, float width, float height, int filled = TRUE)
    {
        if (filled == TRUE)
            Raylib.DrawRectangle((int)x, (int)y, (int)width, (int)height, currentColor);
        else
            Raylib.DrawRectangleLines((int)x, (int)y, (int)width, (int)height, currentColor);
    }

    static void Line(float x1, float y1, float x2, float y2) =>
        Raylib.DrawLine((int)x1, (int)y1, (int)x2, (int)y2, currentColor);

    static void Text(float x, float y, string txt, int centerX = FALSE, int centerY = FALSE)
    {
        int fontSize = 10;
        int tx = (int)x;
        int ty = (int)y;
        if (centerX == TRUE) tx -= Raylib.MeasureText(txt, fontSize) / 2;
        if (centerY == TRUE) ty -= fontSize / 2;
        Raylib.DrawText(txt, tx, ty, fontSize, currentColor);
    }

    static float Min(float a, float b) => MathF.Min(a, b);
    static int MouseX() => Raylib.GetMouseX();
    static int MouseY() => Raylib.GetMouseY();
    static int MouseDown1() => Raylib.IsMouseButtonDown(MouseButton.Left) ? TRUE : FALSE;
    static int MouseHit1() => Raylib.IsMouseButtonPressed(MouseButton.Left) ? TRUE : FALSE;
}