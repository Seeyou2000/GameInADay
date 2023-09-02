using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public partial class TableManager
{
	static bool IsLoaded = false;
	public static void Load()
	{
		if (!IsLoaded)
		{
			ModelAgencyFacilities.Load();
			ModelAudition.Load();
			ModelIdol.Load();
			ModelResearch.Load();
			ModelSongAppeal.Load();
			ModelStaffGrade.Load();
			ModelStaffInfo.Load();
			IsLoaded = true;
		}
	}

	public void Init()
	{
		Load();
	}
}
