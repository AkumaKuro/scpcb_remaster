using rl = Raylib_cs;

partial class Game
{
    static int KeyHit(rl.KeyboardKey key)
    {
        int hit = rl.Raylib.IsKeyDown(key);
        return hit;
    }
}