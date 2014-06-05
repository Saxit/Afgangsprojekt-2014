using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerShoot : MonoBehaviour
{
    public Rigidbody projectile;
    public Transform shooterPos;

    public GameObject obj;              //Listen over mulige spawnobjekter
    public float pooledAmount = 20;     //Max antal objekter i listen
    private List<GameObject> list;

    void Update ()
    {
        Vector3 endPos = new Vector3(0, shooterPos.position.y + 30, 0);
        
        if (Input.GetButtonUp("Fire1"))
        {
            GameObject bullet = Spawn();            
            
            transform.position = Vector3.Lerp(shooterPos.position, endPos, Time.deltaTime);
        }
    }

    private void PoolSpawns()
    {
        list = new List<GameObject>();

        //for (int i = 0; i < pooledAmount; i++)
        //{
        //    for (int n = 0; n < obj.Length; n++)
        //    {

        //        GameObject go = (GameObject)Instantiate(obj[n], transform.position, Quaternion.identity);
        //        go.SetActive(false);
        //        list.Add(go);
        //    }
        //}

        for (int i = 0; i < pooledAmount; i++)
        {
            GameObject gameObj = (GameObject)Instantiate(obj, transform.position, Quaternion.identity);
            gameObj.SetActive(false);
            list.Add(gameObj);
        }

        

    }

    private GameObject Spawn()
    {
        GameObject isActive = null;
        for (int i = 0; i < list.Count; i++)
        {
            if (!list[i].activeInHierarchy)
            {
                list[i].transform.position = this.transform.position;
                list[i].transform.position = this.transform.position;
                list[i].SetActive(true);
                isActive = list[i];
                
            }
        }
        return isActive;
    }
}
