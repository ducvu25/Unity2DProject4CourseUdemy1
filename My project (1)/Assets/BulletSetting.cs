using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSetting : MonoBehaviour
{
    [SerializeField] BulletSO bulletSO;

    public BulletSO GetBulletSO() { return bulletSO; }  
}
