using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    WageConfigSO wageConfigSO;
    List<Transform> pathTransforms;
    int index;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        SetUp();
    }
    void SetUp()
    {
        wageConfigSO = FindObjectOfType<EnemisSpawn>().GetWage();
        pathTransforms = wageConfigSO.Paths();
        index = 1;
        speed = wageConfigSO.Speed;
        transform.position = new Vector2(pathTransforms[0].position.x, pathTransforms[0].position.y);
    }

    // Update is called once per frame
    void Update()
    {
        FindPath();
    }
    void FindPath()
    {
        if(index < pathTransforms.Count)
        {
            Vector3 targetPosition = pathTransforms[index].position;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed*Time.deltaTime);
            if(transform.position == targetPosition )
            {
                index++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
