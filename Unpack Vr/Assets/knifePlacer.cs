using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knifePlacer : MonoBehaviour
{
    public Transform[] pos;
    public GameObject[] objects;


    private void Start()
    {

    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Knife")
        {

            bool canTake = true;

            for (int i = 0; i < objects.Length; i++)
            {
                if (objects[i].gameObject == collision.gameObject)
                {
                    canTake = false;
                }
            }
            if (canTake)
            {
                for (int i = 0; i < objects.Length; i++)
                {
                    // put code here

                    if (objects[i] == null)
                    {
                        objects[i] = collision.gameObject;
                        collision.transform.position = pos[i].position;
                        collision.transform.rotation = pos[i].rotation;
                        collision.GetComponent<Rigidbody>().isKinematic = true;
                        collision.GetComponent<Rigidbody>().useGravity = false;

                        break;
                    }

                }
            }

        }
    }
    private void OnTriggerExit(Collider collision)
    {
        bool canTake = false;

        for (int i = 0; i < objects.Length; i++)
        {
            if (objects[i].gameObject == collision.gameObject)
            {
                canTake = true;
            }
        }

        collision.GetComponent<Rigidbody>().isKinematic = false;
        collision.GetComponent<Rigidbody>().useGravity = true;
    }
}
