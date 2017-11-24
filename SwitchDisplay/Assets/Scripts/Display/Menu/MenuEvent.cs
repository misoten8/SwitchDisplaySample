using TextFx;

/// <summary>
/// MenuEvent クラス
/// 製作者：実川
/// </summary>
public class MenuEvent : UIBase 
{
	private TextFxUGUI _text;

	public override void OnAwake(ISceneCache cache, IEvents displayEvents)
	{
		base.OnAwake(cache, displayEvents);
		var events = displayEvents as MenuEvents;
		_text = uiObject as TextFxUGUI;

		if (events != null)
		{
			events.onCallEvent += () => _text.AnimationManager.OnStart();
		}
	}
}