using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public partial class ModelResearch : CSVFile<ModelResearch> { 
	
	public string ResearchName { get; set; }
	
	public int RequirePoint { get; set; }
	
	public float PreferTeenage { get; set; }
	
	public float PreferYouth { get; set; }
	
	public float PreferAdult { get; set; }
	
	public float PreferMan { get; set; }
	
	public float PreferWoman { get; set; }
	
	public float PreferLight { get; set; }
	
	public float PreferManiac { get; set; }
	
	public float IncreaseCDPriceRate { get; set; }
	
	public int IncentiveProfit { get; set; }
	
	public float GreatSuccessFanIncreaseRate { get; set; }
	
	public float SuccessFanIncreaseRate { get; set; }
	
	public float FailureFanIncreaseRate { get; set; }
	
	public float BigFailureFanIncreaseRate { get; set; }
	
	public float GreatSuccessProb { get; set; }
	
	public float SuccessProb { get; set; }
	
	public float FailureProb { get; set; }
	
	public float BigFailureProb { get; set; }
	
	public static void Load()
	{
		TextAsset dataset = Resources.Load<TextAsset>(@"CSVs/Research");
		string[] dataLines = dataset.text.Split("\n");
		for (int i = 2; i < dataLines.Length; i++)
		{
			dataLines[i].Trim();
			var data = dataLines[i].Split(',');
			if (string.IsNullOrEmpty(data[0]))
			{
				break;
			}
			ModelResearch Tmp = new();
			int idx = 0;
			Tmp.ID = int.Parse(data[idx++]);
			Tmp.ResearchName = data[idx++];
			Tmp.RequirePoint = int.Parse(data[idx++]);
			Tmp.PreferTeenage = float.Parse(data[idx++]);
			Tmp.PreferYouth = float.Parse(data[idx++]);
			Tmp.PreferAdult = float.Parse(data[idx++]);
			Tmp.PreferMan = float.Parse(data[idx++]);
			Tmp.PreferWoman = float.Parse(data[idx++]);
			Tmp.PreferLight = float.Parse(data[idx++]);
			Tmp.PreferManiac = float.Parse(data[idx++]);
			Tmp.IncreaseCDPriceRate = float.Parse(data[idx++]);
			Tmp.IncentiveProfit = int.Parse(data[idx++]);
			Tmp.GreatSuccessFanIncreaseRate = float.Parse(data[idx++]);
			Tmp.SuccessFanIncreaseRate = float.Parse(data[idx++]);
			Tmp.FailureFanIncreaseRate = float.Parse(data[idx++]);
			Tmp.BigFailureFanIncreaseRate = float.Parse(data[idx++]);
			Tmp.GreatSuccessProb = float.Parse(data[idx++]);
			Tmp.SuccessProb = float.Parse(data[idx++]);
			Tmp.FailureProb = float.Parse(data[idx++]);
			Tmp.BigFailureProb = float.Parse(data[idx++]);
			Tmp.Add(Tmp);
		}
	}

}
