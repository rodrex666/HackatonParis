using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargingStation : MonoBehaviour
{
    public Battery battery;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Battery"))
        {
            battery.Charging();
        }
    }
}
