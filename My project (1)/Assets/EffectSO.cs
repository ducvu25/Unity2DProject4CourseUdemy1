using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Effect player", fileName = "Effect/Effect 1")]
public class EffectSO : ScriptableObject
{
    [SerializeField] string id;
    [SerializeField] Sprite hub;
    [SerializeField] string information;
    [SerializeField] EFFECT effect;
    [SerializeField] float timeALive;

    public string Id
    {
        get { return id; }
        set { id = value; }
    }
    public Sprite Hub
    {
        get { return hub; }
        set { hub = value; }
    }

    public string Information
    {
        get { return information; }
        set { information = value; }
    }

    public EFFECT Effect
    {
        get { return effect; }
        set { effect = value; }
    }

    public float TimeAlive
    {
        get { return timeALive; }
        set { timeALive = value; }
    }
}
