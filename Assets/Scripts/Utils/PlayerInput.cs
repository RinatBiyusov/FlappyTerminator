using UnityEngine;
using System;

public class BirdInput : MonoBehaviour
{
    public event Action ButtonClicked;

    public bool WasPressedSpace { get; private set; }

    private void Update()
    {
        CheckPressSpace();
        CheckPressLeftClick();
    }

    private void CheckPressSpace()
    {
        if (Time.timeScale > 0)
            WasPressedSpace = Input.GetKeyDown(KeyCode.Space);
    }

    private void CheckPressLeftClick()
    {
        if (Input.GetMouseButtonDown(0) && Time.timeScale > 0)
            ButtonClicked?.Invoke();
    }
}