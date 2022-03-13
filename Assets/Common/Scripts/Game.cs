using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Game : Singleton<Game>
{
	enum State
	{
		TITLE,
		PLAYER_START,
		GAME,
		PLAYER_DEAD,
		GAME_OVER
	}

	
	[SerializeField] ScreenFade screenFade;
	[SerializeField] AudioClip musicClip;

	public GameData gameData;

	State state = State.TITLE;
	int highScore;

	private void Start()
	{
		highScore = PlayerPrefs.GetInt("highscore", 0);
		highScore++;
		PlayerPrefs.SetInt("highscore", highScore);

		//print(highScore);
		PlayerPrefs.DeleteAll();
		PlayerPrefs.DeleteKey("highscore");

		AudioManager.Instance.PlayMusic(musicClip);
	}

	private void Update()
	{
		switch (state)
		{
			case State.TITLE:
				break;
			case State.PLAYER_START:
				break;
			case State.GAME:
				break;
			case State.PLAYER_DEAD:
				break;
			case State.GAME_OVER:
				break;
			default:
				break;
		}
	}
	
	public void OnLoadScene(string sceneName)
    {
		StartCoroutine(LoadScene(sceneName));
    }

	public void OnPlayerDead()
    {

    }

	IEnumerator LoadScene(string sceneName)
    {
		screenFade.FadeOut();
		yield return new WaitUntil(() => screenFade.isDone);
		SceneManager.LoadScene(sceneName);
		screenFade.isDone = false;
		screenFade.FadeIn();
    }
}
