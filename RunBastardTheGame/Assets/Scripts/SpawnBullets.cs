using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnBullets : MonoBehaviour
{


    public GameObject obj;              //Listen over mulige spawnobjekter
    public float pooledAmount = 20;     //Max antal objekter i listen
    private List<GameObject> list;

    void Awake()
    {
        FillPool();
    }


    private void FillPool()
    {
        list = new List<GameObject>();

        for (int i = 0; i < pooledAmount; i++)
        {
            GameObject gameObj = (GameObject)Instantiate(obj, transform.position, Quaternion.identity);
            gameObj.SetActive(false);
            list.Add(gameObj);
        }

        

    }

    public void Spawn()
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
