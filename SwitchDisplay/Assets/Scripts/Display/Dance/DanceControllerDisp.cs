using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ダンスモードUIのコントローラ角度表示
/// </summary>
public class DanceControllerDisp : UIBase
{

    //private GameObject _text;
    private GameSceneCache _cache;
    //private float _AngleZ;
    //
    //[SerializeField]
    //int No = 1;
    //public Slider UIobj;

    public override void OnAwake(ISceneCache cache, IEvents displayEvents)
    {
        base.OnAwake(cache, displayEvents);
        _cache = cache as GameSceneCache;
    }

    public override bool IsDrawUpdate()
    {
        // wiiリモコンから角度を取る
        //if (_AngleZ != DisplayManager.GetControllerAngle())
        //{
        //    _AngleZ = _cache.DisplayManager.GetControllerAngle();
        //    return true;
        //}
        return false;
    }

    public override void OnDrawUpdate()
    {
        //this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, _AngleZ);
    }
}