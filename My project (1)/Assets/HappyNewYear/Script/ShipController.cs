using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    [SerializeField] GameObject goBullet;
    [SerializeField] Transform poGun;
    [SerializeField] float speed;
    [SerializeField] float delayReset;
    float _delayReset;
    [SerializeField] float delaySpawn;
    float _delaySpawn;
    int value;
    string[] mes = { "Chúc", "Mừng", "Năm", "Mới", "2024", "",
        "Chúc năm mới,\nNiềm vui đến tận trái tim.",
        "Sức khỏe tràn đầy,\nMãi mãi trẻ trung và khỏe mạnh.",
        "Thành công ngập tràn,\nCông việc thuận lợi.",
        "Hạnh phúc sum vầy.\nGia đình hòa thuận,\nTình yêu mãi mãi bền vững."};
    Rigidbody2D rigidbody2D;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        _delayReset = 0;
        _delaySpawn = 0;
        value = 0;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Run(-1);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            Run(1);
        }
        else
        {
            Run(0);
        }
        if (Input.GetKeyDown(KeyCode.Space) && _delaySpawn <= 0)
        {
            ShowMes();
        }
        if(_delayReset > 0)
        {
            _delayReset -= Time.deltaTime;
        }
        else
        {
            if(value < 5) 
                value = 0;
        }
        if(_delaySpawn > 0)
        {
            _delaySpawn -= Time.deltaTime;
        }
    }
    void ShowMes()
    {
        _delaySpawn = delaySpawn;
        Instantiate(goBullet, poGun.position, Quaternion.identity);
        AudioController.instance.Play(1, 1);
        _delayReset = delayReset;
    }
    public string GetMes()
    {
        if (value == 5)
        {
            if (!PhaoController.startGame)
                PhaoController.startGame = true;
        }
        if(value == mes.Length)
        {
            value = 0;
        }
        return mes[value++];
    }
    void Run(int value)
    {
        rigidbody2D.velocity = new Vector2(speed * value, 0);
    }
}
