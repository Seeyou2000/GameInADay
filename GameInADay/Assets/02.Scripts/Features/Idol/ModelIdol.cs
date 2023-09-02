using System;
using System.Collections.Generic;
using UnityEngine;

public partial class ModelIdol {
    public static IdolStat GenerateIdol() {
        // TODO: 확률 엑셀에 기입
        var selected = Get(UnityEngine.Random.Range(1, GetSize() + 1));

        var stats = new Dictionary<IdolStatType, HumanStat>();
        foreach (IdolStatType s in Enum.GetValues(typeof(IdolStatType))) {
            stats[s] = new HumanStat(selected);
        }

        return new IdolStat {
            Name = IdolNameGenerator.Generate(),
            Grade = selected.Grade,
            Stats = stats,
        };
    }
}