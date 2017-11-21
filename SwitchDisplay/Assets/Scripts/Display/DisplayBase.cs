using UnityEngine;
using System;
using System.Collections.Generic;

/// <summary>
/// ディスプレイ基底クラス
/// 製作者：実川
/// </summary>
public abstract class DisplayBase : MonoBehaviour, IDisplay
{
	/// <summary>
	/// ディスプレイ切り替えアニメーションが再生中かどうか
	/// </summary>
	public bool IsSwitchAnimPlaying
	{
		get { return isSwitchAnimPlaying; }
	}

	/// <summary>
	/// ディスプレイイベントの定義インターフェイス
	/// </summary>
	public virtual IEvents DisplayEvents
	{
		get { return null; }
	}

	/// <summary>
	/// ディスプレイ切り替えアニメーションが再生中かどうか
	/// </summary>
	protected bool isSwitchAnimPlaying;

	/// <summary>
	/// OnAwake が呼ばれたかどうか
	/// </summary>
	protected bool isCallOnAwake = false;

	/// <summary>
	/// UIオブジェクトのリスト
	/// </summary>
	[SerializeField]
	protected List<UIBase> uiList = new List<UIBase>();

	/// <summary>
	/// ディスプレイ生成時に呼ばれるイベント
	/// </summary>
	public virtual void OnAwake(ISceneCache cache) 
	{ 
		// キャッシュを各UIオブジェクトに渡す(イベントクラスは渡さない)
		uiList.ForEach(e => e.OnAwake(cache, null));
		isCallOnAwake = true;
	}

	/// <summary>
	/// ディスプレイ遷移開始時に呼ばれるイベント
	/// 使用例：UIの開始アニメーション呼び出し
	/// </summary>
	public virtual void OnSwitchFadeIn() { }

	/// <summary>
	/// ディスプレイ遷移開始時に呼ばれるイベント
	/// 使用例：UIの終了アニメーション呼び出し
	/// </summary>
	public virtual void OnSwitchFadeOut() { }

	/// <summary>
	/// ディスプレイ消去時に呼ばれるイベント
	/// </summary>
	public virtual void OnDelete() { }
}