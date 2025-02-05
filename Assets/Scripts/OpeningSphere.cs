using System.Collections;
using UnityEngine;
using UnityEngine.Video;

public class OpeningSphere : MonoBehaviour
{
    public VideoPlayer vip;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        vip.Play();
        StartCoroutine(Wait());
    }

    IEnumerator Wait(){
        yield return new WaitForSeconds(30);
        transform.parent.gameObject.SetActive(false);
    }
}
