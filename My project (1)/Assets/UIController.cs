using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] GameObject goMenu;
    [SerializeField] TextMeshProUGUI txtCoin, txtScore;
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
}
