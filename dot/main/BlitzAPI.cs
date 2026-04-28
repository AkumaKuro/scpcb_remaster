using System.Reflection.Metadata;
using rl = Raylib_cs;

partial class Game {
    const int TRUE = 1;
    const int FALSE = 0;

    static rl.Color currentColor = rl.Color.White;

    static void Rect(float x, float y, float width, float height, int filled = TRUE)
    {
        if (filled == TRUE)
            rl.Raylib.DrawRectangle((int)x, (int)y, (int)width, (int)height, currentColor);
        else
            rl.Raylib.DrawRectangleLines((int)x, (int)y, (int)width, (int)height, currentColor);
    }

    static void Line(float x1, float y1, float x2, float y2) =>
        rl.Raylib.DrawLine((int)x1, (int)y1, (int)x2, (int)y2, currentColor);

    static void Text(float x, float y, string txt, int centerX = FALSE, int centerY = FALSE)
    {
        int fontSize = 10;
        int tx = (int)x;
        int ty = (int)y;
        if (centerX == TRUE) tx -= rl.Raylib.MeasureText(txt, fontSize) / 2;
        if (centerY == TRUE) ty -= fontSize / 2;
        rl.Raylib.DrawText(txt, tx, ty, fontSize, currentColor);
    }

    static void Color(int r, int g, int b) =>
            currentColor = new rl.Color(r, g, b, 255);

    static float Min(float a, float b) => MathF.Min(a, b);
    static int MouseX() => rl.Raylib.GetMouseX();
    static int MouseY() => rl.Raylib.GetMouseY();
    static int MouseDown1() => rl.Raylib.IsMouseButtonDown(rl.MouseButton.Left) ? TRUE : FALSE;
    static int MouseHit1() => rl.Raylib.IsMouseButtonPressed(rl.MouseButton.Left) ? TRUE : FALSE;
}