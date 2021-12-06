using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    public static InputMaster _controls;


    private void Awake()
    {
        _controls = new InputMaster();
    }

    private void OnEnable()
    {
        _controls.Enable();
    }

    private void OnDisable()
    {
        _controls.Disable();
    }

    public static Vector2 GetMovement(string playerName)
    {
        if (playerName == "Player1")
            return _controls.PlayerMovement.Player1Move.ReadValue<Vector2>();
        else if (playerName == "Player2")
            return _controls.PlayerMovement.Player2Move.ReadValue<Vector2>();
        else
            return _controls.PlayerMovement.CombinedPlayerMove.ReadValue<Vector2>();
    }

    public static bool CombinePressed()
    {
        return _controls.PlayerMovement.Combine.triggered;
    }

}
