using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TextFx;

/// <summary>
/// MenuEvent クラス
/// 製作者：実川
/// </summary>
public class MenuEvent : UIBase 
{
	[SerializeField]
	private TextFxUGUI _text;

	public override void OnAwake(ISceneCache cache, IEvents displayEvents)
	{
		var events = displayEvents as MenuEvents;

		if (events != null)
		{
			events.onCallEvent += () => _text.AnimationManager.OnStart();
		}
	}
}