using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

/// <summary>
/// DisplayManager クラス
/// 製作者：実川
/// </summary>
public class DisplayManager : MonoBehaviour
{
	public enum DisplayType
	{
		Logo,
		Menu
	}

	private static readonly Dictionary<DisplayType, string> _DISPLAY_MAP = 
		new Dictionary<DisplayType, string>
	{
		{ DisplayType.Logo, "LogoDisplay" },
		{ DisplayType.Menu, "MenuDisplay" }
	};

	public static void SwitchDisplay(DisplayType type)
	{
		// シーン遷移
		
	}
}
