using UnityEngine;

public class Bubble : MonoBehaviour
{
    [SerializeField]GameObject bubble;
    [SerializeField]PlayerController playerController;
    void OnEnable()
    {
        EventManager.bubblePopEvent += this.Pop;
    }

    void OnDisable()
    {
        EventManager.bubblePopEvent -= this.Pop;
    }

    public void Pop()
    {
        // destroy balloon
        playerController.SetBalloonAttachment(false);
        bubble.SetActive(false);
        //Object.Destroy(this.gameObject);
    }
}
