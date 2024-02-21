using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] Canvas canvas;
    [SerializeField] GameObject goMenu;
    [SerializeField] TextMeshProUGUI txtCoin, txtScore;

    [Header("\n\n          GO effect           \n")]
    [SerializeField] GameObject goEffect;
    [SerializeField] Transform parentEffect;

    [SerializeField] GameObject goBullet;
    // Start is called before the first frame update
    void Start()
    {
        goMenu.SetActive(false);
    }
    public void SetScore(int value)
    {
        txtScore.text = string.Format("{0:000000}", value);
    }
    public void SetCoin(int value)
    {
        txtCoin.text = value.ToString();
    }
    public void ShowMenuPause(bool value)
    {
        if (value)
        {
            goMenu.SetActive(true);
        }
        else
        {
            Animator animator = goMenu.GetComponent<Animator>();
            animator.SetTrigger("Off");
            RuntimeAnimatorController controller = animator.runtimeAnimatorController;
            float delayOff = 0.5f;
            for (int i = 0; i < controller.animationClips.Length; i++)
            {
                if (controller.animationClips[i].name == "SettingPlay 0")
                {
                    delayOff = controller.animationClips[i].length;
                    break;
                }
            }
            Invoke("OffMenu", delayOff);
        }
    }
    void OffMenu()
    {
        goMenu.SetActive(false);
    }
    private void Update()
    {
        for(int i=0; i< parentEffect.childCount; i++)
        {
            GameObject go = parentEffect.GetChild(i).gameObject;
            go.transform.GetComponent<Slider>().value -= Time.deltaTime;
            go.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = ((int)go.transform.GetComponent<Slider>().value).ToString() + "s";
            if(go.transform.GetComponent<Slider>().value <= 0)
            {
                Destroy(go.gameObject);
            }
        }
    }
    public void AddEffect(EffectSO effectSO)
    {
        string name = "Effect" + effectSO.Id;
        for (int j = 0; j < parentEffect.childCount; j++)
        {
            //Debug.Log(parentEffect.GetChild(j).transform.name);
            if (parentEffect.GetChild(j).transform.name == name)
            {
                parentEffect.GetChild(j).transform.GetComponent<Slider>().value = effectSO.TimeAlive;
                parentEffect.GetChild(j).transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = ((int)effectSO.TimeAlive).ToString() + "s";
                return;
            }
        }
        GameObject go = Instantiate(goEffect);
        go.transform.name = name;
        go.transform.SetParent(parentEffect);
        go.transform.position = Vector3.zero;

        go.transform.GetChild(0).GetComponent<Image>().sprite = effectSO.Hub;
        go.transform.GetChild(1).GetChild(0).GetComponent<Image>().sprite = effectSO.Hub;
        go.transform.GetComponent<Slider>().maxValue = effectSO.TimeAlive;
        go.transform.GetComponent<Slider>().value = effectSO.TimeAlive;
        go.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = ((int)effectSO.TimeAlive).ToString() + "s";
    }

}
