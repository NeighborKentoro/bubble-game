using UnityEngine;

public class EventManager : MonoBehaviour
{
    public delegate void BubblePopAction(int playerId);
    public static event BubblePopAction bubblePopEvent;

    public delegate void GenericPlayerAction(int playerId);
    public static event GenericPlayerAction scoreEvent;

    public static void BubblePop(int playerId)
    {
        bubblePopEvent?.Invoke(playerId);
    }

    public static void PlayerScored(int playerId)
    {
        scoreEvent?.Invoke(playerId);
    }
}
