using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ITemSetting : MonoBehaviour
{
    [SerializeField] EFFECT type;
    bool isUse = true;
    public EFFECT Type
    {
        set { type = value; }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && isUse)
        {
            isUse = false;
            FindAnyObjectByType<GameController>().AddEffect(type);
            Destroy(gameObject);
            Debug.Log("add");
            return;
        }
        if (collision.CompareTag("LimitMap")){
            Destroy(gameObject);
        }
    }
}
