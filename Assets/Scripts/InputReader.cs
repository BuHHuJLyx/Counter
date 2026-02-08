using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour
{
    public event Action MouseClicked;

    private void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            MouseClicked?.Invoke();
        }
    }
}
