using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 管理类
/// </summary>
public static class ManagerModel
{
    /// <summary>
    /// 地形移动速度
    /// </summary>
    public static float WallMoveSpeed { get; set; } = 5f;
    /// <summary>
    /// 地形移动速度倍数
    /// </summary>
    public static float WallMoveSpeedTimes { get; set; } = 1f;
    /// <summary>
    /// 天空盒切换倍数
    /// </summary>
    public static float SkyCutSpeedTimes { get; set; } = 1f;


    public static Action RestartGameEvent { get; set; }
    public static Action EndGameEvent { get; set; }
    public static Action WallRestEvent { get; set; }
    public static Action DestoryAllCars { get; set; }
}
