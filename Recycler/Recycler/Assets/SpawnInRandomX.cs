using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnInRandomX : MonoBehaviour {

    public GameManager gameManager;
    public GameObject[] trashItems;
    public GameObject trash;
    GameObject toSpawn;
    int spawnDelay;
    int delay;
    float width;
    float height;

	// Use this for initialization
	void Start () {
        Camera gameCam = Camera.main;
        height = 2f * gameCam.orthographicSize;
        width = height * gameCam.aspect;       
        trash = GameObject.FindGameObjectWithTag("Trash");
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        spawnDelay = gameManager.spawnDelay;
        Debug.Log(width);
        delay = spawnDelay;
    }
	
	// Update is called once per frame
	void Update () {        
        if (delay > 0)
        {
            delay--;
        }
        if (delay == 0)
        {
            int spawnID = Random.Range(0, trashItems.Length-1);
            toSpawn = trashItems[spawnID];
            Vector3 start = transform.position;
            GameObject obj = Instantiate(toSpawn, start, transform.rotation);
            obj.transform.SetPositionAndRotation(new Vector3(Random.Range(0-(width/2), width/2), transform.position.y, transform.position.z), transform.rotation);
            obj.transform.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-0.1f, 0.1f), 10.0f);
            
            delay = spawnDelay;
        }
	}
}
