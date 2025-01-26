using UnityEngine;

public class EventManager : MonoBehaviour
{
    public delegate void BubblePopAction();
    public static event BubblePopAction bubblePopEvent;

    public delegate void GenericPlayerAction(int playerId);
    public static event GenericPlayerAction scoreEvent;
    public delegate void GenericEvent();
    public static event GenericEvent flapEvent;
    public static event GenericEvent splashEvent;

    public delegate void StartGameAction();
    public static event StartGameAction startGameEvent;

    public static void BubblePop()
    {
        bubblePopEvent?.Invoke();
    }

    public static void PlayerScored(int playerId)
    {
        scoreEvent?.Invoke(playerId);
    }

    public static void StartGame()
    {
        startGameEvent?.Invoke();
    }

    public static void Flap()
    {
        flapEvent?.Invoke();
    }

    public static void Splash()
    {
        splashEvent?.Invoke();
    }
}
