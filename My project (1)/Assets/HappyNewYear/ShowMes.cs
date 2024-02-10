using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowMes : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI txtMes;
    [SerializeField] GameObject goImg;

    // Start is called before the first frame update
    public void SetMes(string mes, bool isMes)
    {
        if(isMes)
        {
            txtMes.text = mes;
            goImg.SetActive(false);
        }
        else
        {
            txtMes.gameObject.SetActive(false);
            goImg.SetActive(true);
        }
    }
    public void DestroyGame()
    {
        Destroy(gameObject);
    }
}
