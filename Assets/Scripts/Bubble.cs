using UnityEngine;

public class Bubble : MonoBehaviour
{
    [SerializeField]GameObject bubble;
    [SerializeField]PlayerController playerController;

    public void Pop()
    {
        // destroy balloon
        playerController.SetBalloonAttachment(false);
        bubble.SetActive(false);
    }
}
