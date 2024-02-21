using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScollBG : MonoBehaviour
{
    [SerializeField] Vector2 speedScoll;

    Vector2 offset;
    Material materialScoll;
    private void Awake()
    {
        materialScoll = transform.GetComponent<SpriteRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        offset = speedScoll*Time.deltaTime;
        materialScoll.mainTextureOffset += offset;
    }
}
