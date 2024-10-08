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

    private void OnCollisionEnter(Collision collision)
    {
        GameObject other = collision.gameObject;
        Debug.Log("Enter object");
        if (other.CompareTag("Battery") && battery.isCharged)
        {
            Debug.Log("Enter baterry");
            tv.GetComponent<MeshRenderer>().material = materials[materialNumber];
        }
        
            
    }

    private void OnCollisionExit(Collision collision)
    {
        GameObject other = collision.gameObject;
        if (other.CompareTag("Battery"))
        {
            tv.GetComponent<MeshRenderer>().material = defaultMaterial;
        }
    }
}
