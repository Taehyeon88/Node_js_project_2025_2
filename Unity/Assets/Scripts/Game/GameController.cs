using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameView gameView;
    public PlayerModel playerModel;
    private GameAPI gameAPI;

    private void Start()
    {
        gameAPI = gameObject.GetComponent<GameAPI>();
        gameView.SetRegisterButtonLisenter(OnRegisterButtonClicked);
        gameView.SetLoginButtonListener(OnLoginButtonClicked);
    }

    public void OnRegisterButtonClicked()
    {
        string playerName = gameView.playerNameInput.text;
        Debug.Log(playerName);
        StartCoroutine(gameAPI.RegisterPlayer(playerName, "1234"));         //예시 (유저 이름과 비번)에
    }

    public void OnLoginButtonClicked()
    {
        string playerName = gameView.playerNameInput.text;
        StartCoroutine(LoginPlayerCoroutine(playerName, "1234"));         //예시 (유저 이름과 비번)
    }

    private IEnumerator LoginPlayerCoroutine(string playerName, string password)
    {
        yield return gameAPI.LoginPlayer(playerName, password, player =>
        {
            playerModel = player;
            UpdateResourcesDisplay();
        });
    }

    private void UpdateResourcesDisplay()
    {
        if (playerModel != null)
        {
            gameView.SetPlayerName(playerModel.playerName);
            gameView.UpdateResources(playerModel.metal, playerModel.crystal, playerModel.deuterium);
        }
    }
}
