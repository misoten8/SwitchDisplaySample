using UnityEngine;
using TMPro;
using TextFx;

public class LogoAnimText : UIBase
{
	[SerializeField]
	private TextFxUGUI _text;

	private TitleSceneCache _cache;


	public override void OnAwake (ISceneCache cache)
	{
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
