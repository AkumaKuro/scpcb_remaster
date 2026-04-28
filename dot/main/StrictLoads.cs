using rl = Raylib_cs;

partial class Game
{

    static int PlaySound_Strict(int sndHandle) {
        Sound snd = Object.Sound(sndHandle);
        if (snd != Null) {
            int shouldPlay = True;
            for (int i = 0; i < 32; i++) {
                if (snd.channels[i] != 0) {
                    if (!ChannelPlaying(snd.channels[i])) {
                        if (snd.internalHandle = 0) {
                            if (FileType(snd.name) != 1) {
                                CreateConsoleMsg("Sound " + Chr(34) + snd.name + Chr(34) + " not found.");
                                if (ConsoleOpening) {
                                    ConsoleOpen = True;
                                }
                            } else {
                                if (EnableSFXRelease) snd.internalHandle = LoadSound(snd.name);
                            }
                            if (snd.internalHandle == 0) {
                                CreateConsoleMsg("Failed to load Sound: " + Chr(34) + snd.name + Chr(34));
                                if (ConsoleOpening) {
                                    ConsoleOpen = True;
                                }
                            }
                        }
                        if (ConsoleFlush) {
                            snd.channels[i] = PlaySound(ConsoleFlushSnd);
                        } else {
                            snd.channels[i] = PlaySound(snd.internalHandle);
                        }
                        ChannelVolume (snd.channels[i],SFXVolume);
                        snd.releaseTime = MilliSecs2()+5000; //release after 5 seconds
                        return snd.channels[i];
                    }
                } else {
                    if (snd.internalHandle = 0) {
                        if (FileType(snd.name) != 1) {
                            CreateConsoleMsg("Sound " + Chr(34) + snd.name + Chr(34) + " not found.");
                            if (ConsoleOpening) {
                                ConsoleOpen = True;
                            }
                        } else {
                            if (EnableSFXRelease) snd.internalHandle = LoadSound(snd.name);
                        }
                            
                        if (snd.internalHandle == 0) {
                            CreateConsoleMsg("Failed to load Sound: " + Chr(34) + snd.name + Chr(34));
                            if (ConsoleOpening) {
                                ConsoleOpen = True;
                            }
                        }
                    }
                    if (ConsoleFlushSnd) {
                        snd.channels[i] = PlaySound(ConsoleFlushSnd);
                    } else {
                        snd.channels[i] = PlaySound(snd.internalHandle);
                    }
                    ChannelVolume (snd.channels[i],SFXVolume);
                    snd.releaseTime = MilliSecs2()+5000; //release after 5 seconds
                    return snd.channels[i];
                }
            }
        }
        
        return 0;
    }

    static int LoadSound_Strict(string file) {
        Sound snd = new Sound();
        snd.name = file;
        snd.internalHandle = 0;
        snd.releaseTime = 0;
        if (!EnableSFXRelease) {
            if (snd.internalHandle == 0) { 
                snd.internalHandle = LoadSound(snd.name);
            }
        }
        
        return Handle(snd);
    }

    static void FreeSound_Strict(int sndHandle) {
        Sound snd = Object.Sound(sndHandle);
        if (snd != Null) {
            if (snd.internalHandle != 0) {
                FreeSound (snd.internalHandle);
                snd.internalHandle = 0;
            }
            Delete (snd);
        }
    }

    static rl.Image LoadImage_Strict(string file) {
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