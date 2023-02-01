using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WristMenu : MonoBehaviour
{
    public InputActionReference wristMenuButton = null;
    public GameObject locomotionMenu;

    private bool locomotionActive = false;

    void Start()
    {
        locomotionMenu.SetActive(locomotionActive);

        wristMenuButton.action.performed += SecondaryButtonPressed;
    }
    private void OnDestroy()
    {
        wristMenuButton.action.performed -= SecondaryButtonPressed;
    }

    private void SecondaryButtonPressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            DisplayLocomotionMenu();
        }
    }

    private void DisplayLocomotionMenu()
    {
        locomotionActive = !locomotionActive;
        locomotionMenu.SetActive(locomotionActive);
    }
}
