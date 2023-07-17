using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Trigger : MonoBehaviour
{
    public UnityEvent _OnTriggerEnter;

    private void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<PlayerControl>();
        if(player != null)
        {
            Debug.Log("go");
            _OnTriggerEnter?.Invoke();
        }
    }
}
