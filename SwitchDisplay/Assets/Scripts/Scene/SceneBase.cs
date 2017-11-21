using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// シーン基底クラス
/// 製作者：実川洋孝
/// </summary>
public class SceneBase<T> : MonoBehaviour where T : SceneBase<T>
{
	/// <summary>
	/// メインシーンの種類
	/// </summary>
	public enum SceneType
	{
		Title,
		Game
	}

	/// <summary>
	/// メインシーンタイプとシーンの紐付けマップ
	/// </summary>
	protected static readonly Dictionary<SceneType, string> SCENE_MAP = 
		new Dictionary<SceneType, string>
	{
		{ SceneType.Title, "Title" },
		{ SceneType.Game, "Game" }
	};

	/// <summary>
	/// シーン切り替え時実行イベント
	/// </summary>
	public event Action<T> onSwitchScene;

	/// <summary>
	/// シーン生成時に最初に表示されるディスプレイ
	/// </summary>
	[SerializeField]
	protected DisplayManager.DisplayType firstUsingDisplay;

	/// <summary>
	/// シーン切り替え
	/// </summary>
	public virtual void Switch(SceneType nextScene) { }

	/// <summary>
	/// シーン切り替え時実行イベント呼び出し
	/// </summary>
	protected void OnSwitchScene(T overrideThis)
	{
		onSwitchScene?.Invoke(overrideThis);
	}
}
