using rl = Raylib_cs;
using System.IO;
partial class Game
{
    enum FileTypeResult
    {
        FILE_EXISTS,
        FILE_NOT_FOUND,
        FILE_IS_DIR
    }
    
    static FileTypeResult FileType(string filename)
    {
        if (Directory.Exists(filename))
        {
            return FileTypeResult.FILE_IS_DIR;
        } else if (File.Exists(filename))
        {
            return FileTypeResult.FILE_EXISTS;
        } else
        {
            return FileTypeResult.FILE_NOT_FOUND;
        }
    }

    static rl.Image LoadImage(string path)
    {
        return rl.Raylib.LoadImage(path);
    }
}