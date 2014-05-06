using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnScriptTime : MonoBehaviour {

    public GameObject[] obj;            //Listen over mulige spawnobjekter
    public float spawnMin = 4f;         //Mindste random-værdi for spawn af objekt
    public float spawnMax = 8f;         //Højeste random-værdi for spawn af objekt
    public float pooledAmount = 3;

    private List<GameObject> list;
	// Use this for initialization
	void Start () {
        PoolSpawns();
	}

    private void PoolSpawns()
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

        InvokeRepeating("Spawn",1, Random.Range(spawnMin, spawnMax));

    }

    /// <summary>
    /// Spawner et objekt hvert random tidsinterval
    /// se også Invoke: http://docs.unity3d.com/Documentation/ScriptReference/MonoBehaviour.Invoke.html
    /// </summary>
    private void Spawn()
    {
        for (int i = 0; i < list.Count; i++)
        { 
            if (!list[i].activeInHierarchy)
            {
                list[i].transform.position = this.transform.position;
                list[i].transform.position = this.transform.position;
                list[i].SetActive(true);
                break;
            }
        }
    }

}
