using UnityEngine;

/// <summary>
/// ディスプレイ単体駆動補助クラス
/// ディスプレイシーン単体でのテストはこのクラスを使用してください
/// 製作者：実川
/// </summary>
public class DisplayDebugger : MonoBehaviour 
{
	/// <summary>
	/// 呼び出し対象ディスプレイ
	/// </summary>
	[SerializeField]
	private DisplayBase _display;

	/// <summary>
	/// 引き渡し用シーンキャッシュ
	/// </summary>
	[SerializeField]
	private SceneCacheBase _sceneCache;

	void Start () 
	{
		// ディスプレイ初期化処理呼び出し
		_display.OnAwake(_sceneCache);
	}
}