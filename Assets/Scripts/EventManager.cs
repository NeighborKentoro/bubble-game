using UnityEngine;

public class EventManager : MonoBehaviour
{
    public delegate void BubblePopAction(int playerId);
    public static event BubblePopAction bubblePopEvent;

    public static void BubblePop(int playerId)
    {
        bubblePopEvent?.Invoke(playerId);
    }
}
