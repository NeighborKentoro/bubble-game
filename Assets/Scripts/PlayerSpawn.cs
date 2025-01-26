using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    [SerializeField]
    private int playerId;

    public int GetPlayerId()
    {
        return playerId;
    }
}
