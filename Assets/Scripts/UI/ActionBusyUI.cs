using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ActionBusyUI : MonoBehaviour
{
    private void Start() 
    {
        UnitActionSystem.Instance.OnBusyChanged += UnitActionSystem_OnBusyChanged;
        Hide();
    }
    
    private void UnitActionSystem_OnBusyChanged(object sender, bool isBusy)
    {
        if(isBusy)
        {
            Show();
        }else{
            Hide();
        }
    }

    private void Show()
    {
        this.gameObject.SetActive(true);
    }
    private void Hide()
    {
        this.gameObject.SetActive(false);
    }
}
