using UnityEngine;

/// <summary>
/// MenuDisplayDebugEvent クラス
/// 製作者：実川
/// </summary>
public class MenuDisplayDebugEvent : DisplayDebugEventBase 
{
	[SerializeField]
	private MenuDisplay _menuDisplay;

	public override void OnAwake()
	{
		debugEvents
			.eventList
			.Add(
			new DisplayDebugger.DebugEvents.Element(
				_menuDisplay._events.onCallEvent,
				nameof(_menuDisplay._events.onCallEvent)));
	}
}