using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using static InputActions;

public interface IInputReader{
    Vector2 Direction {get; }
    void EnablePlayerActions();
    void DisablePlayerActions();
}

public interface IOnPlayerActions{
    void OnFlap(InputAction.CallbackContext context);
    void OnMove(InputAction.CallbackContext context);
}

[CreateAssetMenu(fileName = "InputReader1", menuName = "Input Readers/InputReader Player1", order = 0)]
public class InputReader : ScriptableObject, IPlayerActions, IInputReader, IOnPlayerActions
{
    public event UnityAction<Vector2> Move = delegate {};
    public event UnityAction<bool> Flap = delegate {};

    public InputActions inputActions;
    public Vector2 Direction => inputActions.Player.Move.ReadValue<Vector2>();
    public bool IsFlapPressed => inputActions.Player.Flap.IsPressed();

    public virtual void EnablePlayerActions()
    {
        if(inputActions == null){
            inputActions = new InputActions();
            inputActions.Player.SetCallbacks(this);
        }
        inputActions.Enable();
    }

    public virtual void DisablePlayerActions(){
        inputActions.Disable();
    }

    public void OnFlap(InputAction.CallbackContext context)
    {
        switch (context.phase){
            case InputActionPhase.Started:
                Flap.Invoke(true);
                break;
            case InputActionPhase.Canceled:
                Flap.Invoke(false);
                break;
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Move.Invoke(context.ReadValue<Vector2>());
    }
}
