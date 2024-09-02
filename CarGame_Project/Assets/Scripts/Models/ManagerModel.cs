using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ������
/// </summary>
public static class ManagerModel
{
    /// <summary>
    /// �����ƶ��ٶ�
    /// </summary>
    public static float WallMoveSpeed { get; set; } = 5f;
    /// <summary>
    /// �����ƶ��ٶȱ���
    /// </summary>
    public static float WallMoveSpeedTimes { get; set; } = 1f;
    /// <summary>
    /// ��պ��л�����
    /// </summary>
    public static float SkyCutSpeedTimes { get; set; } = 1f;


    public static Action RestartGameEvent { get; set; }
    public static Action EndGameEvent { get; set; }
    public static Action WallRestEvent { get; set; }
    public static Action DestoryAllCars { get; set; }
}
