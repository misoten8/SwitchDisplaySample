using System.Linq;

/// <summary>
/// (サンプル)ロゴディスプレイクラス
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