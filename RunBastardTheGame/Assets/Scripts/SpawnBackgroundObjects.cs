using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnBackgroundObjects : MonoBehaviour {
    
    public List<GameObject> objectTypes;          //Listen over mulige spawnobjekter
    public float distanceBetweenObjects = 10f;    //Hvor langt er der i afstand mellem de objekter der skal spawnes
    public int numberOfObjectsToSpawn = 10;       //Hvor mange objekter skal der spawnes i lvl

    private GameObject _lastObject;               //Det sidst spawnede objekt
    private int _spawnedObjects = 0;              //Delta antal spawnede objekter
    private bool _allObjectsSpawned = false;      //Bruges til at se om alle objekter er spawnet
    private Object[] _textures;


    // Use this for initialization
    void Start()
    {
        LoadTextures();
        PoolSpawns();
        Spawn();

    }


    // Update is called once per frame
    void Update()
    {

        if (_allObjectsSpawned == false)
        {
            //Finder afstanden imellem dette objekt og det sidst spawnede objekt
            float distance = Vector3.Distance(this.transform.position, _lastObject.transform.position);

            //hvis afstanden mellem dette objekt og det sidste spawnede er større end det brugerdefinerede
            //Og det ikke er slutningen af lvl.
            if (distance >= distanceBetweenObjects && _spawnedObjects != numberOfObjectsToSpawn)
            {
                //spawn nyt objekt
                Spawn();
            }

            //hvis afstanden mellem dette objekt og det sidste spawnede er større end det brugerdefinerede
            //og det ER slutningen af lvl.
            if (distance >= distanceBetweenObjects && _spawnedObjects == numberOfObjectsToSpawn)
            {
                this.enabled = false;
            }

        }
    }

    private void LoadTextures()
    {
        _textures = Resources.LoadAll("Textures", typeof(Texture));
        //Debug.Log(_textures.Length.ToString());
    }

    /// <summary>
    /// Sæt alle platformtyper til inaktive.
    /// </summary>
    private void PoolSpawns()
    {

        for (int i = 0; i < objectTypes.Count; i++)
        {

            objectTypes[i].SetActive(false);

        }

        //Debug.Log(platformTypes.Count.ToString());
    }

    /// <summary>
    /// Vælger et tilfældigt inaktiv objekt fra listen, og sætter den til aktiv.
    /// </summary>
    private void Spawn()
    {
        bool found = false;

        //Så længe der ikke er fundet et inaktiv objekt
        while (!found)
        {
            //Vælg et tilfældigt objekt, her ved vi ikke hvilke der er inaktive
            int i = Random.Range(0, objectTypes.Count);
            int n = Random.Range(0, _textures.Length);
            //Se om det valgte objekt er aktivt
            if (!objectTypes[i].activeInHierarchy)
            {
                //Hvis den er inaktiv, så opret den og opdater spillet med antal spawnede objekter
                _spawnedObjects++;
                
                objectTypes[i].transform.position = this.transform.position;
                objectTypes[i].SetActive(true);
                _lastObject = (GameObject) Instantiate(objectTypes[i], this.transform.position, Quaternion.identity);
                _lastObject.renderer.material.mainTexture = (Texture) _textures[n];
                _lastObject.renderer.material.shader = Shader.Find("Unlit/Transparent");


                found = true;
            }
        }



    }
}
