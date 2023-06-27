using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public List<GameObject> Spawner;
    public int x;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnObject()
    {
        Debug.Log("Object Spawned");
        x = Random.Range(0, Spawner.Count-1);
        Debug.Log(Spawner[x].name);
        GameObject p = Instantiate(Spawner[x]);

    }
    /*
        private void OnTriggerStay(Collider other)
        {
            if(other.gameObject.tag == "Player")
            {
                ExtraInput button = other.GetComponent<ExtraInput>();
                if (button.SpawnGo)
                {

                }
            }
        }*/
}
