using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnScriptDistance : MonoBehaviour {

    public List<GameObject> platformTypes;             //Listen over mulige spawnobjekter
    public GameObject endPlatform;                  //Den sidste platform i lvl
    public float distanceBetweenObjects = 10f;      //Hvor langt er der i afstand mellem de objekter der skal spawnes
    public int numberOfPlatforms = 10;              //Hvor mange platforme skal der spawnes i lvl
    
    private GameObject _lastObject;                 //Det sidst spawnede objekt
    private int _spawnedPlatforms = 0;              //Delta antal spawnede platforme
    private bool _lvlEnd = false;                   //Check om lvl er slut
    

	// Use this for initialization
	void Start () {
        PoolSpawns();
        Spawn();
        Debug.Log("start");
	
	}

	
	// Update is called once per frame
	void Update () {

        if(_lvlEnd == false)
        {
            //Finder afstanden imellem dette objekt og det sidst spawnede objekt
            float distance = Vector3.Distance(this.transform.position, _lastObject.transform.position);

            //hvis afstanden mellem dette objekt og det sidste spawnede er større end det brugerdefinerede
            //Og det ikke er slutningen af lvl.
            if(distance >= distanceBetweenObjects && _spawnedPlatforms != numberOfPlatforms)
            {
                //spawn nyt objekt
                Spawn();
            }

            //hvis afstanden mellem dette objekt og det sidste spawnede er større end det brugerdefinerede
            //og det ER slutningen af lvl.
            if (distance >= distanceBetweenObjects && _spawnedPlatforms == numberOfPlatforms)
            {
                SpawnEnding();
            }

        }
	}

    private void PoolSpawns()
    {
 
        for (int i = 0; i < platformTypes.Count; i++)
        {

            platformTypes[i].SetActive(false);
                    
        }

        Debug.Log(platformTypes.Count.ToString());
    }

    /// <summary>
    /// 
    /// </summary>
    private void Spawn()
    {
        bool found = false;

         while (!found)
         {
            int i = Random.Range(0, platformTypes.Count);
            Debug.Log(i.ToString());
            if (!platformTypes[i].activeInHierarchy)
            {
                _spawnedPlatforms++;
                _lastObject = platformTypes[i];
                Debug.Log(_lastObject.transform.name);
                platformTypes[i].transform.position = this.transform.position;
                platformTypes[i].SetActive(true);
                Instantiate(platformTypes[i], this.transform.position, Quaternion.identity);
                found = true;
            }
        }

        

    }

    /// <summary>
    /// Spawner slutplatformen.
    /// </summary>
    private void SpawnEnding()
    {
        Instantiate(endPlatform, transform.position, Quaternion.identity);
        _lvlEnd = true;
    }

}
