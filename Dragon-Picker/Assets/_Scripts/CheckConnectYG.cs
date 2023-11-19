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

        Debug.Log("ach"+ YandexGame.savesData.achivMent);
        Debug.Log("find"+ GameObject.Find("ListAchiv"));

        if (!(YandexGame.savesData.achivMent[0] == null) & GameObject.Find("ListAchiv"))
        {
            foreach (string value in YandexGame.savesData.achivMent)
            {
                Debug.Log($"{value}");
                GameObject.Find("ListAchiv").GetComponent<TextMeshProUGUI>().text = GameObject.Find("ListAchiv").GetComponent<TextMeshProUGUI>().text + value + "\n";
            }
        }
        else
        {
        }

    }
}
