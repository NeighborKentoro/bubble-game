using UnityEngine;

public class Bubble : MonoBehaviour
{
    void OnEnable()
    {
        EventManager.bubblePopEvent += this.Pop;
    }

    void OnDisable()
    {
        EventManager.bubblePopEvent -= this.Pop;
    }

    public void Pop(int playerId)
    {
        
    }
}
