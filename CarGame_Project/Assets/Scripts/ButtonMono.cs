using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

internal class ButtonMono : ButtonSimple
{
    string _buttonName = "";
    protected override  void Start()
    {
        base.Start();
        _buttonName = name;
    }
    protected override void OnButtonClickEvent()
    {
        base.OnButtonClickEvent();
        //调试时打开
        //Debug.Log($"按钮{_buttonName}OnButtonClock触发");
    }
}
