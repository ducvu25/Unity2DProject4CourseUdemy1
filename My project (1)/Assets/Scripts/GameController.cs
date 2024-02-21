using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameController : MonoBehaviour
{
    UIController uIController;
    int score;
    int coin;
    [HideInInspector]
    public static bool pause;

    [Header("\n\n --------- EFFECT PLAYER ------ \n")]
    [SerializeField] List<EffectSO> effectSOs;
    [SerializeField] GameObject goItempre;


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
    public void AddScore(int value)
    {
        score += value;
        uIController.SetScore(score);
    }
    public void AddCoin(int value)
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
    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            AddEffect(effectSOs[(int)Random.Range(0, effectSOs.Count)].Effect);
        }
    }
    public void AddEffect(EFFECT e)
    {
        if(e == EFFECT.coin)
        {
            AddCoin((int)Random.Range(20, 100));
            return;
        }
        uIController.AddEffect(effectSOs[(int)e]);
    }
    public void NewItem(Vector3 p)
    {
        GameObject gameObject = Instantiate(goItempre, p, Quaternion.identity);
        int index = (int)Random.Range(0, effectSOs.Count);
        gameObject.transform.GetComponent<SpriteRenderer>().sprite = effectSOs[index].Hub;
        gameObject.transform.GetComponent<ITemSetting>().Type = effectSOs[index].Effect;
    }
}
