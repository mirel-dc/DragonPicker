using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class CheckConnectYG : MonoBehaviour
{
    private void OnEnable() => YandexGame.GetDataEvent += CheckSDK;
    private void OnDisable() => YandexGame.GetDataEvent -= CheckSDK;

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
    }
}
