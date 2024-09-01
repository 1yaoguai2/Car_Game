using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClose : MonoBehaviour
{
    private Button btnClose;
    private void Start()
    {
        btnClose = GetComponent<Button>();
        btnClose.onClick.AddListener(() =>
        {
            transform.parent.gameObject.SetActive(false);
        });

    }
}
