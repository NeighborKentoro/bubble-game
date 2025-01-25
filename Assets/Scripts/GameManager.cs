using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private List<Point> points = new List<Point>();
    [SerializeField]
    private GameObject token;

    private void Awake()
    {
        points.Add(new Point(1));
        points.Add(new Point(2));
    }

    void OnEnable()
    {
        EventManager.scoreEvent += this.ScorePoint;
    }

    void OnDisable()
    {
        EventManager.scoreEvent -= this.ScorePoint;
    }

    public void ScorePoint(int playerId)
    {
        // get points for player who scored
        Point p = points.Find(x => x.GetPlayerId() == playerId);
        // increment their score
        p.incrementScore();
        // evaluate win condition
        if (p.GetScore() >= 3)
        {
            // playerId wins
            Debug.Log("player" + playerId + " wins");
        } else
        {
            // if not won, spawn new token
            StartCoroutine(spawnNewToken());
        }
    }

    IEnumerator spawnNewToken()
    {
        yield return new WaitForSeconds(2f);

        GameObject[] spawnPoints = GameObject.FindGameObjectsWithTag("Spawn");

        Debug.Log(spawnPoints.Length);

        // pick random spawn point
        int spawnIndex = Random.Range(0, spawnPoints.Length);

        GameObject spawn = spawnPoints[spawnIndex];

        // spawn new token there
        Debug.Log("Spawning new token");

        Instantiate(token, spawn.transform.position, Quaternion.identity);
    }
}

public class Point
{
    private int playerId;
    private int score;

    public Point(int playerId)
    {
        this.playerId = playerId;
        this.score = 0;
    }

    public int GetPlayerId()
    {
        return playerId;
    }

    public int GetScore()
    {
        return score;
    }

    public void incrementScore()
    {
        score++;
    }
}
