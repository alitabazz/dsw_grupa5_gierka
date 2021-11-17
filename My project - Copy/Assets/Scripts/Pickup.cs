using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public void Collect()
    {
        Debug.Log("Collected Pickup");
        Destroy(gameObject);
    }
}
