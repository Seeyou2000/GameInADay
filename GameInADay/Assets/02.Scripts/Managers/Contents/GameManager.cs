using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{
    public List<IdolStat> CurrentIdols;
    public List<IdolStat> TmpIdols;
    public void Init()
    {
        CurrentIdols = new List<IdolStat>();
        TmpIdols = new List<IdolStat>();
    }
}
