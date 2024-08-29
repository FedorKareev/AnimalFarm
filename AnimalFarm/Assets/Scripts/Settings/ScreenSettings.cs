using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ScreenSettings : MonoBehaviour
{
    [SerializeField]
    private Toggle _windowToggle;

    private void Start()
    {
        _windowToggle.isOn = false;
    }

    public void ScreenMode()
    {
        Screen.fullScreen = !_windowToggle.isOn;
    }

}
