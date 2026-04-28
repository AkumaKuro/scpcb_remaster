using Microsoft.Win32;
using Raylib_cs;
using rl = Raylib_cs;

partial class Game
{
    enum GraphicsMode
    {
        AUTO,
        FULLSCREEN,
        WINDOWED,
        SCALED_WINDOWED
    }
    static void Graphics(int width, int height, int color_depth, GraphicsMode mode)
    {
        String title = GameStateController.title;
        rl.Raylib.InitWindow(width, height, title);
        rl.Raylib.BeginDrawing();
    }

    static void ClsColor(int r, int g, int b)
    {
        rl.Color new_col = new rl.Color(r, g, b);
        GameStateController.bg_color = new_col;
    }

    static void Cls()
    {
        rl.Raylib.ClearBackground(GameStateController.bg_color);
    }

    static void Flip(int vsync = 0)
    {
        rl.Raylib.EndDrawing();
        rl.Raylib.BeginDrawing();
    }

    static void End()
    {
        rl.Raylib.EndDrawing();
        rl.Raylib.CloseWindow();
        Environment.Exit(0);
    }
}