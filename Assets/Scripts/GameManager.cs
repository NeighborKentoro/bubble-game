using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    private List<Point> points = new List<Point>();
    [SerializeField]
    private GameObject token;
    [SerializeField]
    private GameObject playerPrefab;
    [SerializeField]
    private int numberOfTokenSpawnPoints;
    [SerializeField]
    private float yBottomLimit = -2.5f;
    [SerializeField]
    private float xLeftLimit = -6.5f;
    [SerializeField]
    private float yTopLimit = 2.5f;
    [SerializeField]
    private float xRightLimit = 6.5f;
    [SerializeField]
    private InputReader inputReader1;
    [SerializeField]
    private InputReader inputReader2;
    [SerializeField]
    private GameObject tokenSpawnPoint;


    private void Awake()
    {
        points.Add(new Point(1));
        points.Add(new Point(2));

        GameObject.FindGameObjectWithTag("EndGameCanvas").GetComponent<Canvas>().enabled = false;

    }

    void OnEnable()
    {
        EventManager.scoreEvent += this.ScorePoint;
        EventManager.startGameEvent += this.StartGame;
    }

    void OnDisable()
    {
        EventManager.scoreEvent -= this.ScorePoint;
        EventManager.startGameEvent -= this.StartGame;
    }

    public void StartGame()
    {
        // Start game
        Debug.Log("start game");

        // Enable score canvas
        GameObject.FindGameObjectWithTag("ScoreCanvas").GetComponent<Canvas>().enabled = true;

        // Disable game over and main menu canvases
        GameObject.FindGameObjectWithTag("EndGameCanvas").GetComponent<Canvas>().enabled = false;
        GameObject.FindGameObjectWithTag("MenuCanvas").GetComponent<Canvas>().enabled = false;

        // Enable arena objects
        // Generate token locations
        for(int i = 0; i < numberOfTokenSpawnPoints; i++)
        {
            float xTokenValue = Random.Range(xLeftLimit, xRightLimit);
            float yTokenValue = Random.Range(yBottomLimit, yTopLimit);

            Debug.Log(xTokenValue + " " + yTokenValue);

            Instantiate(tokenSpawnPoint, new Vector3(xTokenValue, yTokenValue, 0), Quaternion.identity);
        }


        // Spawn players
        GameObject[] playerSpawns = GameObject.FindGameObjectsWithTag("PlayerSpawn");
        foreach(GameObject ps in playerSpawns)
        {
            GameObject player = Instantiate(playerPrefab, ps.transform.position, Quaternion.identity);
            Player playerScript = player.GetComponent<Player>();
            playerScript.SetPlayerId(ps.GetComponent<PlayerSpawn>().GetPlayerId());
            PlayerController pc = player.GetComponent<PlayerController>();
            if (ps.GetComponent<PlayerSpawn>().GetPlayerId() == 1)
                pc.SetInputReader(inputReader1);
            else
                pc.SetInputReader(inputReader2);
        }


        // Spawn token
        StartCoroutine(spawnNewToken());
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
            Debug.Log("Game over");

            // deactivate score canvas
            GameObject.FindGameObjectWithTag("ScoreCanvas").GetComponent<Canvas>().enabled = false;

            // activate end game canvas
            //GameObject endGameCanvas = GameObject.FindGameObjectWithTag("EndGameCanvas");
            //endGameCanvas.SetActive(true);
            GameObject.FindGameObjectWithTag("EndGameCanvas").GetComponent<Canvas>().enabled = true;

            GameObject winMessage = GameObject.FindGameObjectWithTag("WinMessage");

            winMessage.GetComponent<TMP_Text>().text = "Player " + p.GetPlayerId() + " Wins!";
            //winMessage.GetComponent<TMP_Text>().text = "Player Wins!";
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
