using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnEnemy : MonoBehaviour {


    public GameObject[] obj;
    public float pooledAmount = 5;
    public float spawnMinTime = 10f;
    public float spawnMaxTime = 30f;
    private List<GameObject> list;


	// Use this for initialization
	void Start () {
        FillPool();
        
	}
	
	// Update is called once per frame
	void Update () {

	}

    private void FillPool()
    {
        list = new List<GameObject>();

        for (int i = 0; i < pooledAmount; i++)
        {
            for (int n = 0; n < obj.Length; n++)
            {
                GameObject go = (GameObject)Instantiate(obj[n], transform.position, Quaternion.identity);
                go.SetActive(false);
                list.Add(go);
            }
        }

        InvokeRepeating("SpawnEnemyObject", 1, Random.Range(spawnMinTime, spawnMaxTime));
    }


    private void SpawnEnemyObject()
    {
        Debug.Log("her");
        bool found = false;
        Vector3 spawnPos = new Vector3(this.transform.position.x, this.transform.position.y + 5, this.transform.position.z);
        while(!found)
        {
            int i = Random.Range(0, list.Count);

            if(!list[i].activeInHierarchy)
            {
                list[i].transform.position = spawnPos;
                list[i].SetActive(true);
                found = true;
            }
        }
    }
}
