using UnityEngine;

/// <summary>
/// GameSceneManager クラス
/// 製作者：実川
/// </summary>
[RequireComponent(typeof(GameSceneCache))]
public class GameSceneManager : SceneBase<GameSceneManager>
{
	/// <summary>
	/// 外部シーンが利用できるデータキャッシュ
	/// </summary>
	public override ISceneCache SceneCache
	{
		get { return _sceneCache; }
	}

	[SerializeField]
	GameSceneCache _sceneCache;

	void Start () 
	{
		DisplayManager.Switch(firstUsingDisplay);
	}

	/// <summary>
	/// シーン切り替え
	/// </summary>
	public override void Switch(SceneType nextScene)
	{
		if (duringTransScene)
			return;

		StartCoroutine(SwitchAsync(nextScene));
	}

	/// <summary>
	/// 派生クラスのインスタンスを取得
	/// </summary>
	protected override GameSceneManager GetOverrideInstance()
	{
		return this;
	}

	// デバッグ用
#if UNITY_EDITOR
	private void OnGUI()
	{
		if (GUI.Button(new Rect(new Vector2(200, 0), new Vector2(400, 100)), "ディスプレイ切り替え"))
		{
			switch (DisplayManager.CurrentDisplayType)
			{
				case DisplayManager.DisplayType.None:
					DisplayManager.Switch(DisplayManager.DisplayType.None);
					break;
				default:
					break;
			}
		}

		if (GUI.Button(new Rect(new Vector2(200, 150), new Vector2(400, 100)), "シーン切り替え"))
		{
			Switch(SceneType.Title);
		}
	}
#endif
}