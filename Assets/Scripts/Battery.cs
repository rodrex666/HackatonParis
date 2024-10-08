using UnityEngine;
using System.Collections;

public class Battery : MonoBehaviour
{

    public float targetTime = 20.0f;

    public bool isCharged = true;

    public GameObject light;


    void Update()
    {

        targetTime -= Time.deltaTime;

        if (targetTime <= 0.0f)
        {
            TimerEnded();
        }

    }

    void TimerEnded()
    {
        isCharged = false;
        light.SetActive(false);
    }

    public void Charging()
    {
        isCharged = true;
        targetTime = 60.0f;
        light.SetActive(true);
    }
}
