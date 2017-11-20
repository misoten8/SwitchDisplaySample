/// <summary>
/// DisplayBase インターフェイス
/// 製作者：実川
/// </summary>
public interface IDisplay
{
	/// <summary>
	/// ディスプレイ切り替えアニメーションが再生中かどうか
	/// </summary>
	bool IsSwitchAnimPlaying { get; }

	/// <summary>
	/// ディスプレイ生成時に呼ばれるイベント
	/// </summary>
	void OnAwake(ISceneCache cache);

	/// <summary>
	/// ディスプレイ遷移開始時に呼ばれるイベント
	/// 使用例：UIの開始アニメーション呼び出し
	/// </summary>
	void OnSwitchFadeIn();

	/// <summary>
	/// ディスプレイ遷移開始時に呼ばれるイベント
	/// 使用例：UIの終了アニメーション呼び出し
	/// </summary>
	void OnSwitchFadeOut();

	/// <summary>
	/// ディスプレイ消去時に呼ばれるイベント
	/// </summary>
	void OnDelete();
}
