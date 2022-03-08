using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class playBackground : MonoBehaviour
{
    public TextMeshProUGUI textMeshPoint;
    public TextMeshProUGUI textMeshLife;
    public void playScreenSetActiveTrue()
    {

        gameObject.SetActive(true);

    }

    public void playScreenSetActiveFalse()
    {
        Debug.Log("play e basildi");
        
        gameObject.SetActive(false);

    }
    public void plusLife()
    {
        if (PlayerPrefs.GetInt("Diamond") > 19)
        {
            PlayerPrefs.SetInt("Diamond" , PlayerPrefs.GetInt("Diamond") - 20);
            textMeshPoint.text = PlayerPrefs.GetInt("Diamond").ToString();
            PlayerPrefs.SetInt("Life", PlayerPrefs.GetInt("Life") + 1);
            textMeshLife.text = PlayerPrefs.GetInt("Life").ToString();
        }
        

    }
    public void plusEarnDiamond()
    {
        if (PlayerPrefs.GetInt("Diamond") > 19)
        {
            PlayerPrefs.SetInt("Diamond", PlayerPrefs.GetInt("Diamond") - 20);
            textMeshPoint.text = PlayerPrefs.GetInt("Diamond").ToString();

            PlayerPrefs.SetInt("dimaondEarnMultiple", PlayerPrefs.GetInt("dimaondEarnMultiple") + 1);
        }
    }


    public void ResetAllKey()
    {
        PlayerPrefs.SetInt("dimaondEarnMultiple", 1);
        PlayerPrefs.SetInt("Diamond", 0);
        PlayerPrefs.SetInt("Life", 3);

        textMeshPoint.text = PlayerPrefs.GetInt("Diamond").ToString();
        textMeshLife.text = PlayerPrefs.GetInt("Life").ToString();
    }
}
