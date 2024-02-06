using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dame : MonoBehaviour
{
    int dame = 10;
    bool isActive = true;
    public int GetDame() { return dame; }
    public void SetDame(int dame)
    {
        this.dame = dame;
    }
    public bool IsActive
    {
        get { return isActive; }
        set { isActive = value; }
    }
}
