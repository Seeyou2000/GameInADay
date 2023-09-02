using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public partial class ModelStaffInfo : CSVFile<ModelStaffInfo> { 
	
	public string Staff { get; set; }
	
	public bool IsFire { get; set; }
	
	public bool IsPay { get; set; }
	
	public static void Load()
	{
		TextAsset dataset = Resources.Load<TextAsset>(@"CSVs/StaffInfo");
		string[] dataLines = dataset.text.Split("\n");
		for (int i = 2; i < dataLines.Length; i++)
		{
			dataLines[i].Trim();
			var data = dataLines[i].Split(',');
			if (string.IsNullOrEmpty(data[0]))
			{
				break;
			}
			ModelStaffInfo Tmp = new();
			int idx = 0;
			Tmp.ID = int.Parse(data[idx++]);
			Tmp.Staff = data[idx++];
			Tmp.IsFire = bool.Parse(data[idx++]);
			Tmp.IsPay = bool.Parse(data[idx++]);
			Tmp.Add(Tmp);
		}
	}

}
