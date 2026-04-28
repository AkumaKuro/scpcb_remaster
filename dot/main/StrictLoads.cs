using rl = Raylib_cs;

partial class Game
{
    static rl.Image LoadImage_Strict(String file) {
        if (FileType(file) != FileTypeResult.FILE_EXISTS) {
            RuntimeError ("Image " + Chr(34) + file + Chr(34) + " missing. ");
        }
        rl.Image tmp = LoadImage(file);
        return tmp;
    }

    static void AutoReleaseSounds() {
        //Sound snd;
        foreach (Sound snd in Sound.each()) {
            int tryRelease = True;
            for (int i = 0; i < 32; i++) {
                if (snd.channels[i] != 0) {
                    if (ChannelPlaying(snd.channels[i])) {
                        tryRelease = False;
                        snd.releaseTime = MilliSecs2()+5000;
                        break;
                    }
                }
            }
            if (tryRelease) {
                if (snd.releaseTime < MilliSecs2()) {
                    if (snd.internalHandle != 0) {
                        FreeSound (snd.internalHandle);
                        snd.internalHandle = 0;
                    }
                }
            }
        }
    }
}