using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Define
{
    public const int MaxAuditionCount = 5;
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
        Drop,
        PointerEnter,
        PointerExit
    }

    public static readonly int RoomCount = 5;
}
