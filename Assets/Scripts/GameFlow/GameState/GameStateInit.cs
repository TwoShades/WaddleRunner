using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStateInit : GameState
{
    public GameObject menuUI;
    [SerializeField] private TextMeshProUGUI highscoreText;
    [SerializeField] private TextMeshProUGUI fishCountText;

    public override void Construct()
    {
        GameManager.Instance.ChangeCamera(GameCamera.Init);

        highscoreText.text = "Highscore: " + SaveManager.Instance.save.Highscore.ToString();
        fishCountText.text = "Fish :" + SaveManager.Instance.save.Fish.ToString();

        menuUI.SetActive(true);
    }

    public override void Destruct()
    {
        menuUI.SetActive(false);
    }

    public void OnPlayClick()
    {
        brain.ChangeState(GetComponent<GameStateGame>());
        GameStats.Instance.ResetSession();
    }

    public void OnShopClick()
    {
        brain.ChangeState(GetComponent<GameStateShop>());
        Debug.Log("Shop Button has been clicked!");
    }
}
