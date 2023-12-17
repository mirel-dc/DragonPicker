using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using YG;

public class CheckConnectYG : MonoBehaviour
{
    private void OnEnable() => YandexGame.GetDataEvent += CheckSDK;
    private void OnDisable() => YandexGame.GetDataEvent -= CheckSDK;
    private TextMeshProUGUI scoreBest;

    void Start()
    {
       if (YandexGame.SDKEnabled)
        {
            CheckSDK();
        }
    }


    public void CheckSDK()
    {
        if (YandexGame.auth)
        {
            Debug.Log("User authorizated");
        }
        else
        {
            Debug.Log("User not authorizated");
            YandexGame.AuthDialog();
        }
        GameObject scoreBO = GameObject.Find("BestScore");
        scoreBest = scoreBO.GetComponent<TextMeshProUGUI>();
        scoreBest.text = "Best Score: " + YandexGame.savesData.bestScore.ToString();

        //if (YandexGame.savesData.achivMent[0] == null & !GameObject.Find("ListAchiv"))
        //{
        //     
        //}
        //else
        //{
        //    foreach (string value in YandexGame.savesData.achivMent)
        //    {
        //        GameObject.Find("ListAchiv").GetComponent<TextMeshProUGUI>().text = GameObject.Find("ListAchiv").GetComponent<TextMeshProUGUI>().text + value + "\n";
        //    }
        //}
    }
}
