using UnityEngine;
using TextFx;

/// <summary>
/// MenuEvent クラス
/// 製作者：実川
/// </summary>
public class MenuEvent : UIBase 
{
	private TextFxUGUI _textFx;

	public override void OnAwake(ISceneCache cache, IEvents displayEvents)
	{
		base.OnAwake(cache, displayEvents);
		var events = displayEvents as MenuEvents;
		_textFx = uiObject as TextFxUGUI;

		if (events != null)
		{
			events.onCallEvent += () => _textFx.AnimationManager.PlayAnimation();
		}
	}
}