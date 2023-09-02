using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public partial class ModelSample : CSVFile<ModelSample> { 
	
	public bool Dir0 { get; set; }
	
	public bool Dir1 { get; set; }
	
	public bool Dir2 { get; set; }
	
	public bool Dir3 { get; set; }
	
	public static void Load()
	{
		TextAsset dataset = Resources.Load<TextAsset>(@"CSVs/Sample");
		string[] dataLines = dataset.text.Split("\n");
		for (int i = 2; i < dataLines.Length; i++)
		{
			dataLines[i].Trim();
			var data = dataLines[i].Split(',');
			if (string.IsNullOrEmpty(data[0]))
			{
				break;
			}
			ModelSample Tmp = new();
			int idx = 0;
			Tmp.ID = int.Parse(data[idx++]);
			Tmp.Dir0 = bool.Parse(data[idx++]);
			Tmp.Dir1 = bool.Parse(data[idx++]);
			Tmp.Dir2 = bool.Parse(data[idx++]);
			Tmp.Dir3 = bool.Parse(data[idx++]);
			Tmp.Add(Tmp);
		}
	}

}
