using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public partial class ModelIdol : CSVFile<ModelIdol> { 
	
	public string Grade { get; set; }
	
	public int Min { get; set; }
	
	public int Max { get; set; }
	
	public static void Load()
	{
		TextAsset dataset = Resources.Load<TextAsset>(@"CSVs/Idol");
		string[] dataLines = dataset.text.Split("\n");
		for (int i = 2; i < dataLines.Length; i++)
		{
			dataLines[i].Trim();
			var data = dataLines[i].Split(',');
			if (string.IsNullOrEmpty(data[0]))
			{
				break;
			}
			ModelIdol Tmp = new();
			int idx = 0;
			Tmp.ID = int.Parse(data[idx++]);
			Tmp.Grade = data[idx++];
			Tmp.Min = int.Parse(data[idx++]);
			Tmp.Max = int.Parse(data[idx++]);
			Tmp.Add(Tmp);
		}
	}

}
