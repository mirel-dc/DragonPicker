using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
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
        GameObject scoreBO = GameObject.Find("Score");
        scoreBest = scoreBO.GetComponent<TextMeshProUGUI>();
        scoreBest.text ="Best Score:" + YandexGame.savesData.bestScore.ToString();
    }
}
