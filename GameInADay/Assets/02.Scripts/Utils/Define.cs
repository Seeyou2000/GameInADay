using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Define
{
    public enum Scene
    {
        Unknown,
        Login,
        Lobby,
        Game,
    }

    public enum Sound
    {
        Bgm,
        Effect,
        MaxCount,
    }

    public enum Stats
    {
        Cute,Cool,Sexy,Beauty,Vocal,Dance,Humor,Intelligence
    }

    public enum UIEvent
    {
        Click,
        Drag,
    }
}
