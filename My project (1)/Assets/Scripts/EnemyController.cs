using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Heath heath;
    [SerializeField] ParticleSystem particleSystem;

    private void Awake()
    {
        heath = GetComponent<Heath>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Dame dame = collision.transform.GetComponent<Dame>();
        if(dame != null && dame.IsActive)
        {
            dame.IsActive = false;
            if (!heath.AddDame(dame.GetDame()))
            {
                ParticleSystem instace = Instantiate(particleSystem, transform.position, Quaternion.identity);
                Destroy(instace, instace.main.duration + instace.main.startLifetime.constantMax);
                Destroy(gameObject);
            }
        }
        if(dame == null)
        {
            Debug.Log("Not DAME");
        }
    }
}
