using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public partial class ModelStaffGrade : CSVFile<ModelStaffGrade> { 
	
	public string Grade { get; set; }
	
	/// <summary>
	/// 모든 직업이 지불함
	/// </summary>
	public int Pay { get; set; }
	
	
	/// <summary>
	/// 스타일리스트, 의사 제외 전부 사용
	/// </summary>
	public int ResearchPoint { get; set; }
	
	/// <summary>
	/// 스타일리스트만 사용
	/// </summary>
	public int IncreaseAbility { get; set; }
	
	/// <summary>
	/// 의사만 사용
	/// </summary>
	public int RecoverStamina { get; set; }
	
	
	/// <summary>
	/// 등급에 따라 ResearchPoint가 갱신되는 시간
	/// </summary>
	public int UpdateTime { get; set; }
	
	public static void Load()
	{
		TextAsset dataset = Resources.Load<TextAsset>(@"CSVs/StaffGrade");
		string[] dataLines = dataset.text.Split("\n");
		for (int i = 2; i < dataLines.Length; i++)
		{
			dataLines[i].Trim();
			var data = dataLines[i].Split(',');
			if (string.IsNullOrEmpty(data[0]))
			{
				break;
			}
			ModelStaffGrade Tmp = new();
			int idx = 0;
			Tmp.ID = int.Parse(data[idx++]);
			Tmp.Grade = data[idx++];
			Tmp.Pay = int.Parse(data[idx++]);
			Tmp.ResearchPoint = int.Parse(data[idx++]);
			Tmp.IncreaseAbility = int.Parse(data[idx++]);
			Tmp.RecoverStamina = int.Parse(data[idx++]);
			Tmp.UpdateTime = int.Parse(data[idx++]);
			Tmp.Add(Tmp);
		}
	}

}
