using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Heath heath;
    [SerializeField] ParticleSystem particleSystem;
    int score = 5;

    private void Awake()
    {
        heath = GetComponent<Heath>();
        score = FindObjectOfType<EnemisSpawn>().GetWage().Score;
    }
    // Start is called before the first frame update
/*    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }*/
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Dame dame = collision.transform.GetComponent<Dame>();
        if(dame != null && dame.IsActive)
        {
            dame.IsActive = false;
            if (!heath.AddDame(dame.GetDame()))
            {
                Destroy(gameObject);
                GameController gameController = FindAnyObjectByType<GameController>();
                /*if ((int)Random.Range(0, 3) == 2)
                {*/
                    gameController.NewItem(transform.position);
                //}
                gameController.AddScore(score);
            }
            ParticleSystem instace = Instantiate(particleSystem, transform.position, Quaternion.identity);
            Destroy(instace.gameObject, instace.main.duration + instace.main.startLifetime.constantMax);
        }
        if (dame == null)
        {
            Debug.Log("Not DAME");
        }
    }
}
