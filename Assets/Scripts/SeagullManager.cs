using System.Collections;
using UnityEngine;

public class SeagullManager : MonoBehaviour
{
    [SerializeField]GameObject seagullPrefab;
    [SerializeField]Transform[] leftSideSpawnPositions;
    [SerializeField]Transform[] rightSideSpawnPositions;
    [SerializeField]float spawnTimer = 5f;
    [SerializeField]float despawnTimer = 8f;
    bool canSpawn;
 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        canSpawn = true;
    }

    void Update(){
        if(canSpawn){
            StartCoroutine(SpawnSeagullEnumerator());
        }
    }

    IEnumerator SpawnSeagullEnumerator(){
        canSpawn = false;
        yield return new WaitForSeconds(spawnTimer);
        SpawnSeagull();
        canSpawn = true;
    }

    GameObject SpawnSeagull(){
        int side = Random.Range(0,2);
        Vector3 position;
        Vector3 dir;
        if(side == 0){
            position = leftSideSpawnPositions[Random.Range(0, leftSideSpawnPositions.Length)].position;
            dir = Vector3.right;
        }else{
            position = rightSideSpawnPositions[Random.Range(0, rightSideSpawnPositions.Length)].position;
            dir = Vector3.left;
        }
        GameObject temp =Instantiate(seagullPrefab, position, Quaternion.identity);
        temp.GetComponent<Seagull>().ActivateSeagull(dir, true, despawnTimer);
        EventManager.Seagull();
        return temp;
     }
}
