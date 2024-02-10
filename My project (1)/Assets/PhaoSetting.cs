using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaoSetting : MonoBehaviour
{
    [SerializeField] GameObject goPre;
    [SerializeField] int anpha = 5;
    public int level;
    // Start is called before the first frame update

    // Update is called once per frame
    public void Destroy()
    {
        if(level < 4)
        {
            int x = (int)Random.Range(0, 3);
            if (x == 1)
            {
                for (int i = 0; i < (int)Random.Range(2, 4); i++)
                {
                    for (int j = 0; j < 360; j += anpha)
                    {
                        GameObject go = Instantiate(goPre, transform.position, Quaternion.Euler(0, 0, j));
                        PhaoSetting phaoSetting = go.GetComponent<PhaoSetting>();
                        phaoSetting.level = level + 1;
                    }
                }
            }
        }
        Destroy(gameObject);
    }
}
