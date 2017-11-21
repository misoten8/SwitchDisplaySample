using UnityEngine;
using TMPro;

/// <summary>
/// メニュータイマー
/// </summary>
public class MenuTimer : UIBase
{
	[SerializeField]
	private TextMeshProUGUI _text;

	private TitleSceneCache _cache;
	private float _drawValue = 0.0f;

	public override void OnAwake (ISceneCache cache)
	{
		_cache = cache as TitleSceneCache;
	}

	public override bool IsDrawUpdate ()
	{
		//if (_cache == null)
		//	return false;
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
