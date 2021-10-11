using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float respawnTime = 5.0f;
    public Vector3 enemyLocation;
    [SerializeField] private Transform playerPosition;
    
    void Start()
    {
        StartCoroutine(enemySpawner());
    }

    IEnumerator enemySpawner()
    {
        while(true) {
            yield return new WaitForSeconds(respawnTime);
            float randomY = Random.Range(0,1);
            int x = (int)Random.Range(playerPosition.position.x-5f, playerPosition.position.x + 5f);
            int y = (int)(randomY > 0.5 ? playerPosition.position.y + 5f : playerPosition.position.y - 5f);
            Debug.Log(randomY);
            
            GameObject a = Instantiate(enemyPrefab) as GameObject;
            //fireLocation = GameObject.FindWithTag("Fire").transform.position;
            a.transform.position = new Vector3(x, y, 0);
            //a.transform.position = fireLocation;
        }
    }

}
