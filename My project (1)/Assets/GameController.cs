using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    UIController uIController;
    int score;
    int coin;
    public static bool pause;

    private void Awake()
    {
        uIController = GetComponent<UIController>();
    }
    private void Start()
    {
        pause = false;
        coin = 0;
        score = 0;
        uIController.SetCoin(coin);
        uIController.SetScore(score);
    }
    public void UpdateScore(int value)
    {
        score += value;
        uIController.SetScore(score);
    }
    public void UpdateCoin(int value)
    {
        coin += value;
        uIController.SetCoin(coin);
    }
    public void PauseGame(bool value)
    {
        pause = value;
        SetPauseObject(value);
        /*if (value)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }*/
        uIController.ShowMenuPause(pause);
    }
    void SetPauseObject(bool value)
    {
        Rigidbody2D[] rigidbody2Ds = FindObjectsOfType<Rigidbody2D>();
        foreach (Rigidbody2D rb in rigidbody2Ds)
        {
            rb.isKinematic = !value;
        }
    }
}
