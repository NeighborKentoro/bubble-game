using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using static InputActions;

[CreateAssetMenu(fileName = "InputReader2", menuName = "Input Readers/InputReader Player2", order = 1)]
public class InputReader2 : InputReader, IPlayer2Actions
{
    public override void EnablePlayerActions()
    {
        if(inputActions == null){
            inputActions = new InputActions();
            inputActions.Player2.SetCallbacks(this);
        }
        inputActions.Enable();
    }
}
