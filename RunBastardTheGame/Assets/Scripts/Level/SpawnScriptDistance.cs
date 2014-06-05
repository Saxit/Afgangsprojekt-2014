using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnScriptDistance : MonoBehaviour {

    public GameObject[] obj;                      //Listen over mulige spawnobjekter
    public GameObject uniqueObject;               //Specielt objekt der ikke passer i listen. F.eks slutplatformen
    public float distanceBetweenObjects = 60f;    //Hvor langt er der i afstand mellem de objekter der skal spawnes
    public int numberOfObjectsToSpawn = 18;       //Hvor mange objekter skal der spawnes i lvl
    public float pooledAmount = 5;                //antallet af hver type obj der skal pooles
    public GameObject lastObject;                 //Det sidst spawnede objekt

    private List<GameObject> list;
    private int _spawnedObjects = 0;              //Delta antal spawnede objekter
    private bool _allObjectsSpawned = false;      //Bruges til at se om alle objekter er spawnet
    

	// Use this for initialization
	void Start () {
        FillPool();
        SpawnPlatform();
    
	}

	
	// Update is called once per frame
	void Update () {

        isAllObjectsSpawned();

        //Finder afstanden imellem dette objekt og det sidst spawnede objekt
        float distance = Vector3.Distance(this.transform.position, lastObject.transform.position);

        if(_allObjectsSpawned == false)
        {
            //hvis afstanden mellem dette objekt og det sidste spawnede er større end det brugerdefinerede
            //Og det ikke er slutningen af lvl.
            if(distance >= distanceBetweenObjects)
            {
                Debug.Log(distance.ToString());
                //spawn nyt objekt
                SpawnPlatform();
            }
        }
        else
        {
            //hvis afstanden mellem dette objekt og det sidste spawnede er større end det brugerdefinerede
            //og det ER slutningen af lvl.
            if (distance >= distanceBetweenObjects)
            {
                SpawnUnique();
            }
        }

	}

    /// <summary>
    /// Kontrollerer om alle banens platforme er blevet spawnet.
    /// </summary>
    private void isAllObjectsSpawned()
    {
        if (numberOfObjectsToSpawn == _spawnedObjects)
        {
            _allObjectsSpawned = true;
        }
    }

    /// <summary>
    /// Sæt alle platformtyper til inaktive.
    /// </summary>
    private void FillPool()
    {
        //Debug.Log("poolspawns");
        list = new List<GameObject>();

        for (int i = 0; i < pooledAmount; i++)
        {
            for (int n = 0; n < obj.Length; n++)
            {
                GameObject go = (GameObject)Instantiate(obj[n], transform.position, Quaternion.identity);
                go.SetActive(false);
                list.Add(go);
                //Debug.Log(list.Count.ToString());
            }
                
        }

        //Debug.Log(platformTypes.Count.ToString());
    }

    /// <summary>
    /// Vælger et tilfældigt inaktiv objekt fra listen, og sætter den til aktiv.
    /// </summary>
    private void SpawnPlatform()
    {
        //Debug.Log("spawn");
        bool found = false;

        //Så længe der ikke er fundet et inaktiv objekt
         while (!found)
         {
             //Vælg et tilfældigt objekt, her ved vi ikke hvilke der er inaktive
            int i = Random.Range(0, list.Count);
            
            //Se om det valgte objekt er aktivt
            if (!list[i].activeInHierarchy)
            {
                //Hvis den er inaktiv, så opret den.
                _spawnedObjects++;                                                  //opdater banens længde
                lastObject = list[i];                                               //cache nyt GO
                list[i].transform.position = this.transform.position;               //sæt nyt GO til spawnerens position
                list[i].SetActive(true);                                            //Aktiver nyt GO
                found = true;
            }
        }

        

    }

    /// <summary>
    /// Spawner det unikke objekt. Og slukker for spawnobjektet
    /// </summary>
    private void SpawnUnique()
    {
        Instantiate(uniqueObject, transform.position, Quaternion.identity);
        this.gameObject.SetActive(false);
    }

}
