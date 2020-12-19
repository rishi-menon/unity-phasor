using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroidSpawnerScript : MonoBehaviour
{
    public GameObject astroid;
    [Space(5)]
    public Vector2 timeBetweenSpawns;
    public Vector2 spawnPosYPercent;

    private float nextSpawnTime;
    private float spawnPosX;
    private Vector2 spawnPosY;

    // Start is called before the first frame update
    void Start()
    {
        nextSpawnTime = 0;
        Vector3 bottomRight = Camera.main.ScreenToWorldPoint(Vector3.right * Screen.width);
        Vector3 topRight    = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height));
        spawnPosX = bottomRight.x + 2; 

        spawnPosY.x = Mathf.Lerp(bottomRight.y, topRight.y, spawnPosYPercent.x);
        spawnPosY.y = Mathf.Lerp(bottomRight.y, topRight.y, spawnPosYPercent.y);
    }

    // Update is called once per frame
    void Update()
    {
        float curTime = Time.time;
        if (curTime >= nextSpawnTime)
        {
            
            nextSpawnTime = curTime + Mathf.Lerp(timeBetweenSpawns.x, timeBetweenSpawns.y, Random.Range (0.0f, 1.0f));
            CreateAstroid();
        } 
    }

    void CreateAstroid() {
        Vector3 position = Vector3.zero;
        position.x = spawnPosX;
        position.y = Mathf.Lerp (spawnPosY.x, spawnPosY.y, Random.Range (0.0f, 1.0f));

        GameObject obj = Instantiate(astroid, position, Quaternion.identity);
        obj.transform.parent = transform;
    }
}
