using UnityEngine;
using TMPro;

/// <summary>
/// (サンプル)メニュータイマー
/// </summary>
public class MenuTimer : UIBase
{
	private TextMeshProUGUI _text;
	private TitleSceneCache _cache;
	private float _drawValue = 0.0f;

	public override void OnAwake (ISceneCache cache, IEvents displayEvents)
	{
		base.OnAwake(cache, displayEvents);
		_text = uiObject as TextMeshProUGUI;
		_cache = cache as TitleSceneCache;
	}

	public override bool IsDrawUpdate ()
	{
		if (_drawValue != _cache.titleTimer.ElapsedTime) 
		{
			_drawValue = _cache.titleTimer.ElapsedTime;
			return true;
		}
		return false;
	}

	public override void OnDrawUpdate ()
	{
		_text.text = "TIME:" + _drawValue.ToString("F1");
	}
}
