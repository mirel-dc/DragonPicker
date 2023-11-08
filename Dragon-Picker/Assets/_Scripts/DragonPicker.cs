using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using YG;
using TMPro;

public class DragonPicker : MonoBehaviour
{
    private void OnEnable() => YandexGame.GetDataEvent += GetLoadSave;
    private void OnDisable() => YandexGame.GetDataEvent -= GetLoadSave;

    public GameObject energyShieldPrefab;
    public int numEnergyShield = 3;
    public float energyShieldBottomY = -6f;
    public float energyShieldRaduis = 1.5f;

    public TextMeshProUGUI scoreGT;
    public TextMeshProUGUI playerName;

    public List<GameObject> shieldList;

    void Start()
    {
        if (YandexGame.SDKEnabled)
        {
            GetLoadSave();
        }


        for (int i = 1; i <= numEnergyShield; i++)
        {
            GameObject tShieldGo = Instantiate<GameObject>(energyShieldPrefab);
            tShieldGo.transform.position = new Vector3(0,energyShieldBottomY,0);
            tShieldGo.transform.localScale = new Vector3(1*i, 1*i, 1*i);
            shieldList.Add(tShieldGo);
        }

        GameObject playerNamePrefabGUI = GameObject.Find("PlayerName");
        playerName = playerNamePrefabGUI.GetComponent<TextMeshProUGUI>();
        playerName.text = YandexGame.playerName;
        Debug.Log(YandexGame.playerName);
    }

    void Update()
    {
        
    }

    public void DragonEggDestroyed()
    {
        GameObject[] tDragonEggArray = GameObject.FindGameObjectsWithTag("Dragon Egg");
        foreach(GameObject tGO in tDragonEggArray)
        {
            Destroy(tGO);
        }
        int shiledIndex = shieldList.Count - 1;
        GameObject tShieldGo = shieldList[shiledIndex];
        shieldList.RemoveAt(shiledIndex);
        Destroy(tShieldGo);

        if (shieldList.Count == 0)
        {
            GameObject scoreGo = GameObject.Find("Score");
            scoreGT = scoreGo.GetComponent<TextMeshProUGUI>();
            UserSave(int.Parse(scoreGT.text),YandexGame.savesData.bestScore);
            YandexGame.NewLeaderboardScores("TopPlayerScore", int.Parse(scoreGT.text));
            SceneManager.LoadScene("_0Scene");
            GetLoadSave();
        }
    }

    public void GetLoadSave()
    {
        Debug.Log(YandexGame.savesData.score);
        
    }

    public void UserSave(int currentScore,int currentBestScore)
    {
        YandexGame.savesData.score = currentScore;
        if (currentScore > currentBestScore) YandexGame.savesData.bestScore = currentBestScore;
        YandexGame.SaveProgress();
    }
}
