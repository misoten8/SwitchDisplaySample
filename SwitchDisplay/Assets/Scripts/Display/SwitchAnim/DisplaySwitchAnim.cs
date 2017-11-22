using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ディスプレイ切り替えアニメーションクラス
/// </summary>
public class DisplaySwitchAnim : MonoBehaviour
{
	public enum AnimType
	{
		/// <summary>
		/// 移動しない
		/// </summary>
		None,
		/// <summary>
		/// 中心から外側に向かって各UIオブジェクトが移動する
		/// </summary>
		CircleOut
		//SlideLeftIn...
	}

	/// <summary>
	/// アニメーション再生中かどうか
	/// </summary>
	public bool IsPlaying
	{
		get { return _isPlaying; }
	}

	private bool _isPlaying = false;

	/// <summary>
	/// フェードインアニメーション再生時間
	/// </summary>
	[SerializeField]
	private float _fadeInAnimTime = 1.0f;

	/// <summary>
	/// フェードアウトアニメーション再生時間
	/// </summary>
	[SerializeField]
	private float _fadeOutAnimTime = 1.0f;

	/// <summary>
	/// フェードインで使用する再生アニメーションの種類
	/// </summary>
	[SerializeField]
	private AnimType _fadeInAnim = AnimType.None;

	/// <summary>
	/// フェードアウトで使用する再生アニメーションの種類
	/// </summary>
	[SerializeField]
	private AnimType _fadeOutAnim = AnimType.None;

	/// <summary>
	/// UIオブジェクトリスト
	/// </summary>
	private List<UIBase> _uiList = null;

	private float _playingAnimElapsedTime = 0.0f;

	private float _animTime = 0.0f;

	/// <summary>
	/// アニメーション再生処理
	/// </summary>
	private Action<float> _animPlayer;

	/// <summary>
	/// 初期化処理
	/// </summary>
	public void OnAwake(List<UIBase> uiList)
	{
		_uiList = uiList;
	}

	/// <summary>
	/// アニメーション再生処理
	/// </summary>
	public void OnPlayFadeIn()
	{
		_OnPlay ();
		_animTime = _fadeInAnimTime;
	}

	/// <summary>
	/// アニメーション再生処理
	/// </summary>
	public void OnPlayFadeOut()
	{
		_OnPlay ();
		_animTime = _fadeOutAnimTime;

	}
		
	private void Update()
	{
		if (!_isPlaying)
			return;

		_playingAnimElapsedTime += Time.deltaTime;
		_animPlayer?.Invoke (Mathf.Min(_playingAnimElapsedTime / _animTime, 1.0f));

		if (_playingAnimElapsedTime > _animTime)
			_isPlaying = false;
	}

	/// <summary>
	/// 共通のアニメーション再生処理
	/// </summary>
	/// <returns>The play.</returns>
	private void _OnPlay()
	{
		_isPlaying = true;
		//TODO:DoTweenを導入し、アニメーション処理を実装する
		//処理ごとに関数化し、Action<float>型　変数に登録してUpdateで実行させる
		_animPlayer = (rate) => {};
		_animPlayer?.Invoke (0.0f);
	}
}
