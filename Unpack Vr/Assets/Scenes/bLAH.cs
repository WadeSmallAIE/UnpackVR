using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bLAH : MonoBehaviour
{
    public GameObject Ancore;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float distanceCheck = Vector3.Distance(transform.position, Ancore.transform.position);
        if (distanceCheck > 2)
        {
            Ancore.transform.position = new Vector3(transform.position.x,transform.position.y, Ancore.transform.position.z + 2);
        }
    }
}
