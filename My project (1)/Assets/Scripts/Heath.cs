using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heath : MonoBehaviour
{
    [SerializeField] int hpMax = 50;
    int hp;
    // Start is called before the first frame update
    void Start()
    {
        hp = hpMax;
    }
    public bool AddDame(int value)
    {
        hp -= value;
        if (hp < 0)
        {
            hp = 0;
            return false;
        }
        return true;
    }
    public int GetHp()
    {
        return hp;
    }
}
