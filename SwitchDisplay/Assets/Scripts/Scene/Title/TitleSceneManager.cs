﻿using UnityEngine;

/// <summary>
/// (サンプル)タイトルシーン管理クラス
/// </summary>
[RequireComponent(typeof(TitleSceneCache))]
public class TitleSceneManager : SceneBase<TitleSceneManager>
{
	/// <summary>
	/// 外部シーンが利用できるデータキャッシュ
	/// </summary>
	public override ISceneCache SceneCache
	{
		get { return _sceneCache; }
	}

	[SerializeField]
	private TitleSceneCache _sceneCache;

	/// <summary>
	/// シーン切り替え
	/// </summary>
	public override void Switch (SceneType nextScene)
	{
		if (duringTransScene)
			return;

		StartCoroutine(SwitchAsync(nextScene));
	}

	/// <summary>
	/// 派生クラスのインスタンスを取得
	/// </summary>
	protected override TitleSceneManager GetOverrideInstance()
	{
		return this;
	}

	void Start ()
	{
		DisplayManager.Switch(firstUsingDisplay);
	}

	// デバッグ用
#if UNITY_EDITOR
	private void OnGUI()
	{
		if(GUI.Button(new Rect(new Vector2(200,0), new Vector2(400, 100)), "ディスプレイ切り替え"))
		{
			switch (DisplayManager.CurrentDisplayType)
			{
			case DisplayManager.DisplayType.Logo:
				DisplayManager.Switch(DisplayManager.DisplayType.Menu);
				break;
			case DisplayManager.DisplayType.Menu:
				DisplayManager.Switch(DisplayManager.DisplayType.Logo);
				break;
			default:
				break;
			}
		}

		if (GUI.Button (new Rect (new Vector2 (200, 150), new Vector2 (400, 100)), "シーン切り替え")) 
		{
			Switch (SceneType.Game);
		}
	}
	#endif
}
