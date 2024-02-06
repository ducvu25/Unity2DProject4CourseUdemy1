using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Bullet", fileName = "Bullets/Bullet")]
public class BulletSO : ScriptableObject
{
    [SerializeField] float timeSpawn = 2;
    [SerializeField] float timeALive = 5;
    [SerializeField] int dame = 10;
    [SerializeField] Vector2 speed;

    public float TimeSpawn
    {
        get { return timeSpawn; }
    }
    public float TimeALive
    {
        get { return timeALive; }
    }
    public int Damege
    {
        get { return dame; }
    }
    public Vector2 Speed
    {
        get { return speed; }
    }
}
