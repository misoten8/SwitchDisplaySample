using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// DisplayTest クラス
/// 製作者：実川
/// </summary>
public class DisplayTest : MonoBehaviour 
{
	private void OnGUI()
	{
		if(GUI.Button(new Rect(new Vector2(200,0), new Vector2(400, 100)), "ディスプレイ切り替え"))
		{
			switch (DisplayManager.CurrentDisplayType)
			{
				case DisplayManager.DisplayType.Logo:
					DisplayManager.SwitchDisplay(DisplayManager.DisplayType.Menu);
					break;
				case DisplayManager.DisplayType.Menu:
					DisplayManager.SwitchDisplay(DisplayManager.DisplayType.Logo);
					break;
				default:
					break;
			}
		}
	}
}