using System.Linq;

/// <summary>
/// LogoDisplay クラス
/// 製作者：実川
/// </summary>
public class LogoDisplay : DisplayBase
{
	public override void OnAwake(ISceneCache cache)
	{
		base.OnAwake (cache);
	}

	void Update()
	{
		if (!isCallOnAwake)
			return;
		// 描画処理
		uiList.Where (e => e.IsDrawUpdate ()).ToList().ForEach(e => e.OnDrawUpdate());
	}
}