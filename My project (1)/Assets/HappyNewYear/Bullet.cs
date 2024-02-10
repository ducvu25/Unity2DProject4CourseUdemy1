using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] Vector2 timeALive;
    [SerializeField] GameObject goMessPre;
    [SerializeField] Vector2 velocity;
    Rigidbody2D rb;   
    float time;
    // Start is called before the first frame update
    void Start()
    {
        time = Random.Range(timeALive.x, timeALive.y);
        rb = GetComponent<Rigidbody2D>();

        rb.velocity = new Vector2(0, Random.Range(velocity.x, velocity.y));
    }

    // Update is called once per frame
    void Update()
    {
        if(time > 0)
        {
            time -= Time.deltaTime;
        }
        else
        {
            GameObject go = Instantiate(goMessPre, transform.position, Quaternion.identity);
            ShowMes showMes = go.GetComponent<ShowMes>();
            ShipController shipController = FindObjectOfType<ShipController>();
            string mes = shipController.GetMes();
            if(mes != "")
            {
                showMes.SetMes(mes, true);
            }
            else
            {
                showMes.SetMes("", false);
            }
            Destroy(gameObject);
        }
    }
}
