using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject bulletPre;
    [SerializeField] Transform poSpawn;
    int type = 0;

    [SerializeField] bool isAI;
    [SerializeField] float deltaDelay = 0.5f;

    [HideInInspector] public bool isFiring;

    Coroutine coroutine;
    // Start is called before the first frame update
    void Start()
    {
        type = 0;
        isFiring = true;
        coroutine = null;
    }

    // Update is called once per frame
    void Update()
    {
        Fire();
    }

    void Fire()
    {
        if(isFiring && coroutine == null)
        {
            coroutine = StartCoroutine(Spawn());
        }
        else if(!isFiring && coroutine != null) 
        {
            StopCoroutine(coroutine);
            coroutine = null;
        }
    }
    float delay = 0.5f;
    IEnumerator Spawn()
    {
        bool stop = false;
        while(!stop)
        {
            GameObject go = Instantiate(bulletPre, poSpawn.position, Quaternion.identity);
            BulletController bulletController = go.transform.GetComponent<BulletController>();
            if (bulletController != null)
            {
                bulletController.SetType(type);
                delay = bulletController.GetDelaySpawn();
                Debug.Log(delay);
            }
            else
            {
                stop = true;
                Debug.Log("Not find BulletController");
            }
            if (isAI)
                delay = Ran(delay);
            yield return new WaitForSeconds(delay);
        }
    }

    float Ran(float value)
    {
        float result = Random.Range(value - deltaDelay, value + deltaDelay);
        result = Mathf.Clamp(result, 0.5f, float.MaxValue);
        return result;
    }
}
