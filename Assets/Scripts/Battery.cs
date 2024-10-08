using UnityEngine;
using System.Collections;

public class Battery : MonoBehaviour
{

    public float targetTime = 60.0f;

    public bool isCharged = true;


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
    }

    public void Charging()
    {
        isCharged = true;
        targetTime = 60.0f;
    }
}
