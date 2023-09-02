using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public partial class ModelSongAppeal : CSVFile<ModelSongAppeal> { 
	
	public string PublicType { get; set; }
	
	public float AppealRate { get; set; }
	
	public static void Load()
	{
		TextAsset dataset = Resources.Load<TextAsset>(@"CSVs/SongAppeal");
		string[] dataLines = dataset.text.Split("\n");
		for (int i = 2; i < dataLines.Length; i++)
		{
			dataLines[i].Trim();
			var data = dataLines[i].Split(',');
			if (string.IsNullOrEmpty(data[0]))
			{
				break;
			}
			ModelSongAppeal Tmp = new();
			int idx = 0;
			Tmp.ID = int.Parse(data[idx++]);
			Tmp.PublicType = data[idx++];
			Tmp.AppealRate = float.Parse(data[idx++]);
			Tmp.Add(Tmp);
		}
	}

}
