using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] float shakeMagnitude = 0.5f;
    [SerializeField] float shakeDelay = 0.2f;

    Vector3 inittiaPos;

    // Start is called before the first frame update
    void Start()
    {
        inittiaPos = transform.position;
    }
    public void Play()
    {
        StartCoroutine(Shake());
    }
    IEnumerator Shake()
    {
        //Debug.Log("Shake");
        float time = 0;
        while (time < shakeDelay)
        {
            time += Time.deltaTime;
            transform.position = inittiaPos + (Vector3)Random.insideUnitCircle*shakeMagnitude;
            yield return new WaitForEndOfFrame();
        }
        transform.position = inittiaPos;
    }
}
