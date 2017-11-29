using TextFx;

/// <summary>
/// (サンプル)イベント呼び出しによって動く、テキストUIクラス
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