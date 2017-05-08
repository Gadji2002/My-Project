using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureSpawner : MonoBehaviour
{

    public float minTime = 5f;
    public float maxTime = 40f;
	//public int limit = 12;

	private int spawned = 0;

	private GameObject[] treasureSpawnPoints;

    [SerializeField]

	private GameObject treasure;

	private GameObject currentTreasure;

    private int randomPointNumber = 0;

    void Awake()
    {
		treasureSpawnPoints = GameObject.FindGameObjectsWithTag("Floor");
        StartCoroutine(SpawnPerTime());
    }

    private IEnumerator SpawnPerTime()
    {
        while (true)
        {
			randomPointNumber = Random.Range(0, treasureSpawnPoints.Length);
			SpawnTreasure();
            float randTime = Random.Range(minTime, maxTime);
            yield return new WaitForSeconds(randTime);

        }
    }

	private void SpawnTreasure()
    {
		if (treasureSpawnPoints != null)
        {
			Vector3 position = treasureSpawnPoints[randomPointNumber].
                transform.position;
            position += new Vector3(0, 0f, 0);
			currentTreasure = Instantiate(treasure,
                position, Quaternion.identity) as GameObject;
			TreasureScript treasureScript = currentTreasure.GetComponent<TreasureScript>();
			if (treasureScript != null)
				treasureScript.ChooseRandomState();
		
        }
    }
}
