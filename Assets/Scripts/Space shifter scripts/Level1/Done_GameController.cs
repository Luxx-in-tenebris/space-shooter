using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Done_GameController : MonoBehaviour
{
	public GameObject[] hazards;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	
	public Text scoreText;
    public Text scoreText1;
    public GameObject Game_Over;
	
	private bool gameOver;
	private int score;
	
	void Start ()
	{
		gameOver = false;
        Game_Over.SetActive(false);
		score = 0;
		UpdateScore ();
		StartCoroutine (SpawnWaves ());
	}	
	
	IEnumerator SpawnWaves ()
	{
		yield return new WaitForSeconds (startWait);
		while (true)
		{
			for (int i = 0; i < hazardCount; i++)
			{
				GameObject hazard = hazards [Random.Range (0, hazards.Length)];
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazard, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);
			
			if (gameOver)
			{
                
                Game_Over.SetActive(true);
                break;
			}
		}
	}
	
	public void AddScore (int newScoreValue)
	{
		score += newScoreValue;
        UpdateScore ();
	}
	
	void UpdateScore ()
	{
		scoreText.text = "Score: " + score;
        scoreText1.text = "Score: " + score;
    }
	
	public void GameOver ()
	{
        Time.timeScale = 0.1f;
        
        Game_Over.SetActive(true);	
		gameOver = true;
	}
}