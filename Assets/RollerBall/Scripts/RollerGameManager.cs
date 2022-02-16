using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RollerGameManager : Singleton<RollerGameManager>
{
	enum State
	{
		TITLE,
		PLAYER_START,
		GAME,
		PLAYER_DEAD,
		GAME_OVER,
		GAME_WON
	}

	[SerializeField] GameObject playerPrefab;
	[SerializeField] Transform playerSpawn;
	[SerializeField] GameObject mainCamera;

	[SerializeField] GameObject titleScreen;
	[SerializeField] GameObject gameOverScreen;
	[SerializeField] GameObject gameWonScreen;
	[SerializeField] TMP_Text scoreUI;
	[SerializeField] TMP_Text livesUI;
	[SerializeField] TMP_Text timeUI;
	[SerializeField] Slider healthBarUI;

	[SerializeField] float scoreBarrier = 380;

	public float playerHealth{set{healthBarUI.value = value;}}
	public float playerMaxHealth{set{healthBarUI.maxValue = value;}}


	public delegate void GameEvent();

	public event GameEvent startGameEvent;
	public event GameEvent stopGameEvent;

	int score = 0;
	int lives;
	State state = State.TITLE;
	float stateTimer;
	float gameTime = 0;

	public int Score
	{
		get { return score; }
		set
		{
			score = value;
			scoreUI.text = "Score: " + score.ToString("D2");
		}
	}

	public int Lives
	{
		get { return lives; }
		set
		{
			lives = value;
			livesUI.text = "Lives: " +  lives.ToString();
		}
	}

	public float GameTime
	{
		get { return gameTime; }
		set
		{
			gameTime = value;
			timeUI.text = "<mspace=mspace=40>Time: " + gameTime.ToString("0.0") + "</mspace>";
		}
	}

	private void Start()
    {
		stopGameEvent += DestroyAllEnemies;
    }

    private void Update()
    {
		stateTimer -= Time.deltaTime;
		

        switch (state)
        {
            case State.TITLE:
                break;
            case State.PLAYER_START:
                OnPlayerStart();
                break;
            case State.GAME:
				GameTime -= Time.deltaTime;

				if (gameTime <= 0)
				{
					GameTime = 0;
					state = State.GAME_OVER;
					Lives = 1;
					mainCamera.SetActive(true);
					GameObject.FindGameObjectWithTag("Player").GetComponent<Health>().Damage(GameObject.FindGameObjectWithTag("Player").GetComponent<Health>().health);
				}

				if(score >= scoreBarrier)
                {
					GameTime = 0;
					state = State.GAME_WON;
					stateTimer = 5;
					Lives = 1;
					GameObject.FindGameObjectWithTag("Player").GetComponent<Health>().Damage(GameObject.FindGameObjectWithTag("Player").GetComponent<Health>().health);
					gameWonScreen.SetActive(true);
					mainCamera.SetActive(true);
                }

				break;
            case State.PLAYER_DEAD:
				if(stateTimer <= 0) state = State.PLAYER_START;
				mainCamera.SetActive(true);
                break;
            case State.GAME_OVER:
				if (stateTimer <= 0)
				{
					state = State.TITLE;
					gameOverScreen.SetActive(false);
					OnStartTitle();
				}
                break;
			case State.GAME_WON:
				if (stateTimer <= 0)
				{
					state = State.TITLE;
					gameWonScreen.SetActive(false);
					OnStartTitle();
				}
				break;
			default:
                break;
        }
    }

    private void OnPlayerStart()
    {
		DestroyAllEnemies();
        Instantiate(playerPrefab, playerSpawn.position, playerSpawn.rotation);
        mainCamera.SetActive(false);
        startGameEvent?.Invoke();
        state = State.GAME;
        GameTime = 60;
    }

    public void OnStartGame()
	{
		
		Score = 0;
		Lives = 3;
		titleScreen.SetActive(false);
		OnPlayerStart();


		startGameEvent?.Invoke();
	}

	public void OnStartTitle()
	{
		state = State.TITLE;
		titleScreen.SetActive(true);
		stopGameEvent?.Invoke();
	}

	public void OnPlayerDead()
    {
		Lives = lives - 1;
		if(lives == 0)
        {
			if (state != State.GAME_WON) {
				state = State.GAME_OVER;
				stateTimer = 5;
				gameOverScreen.SetActive(true);
				mainCamera.SetActive(true);
			}
        }
        else
        {
			state = State.PLAYER_DEAD;
			stateTimer = 3;
        }

		stopGameEvent();
	}

	private void DestroyAllEnemies()
	{
		// destroy all enemies
/*		var spaceEnemies = FindObjectsOfType<SpaceEnemy>();
		foreach (var spaceEnemy in spaceEnemies)
		{
			Destroy(spaceEnemy.gameObject);
		}*/

	}
}