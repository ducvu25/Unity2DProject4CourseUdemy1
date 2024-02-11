using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaoController : MonoBehaviour
{
    [SerializeField] GameObject goPre;
    [SerializeField] float timeSpawn;
    float _timeSpawn;
    Vector2 v2_positionMin, v2_positionMax;
    public static bool startGame;
    // Start is called before the first frame update
    void Start()
    {
        startGame = false;
        InitLimit();
        _timeSpawn = 0.5f;
    }
    void InitLimit()
    {
        Camera camera = Camera.main;
        v2_positionMin = camera.ViewportToWorldPoint(new Vector2(0, 0));
        v2_positionMax = camera.ViewportToWorldPoint(new Vector2(1, 1));
    }
    // Update is called once per frame
    void Update()
    {
        if (!startGame) return;
        if(_timeSpawn > 0)
        {
            _timeSpawn -= Time.deltaTime;
        }
        else
        {
            _timeSpawn = timeSpawn;
            Spawn();
        }
    }
    void Spawn()
    {
        for (int i = 0; i < (int)Random.Range(6, 10); i++)
        {
            AudioController.instance.Play(1, 1);
            Instantiate(goPre, new Vector3(Random.Range(v2_positionMin.x, v2_positionMax.x), Random.Range(v2_positionMax.y, v2_positionMax.y + (v2_positionMax.y - v2_positionMin.y) / 2), 0), Quaternion.identity);
        }
    }
    public void Exit()
    {
        Application.Quit();
    }
}
