using System.Collections.Generic;
using UnityEngine;

public struct HumanStat {
    public int Current;
    public int Poten;

    public HumanStat(ModelIdol model) {
        Current = Random.Range(model.CurMin, model.CurMax);
        Poten = Random.Range(model.PotenMin, model.PotenMax);
    }

    public override string ToString() {
        return $"{Current}/{Poten}";
    }
}

public struct IdolStat {
    public string Name;
    public string Grade;
    public Dictionary<IdolStatType, HumanStat> Stats;

    public override string ToString() {
        return $"{Name} - {Grade} : {Stats}";
    }
}