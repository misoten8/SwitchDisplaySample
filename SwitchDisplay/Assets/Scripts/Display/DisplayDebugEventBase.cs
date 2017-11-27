using UnityEngine;

/// <summary>
/// DisplayDebugEventBase クラス
/// 製作者：実川
/// </summary>
public abstract class DisplayDebugEventBase : MonoBehaviour 
{
	/// <summary>
	/// デバッグ用イベントクラス
	/// </summary>
	public DisplayDebugger.DebugEvents DebugEvents
	{
		get { return debugEvents; }
	}

	/// <summary>
	/// デバッグ用イベントクラス
	/// </summary>
	protected DisplayDebugger.DebugEvents debugEvents = new DisplayDebugger.DebugEvents();

	/// <summary>
	/// 初期化時実行イベント
	/// </summary>
	public abstract void OnAwake();
}