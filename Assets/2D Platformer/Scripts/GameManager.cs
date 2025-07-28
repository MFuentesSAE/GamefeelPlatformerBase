using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace Platformer
{
    public class GameManager : MonoBehaviour
    {
        public int coinsCounter = 0;

        [Range(0, 10)]
        public int coinsToCollect = 1;

        public GameObject playerGameObject;
        private PlayerController player;
        public GameObject deathPlayerPrefab;
        public TextMeshProUGUI coinText;
        public UnityEvent onGameWinEvents;

        public static GameManager instance;

		private void Awake()
		{
            instance = this;
		}

		void Start()
        {
            player = playerGameObject.GetComponent<PlayerController>();
            coinsCounter = 0;
			coinText.text = coinsCounter.ToString();
		}

        public void AddCoins(int amount)
        {
            coinsCounter += amount;
			coinText.text = coinsCounter.ToString();
            if(coinsCounter >= coinsToCollect)
            {
                GameWon();
            }
		}

        public void GameOver()
        {
			playerGameObject.SetActive(false);
			GameObject deathPlayer = Instantiate(deathPlayerPrefab, playerGameObject.transform.position, playerGameObject.transform.rotation);
			deathPlayer.transform.localScale = new Vector3(playerGameObject.transform.localScale.x, playerGameObject.transform.localScale.y, playerGameObject.transform.localScale.z);
            EndGame();
		}

        public void GameWon()
        {
            onGameWinEvents?.Invoke();
			StartCoroutine(LoadSceneRoutine(2, 0));
		}

        private void EndGame()
        {
            StartCoroutine(LoadSceneRoutine(2, 1));
        }

       IEnumerator LoadSceneRoutine(float waitTime, int sceneToLoad)
        {
            yield return new WaitForSeconds(waitTime);
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
