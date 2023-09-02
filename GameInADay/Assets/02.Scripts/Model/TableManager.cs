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
			ModelIdol.Load();
			IsLoaded = true;
		}
	}
}
