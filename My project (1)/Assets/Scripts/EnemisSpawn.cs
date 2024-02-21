using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemisSpawn : MonoBehaviour
{
    [SerializeField] List<WageConfigSO> wageConfigSOs;
    WageConfigSO wage;
    public bool continueGame = true;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator Spawn()
    {
        
        while (continueGame)
        {
            foreach (WageConfigSO wageConfigSO in wageConfigSOs)
            {
                wage = wageConfigSO;
                for (int i = 0; i < wageConfigSO.Number; i++)
                {
                    Instantiate(wageConfigSO.GoGameObject,
                                wageConfigSO.PathHeader.position,
                                Quaternion.identity);
                    yield return new WaitForSeconds(wage.DelaySpawn);
                }
                yield return new WaitForSeconds(wage.DelayNew);
            }
        }
    }
    public WageConfigSO GetWage()
    {
        return wage;
    }
}
