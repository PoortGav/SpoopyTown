using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightPump : MonoBehaviour
{
    public Light pumpkinLight;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            pumpkinLight.enabled = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            pumpkinLight.enabled = false;
        }
    }
}
