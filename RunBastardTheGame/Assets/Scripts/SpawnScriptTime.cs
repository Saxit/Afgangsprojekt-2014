using UnityEngine;
using System.Collections;

public class SpawnScriptTime : MonoBehaviour {

    public GameObject[] obj;            //Listen over mulige spawnobjekter
    public float spawnMin = 1f;         //Mindste random-værdi for spawn af objekt
    public float spawnMax = 2f;         //Højeste random-værdi for spawn af objekt

	// Use this for initialization
	void Start () {
        Spawn();
	}
	
    /// <summary>
    /// Spawner et objekt hvert random tidsinterval
    /// se også Invoke: http://docs.unity3d.com/Documentation/ScriptReference/MonoBehaviour.Invoke.html
    /// </summary>
    private void Spawn()
    {
        Instantiate(obj[Random.Range(0, obj.GetLength(0))], transform.position, Quaternion.identity);
        Invoke("Spawn", Random.Range(spawnMin, spawnMax));

    }

}
