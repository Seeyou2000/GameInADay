using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public partial class ModelAgencyFacilities : CSVFile<ModelAgencyFacilities> { 
	
	public string FacilitiesName { get; set; }
	
	public int RoomSpace { get; set; }
	
	public int Money { get; set; }
	
	public int RentalCost { get; set; }
	
	public static void Load()
	{
		TextAsset dataset = Resources.Load<TextAsset>(@"CSVs/AgencyFacilities");
		string[] dataLines = dataset.text.Split("\n");
		for (int i = 2; i < dataLines.Length; i++)
		{
			dataLines[i].Trim();
			var data = dataLines[i].Split(',');
			if (string.IsNullOrEmpty(data[0]))
			{
				break;
			}
			ModelAgencyFacilities Tmp = new();
			int idx = 0;
			Tmp.ID = int.Parse(data[idx++]);
			Tmp.FacilitiesName = data[idx++];
			Tmp.RoomSpace = int.Parse(data[idx++]);
			Tmp.Money = int.Parse(data[idx++]);
			Tmp.RentalCost = int.Parse(data[idx++]);
			Tmp.Add(Tmp);
		}
	}

}
