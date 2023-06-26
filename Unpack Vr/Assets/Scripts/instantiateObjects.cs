using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instantiateObjects : MonoBehaviour
{

    public Transform pos;
    public GameObject[] instantiateObject;

    // Start is called before the first frame update
    void Start()
    {
        CreateObjects();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void CreateObjects()
    {
        int n = Random.Range(0, instantiateObject.Length);
        GameObject g = Instantiate(instantiateObject[n], pos.position, transform.rotation);
    }
}
