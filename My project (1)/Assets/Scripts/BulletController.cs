using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] float delaySpawn = 0;
    BulletSO bulletSO;
    // Start is called before the first frame update
/*    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }*/

    public float GetDelaySpawn()
    {
        return delaySpawn;  
    }
    public void SetType(int value)
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            //Debug.Log(i);
            if(i != value)
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }
            else
            {
                bulletSO = transform.GetChild(i).GetComponent<BulletSetting>().GetBulletSO();
                if(bulletSO != null )
                {
                    transform.GetChild(i).GetComponent<Dame>().SetDame(bulletSO.Damege);
                    transform.GetComponent<Rigidbody2D>().velocity = bulletSO.Speed;
                    delaySpawn = bulletSO.TimeSpawn;
                    //Debug.Log(transform.GetComponent<Rigidbody2D>().velocity);
                    Destroy(gameObject, bulletSO.TimeALive);
                }
                else
                {
                    Debug.Log("NULL BULLET");
                }
            }
        }
    }
}
