using System;
using System.Linq;

/// <summary>
/// MenuDisplay クラス
/// 製作者：実川
/// </summary>
public class MenuDisplay : DisplayBase
{
	public override IEvents DisplayEvents
	{
		get { return _events; }
	}

	/// <summary>
	/// UIオブジェクト呼び出しイベントクラス
	/// </summary>
	public MenuEvents _events = new MenuEvents();

	public override void OnAwake(ISceneCache cache)
	{
		gameObject.SetActive(true);
		// シーンキャッシュとイベントクラスを各UIオブジェクトに渡す
		uiList.ForEach(e => e.OnAwake(cache, _events));
		isCallOnAwake = true;
		switchAnim.OnAwake (uiList);
	}

	void Update()
	{
		if (!isCallOnAwake)
			return;
		// 描画処理
		uiList.Where (e => e.IsDrawUpdate ()).ToList().ForEach(e => e.OnDrawUpdate());
	}
}