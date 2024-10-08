using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Socket : MonoBehaviour
{
    public GameObject tv;

    public Battery battery;

    [SerializeField] Material[] materials;

    public Material defaultMaterial;

    public int materialNumber = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Battery") && battery.isCharged)
        {
            tv.GetComponent<MeshRenderer>().material = materials[materialNumber];
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Battery"))
        {
            tv.GetComponent<MeshRenderer>().material = defaultMaterial;
        }
    }
}
