using UnityEngine;
using UnityEngine.UI;
using TMPro;
using TextFx;

/// <summary>
/// UIオブジェクト基底クラス
/// 製作者：実川
/// </summary>
public class UIBase : MonoBehaviour
{
	/// <summary>
	/// ディスプレイ生成時に呼ばれるイベント
	/// </summary>
	virtual public void OnAwake(ISceneCache cache) { }

	/// <summary>
	/// 描画更新判定処理
	/// </summary>
	virtual public bool IsDrawUpdate()
	{
		return false;
	}

	/// <summary>
	/// UIの描画更新処理
	/// </summary>
	virtual public void OnDrawUpdate() { }
}
