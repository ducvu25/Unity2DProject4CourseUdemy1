using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [Header("\n-----------Information----------")]
    [SerializeField] float speed = 5f;
    Heath information;

    [Header("\n-----------Limit ground----------")]
    Vector2 v2_inputSystem;
    [SerializeField] float padding = 0.5f;
    Vector2 v2_positionMin, v2_positionMax;

    private void Awake()
    {
        information = GetComponent<Heath>();
    }
    // Start is called before the first frame update
    void Start()
    {
        InitLimit();
    }
    void InitLimit()
    {
        Camera camera = Camera.main;
        v2_positionMin = camera.ViewportToWorldPoint(new Vector2(0, 0));
        v2_positionMax = camera.ViewportToWorldPoint(new Vector2(1, 1));
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        Vector3 move = v2_inputSystem*speed*Time.deltaTime;
        float move_x = Mathf.Clamp(transform.position.x + move.x, v2_positionMin.x + padding, v2_positionMax.x - padding);
        float move_y = Mathf.Clamp(transform.position.y + move.y, v2_positionMin.y + padding, v2_positionMax.y - padding);
        transform.position = new Vector3(move_x, move_y, 0);
    }

    void OnMove(InputValue inputSystem)
    {
        v2_inputSystem = inputSystem.Get<Vector2>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Dame dame = collision.transform.GetComponent<Dame>();
        if(dame != null && dame.IsActive)
        {
            information.AddDame(dame.GetDame());
            if(information.GetHp() == 0)
            {
                Debug.Log("Die");
            }
            CameraShake cameraShake = Camera.main.GetComponent<CameraShake>();
            if(cameraShake != null )
            {
                cameraShake.Play();
            }
            else
            {
                Debug.Log("Not find cameraShake");
            }
            //Debug.Log(information.GetHp());
            dame.IsActive = false;
            Destroy(collision.gameObject);
        }
        else
        {
            Debug.Log("Not find Dame");
        }
    }
}
