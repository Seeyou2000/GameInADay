using UnityEngine;

public static class GameRandom
{
    
    public static int IdolIndexFromAudition(string auditionType)
    {
        var audition = ModelAudition.GetByAuditionType(auditionType);
        var rand = Random.Range(0.0f, 100.0f);
        var idolIndex = 1;

        if (rand < audition.PlatinumAppearProb)
        {
            idolIndex = 4;
            Debug.Assert(ModelIdol.Get(idolIndex).Grade == "platinum");
        }
        else if (rand < audition.GoldAppearProb)
        {
            idolIndex = 3;
            Debug.Assert(ModelIdol.Get(idolIndex).Grade == "gold");
        }
        else if (rand < audition.SilverAppearProb)
        {
            idolIndex = 2;
            Debug.Assert(ModelIdol.Get(idolIndex).Grade == "silver");
        }
        else
        {
            Debug.Assert(ModelIdol.Get(idolIndex).Grade == "normal");
        }

        return idolIndex;
    }

    public static Staff Staff()
    {
        var grade = ModelStaffGrade.GetRandom();
        var type = ModelStaffInfo.GetRandom(2);
        return new Staff {
            Name = IdolNameGenerator.Generate(),
            PayPerWeek = grade.Pay,
            GradeId = grade.ID,
            Type = type.Staff,
        };
    }
}