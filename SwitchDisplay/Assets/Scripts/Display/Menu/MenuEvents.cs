﻿using System;

/// <summary>
/// メニューディスプレイのUIオブジェクト呼び出しイベントクラス
/// 製作者：実川
/// </summary>
public class MenuEvents : EventsBase 
{
	/// <summary>
	/// CallEvent処理実行イベント
	/// 本当は複数のUIオブジェクトが登録できるような、UIオブジェクトが欲しい「タイミング」の名前の変数名にする
	/// 例：onTimeUp...タイムアップ時実行イベント（これなら、複数のUIオブジェクトを登録できる）
	/// </summary>
	public Action onCallEvent;
}