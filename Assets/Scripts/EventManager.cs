using UnityEngine;

public class EventManager : MonoBehaviour
{
    public delegate void BubblePopAction();
    public static event BubblePopAction bubblePopEvent;

    public static void BubblePop()
    {
        bubblePopEvent?.Invoke();
    }
}
