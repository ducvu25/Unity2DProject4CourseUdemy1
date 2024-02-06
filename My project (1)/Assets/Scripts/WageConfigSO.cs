using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

[CreateAssetMenu(menuName ="Wage", fileName = "Enemy/Wage")]
public class WageConfigSO : ScriptableObject
{
    [SerializeField] GameObject goPrefabs;
    [SerializeField] int number;
    [SerializeField] Transform path;
    [SerializeField] float speed;
    [SerializeField] float delaySpawn = 0.5f;
    [SerializeField] float delayNew = 1f;
    public Transform PathHeader
    {
        get { return path.GetChild(0).transform; }
    }
    public List<Transform> Paths()
    {
        List<Transform> result = new List<Transform>();
        foreach(Transform i in path)
        {
            result.Add(i);
        }
        return result;
    }
    public GameObject GoGameObject
    {
        get { return goPrefabs; }
    }
    public int Number
    {
        get { return number; }
    }
    public float Speed
    {
        get { return speed; }
    }
    public float DelaySpawn
    {
        get { return delaySpawn; }
    }
    public float DelayNew {
        get { return delayNew; }
    }
}
