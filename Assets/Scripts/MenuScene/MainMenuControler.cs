using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuControler : MonoBehaviour {


    public void _CharacterButton()
    {
        SceneManager.LoadScene("HeroesScene");
    }

    public void _CurrencyButton()
    {
        SceneManager.LoadScene("CoinStoreScene");
    }

    public void _GachaButton()
    {
        SceneManager.LoadScene("GachaScene");
    }

    public void _PlayButton()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void _RewardButton()
    {
        SceneManager.LoadScene("RewardScene");
    }

    public void _SettingButton()
    {
        SceneManager.LoadScene("SettingScene");
    }

    public void _WheelButton()
    {
        SceneManager.LoadScene("WheelScene");
    }
}
