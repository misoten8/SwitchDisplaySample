using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// TitleScene クラス
/// 製作者：実川
/// </summary>
public class TitleScene : MonoBehaviour
{
	[SerializeField]
	DisplayManager.DisplayType _firstUsingDisplay;

	void Start ()
	{
		DisplayManager.SwitchDisplay(_firstUsingDisplay);
	}
	
	void Update ()
	{
		
	}
}
