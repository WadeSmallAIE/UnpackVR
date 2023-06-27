using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instantiateObjects : MonoBehaviour
{

    public Transform pos;
    public Rigidbody[] prefab;

    // Start is called before the first frame update
    void Start()
    {
        //CreateObjects();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void CreateObjects()
    {
        int n = Random.Range(0, prefab.Length);
        Rigidbody p = Instantiate(prefab[n], pos.position, Quaternion.identity);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "GameController")
        {
            //CreateObjects();
            Debug.Log("hit");
        }
    }

}
