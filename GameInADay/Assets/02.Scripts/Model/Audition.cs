using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public partial class ModelAudition : CSVFile<ModelAudition> { 
	
	public string AuditionType { get; set; }
	
	public float NormalAppearProb { get; set; }
	
	public float SilverAppearProb { get; set; }
	
	public float GoldAppearProb { get; set; }
	
	public float PlatinumAppearProb { get; set; }
	
	public int GuaranteedSilver { get; set; }
	
	public int GuaranteedGold { get; set; }
	
	public int Money { get; set; }
	
	public static void Load()
	{
		TextAsset dataset = Resources.Load<TextAsset>(@"CSVs/Audition");
		string[] dataLines = dataset.text.Split("\n");
		for (int i = 2; i < dataLines.Length; i++)
		{
			dataLines[i].Trim();
			var data = dataLines[i].Split(',');
			if (string.IsNullOrEmpty(data[0]))
			{
				break;
			}
			ModelAudition Tmp = new();
			int idx = 0;
			Tmp.ID = int.Parse(data[idx++]);
			Tmp.AuditionType = data[idx++];
			Tmp.NormalAppearProb = float.Parse(data[idx++]);
			Tmp.SilverAppearProb = float.Parse(data[idx++]);
			Tmp.GoldAppearProb = float.Parse(data[idx++]);
			Tmp.PlatinumAppearProb = float.Parse(data[idx++]);
			Tmp.GuaranteedSilver = int.Parse(data[idx++]);
			Tmp.GuaranteedGold = int.Parse(data[idx++]);
			Tmp.Money = int.Parse(data[idx++]);
			Tmp.Add(Tmp);
		}
	}

}
