using UnityEngine;

/// <summary>
/// ディスプレイ基底クラス
/// 製作者：実川
/// </summary>
public class DisplayBase : MonoBehaviour, IDisplay
{
	public bool IsSwitchAnimPlaying
	{
		get { return isSwitchAnimPlaying; }
	}

	/// <summary>
	/// ディスプレイ切り替えアニメーションが再生中かどうか
	/// </summary>
	protected bool isSwitchAnimPlaying;

	/// <summary>
	/// ディスプレイ生成時に呼ばれるイベント
	/// </summary>
	public virtual void OnAwake(ISceneCache cache) { }

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