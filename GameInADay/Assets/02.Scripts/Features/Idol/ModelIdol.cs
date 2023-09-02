using System;
using System.Collections.Generic;
using UnityEngine;

public partial class ModelIdol {
    public static IdolStat GenerateIdol(string auditionType) {
        var selected = Get(GameRandom.IdolIndexFromAudition(auditionType));

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