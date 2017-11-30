using TextFx;

/// <summary>
/// (サンプル)イベント呼び出しによって動く、テキストUIクラス
/// </summary>
public class LogoAnimText : UIBase
{
	private TextFxUGUI _text;
	private TitleSceneCache _cache;

	public override void OnAwake (ISceneCache cache, IEvents displayEvents)
	{
		base.OnAwake(cache, displayEvents);
		_text = uiObject as TextFxUGUI;
		_cache = cache as TitleSceneCache;
	}

	public override bool IsDrawUpdate ()
	{
		return false;
	}

	public override void OnDrawUpdate ()
	{
		
	}
}
