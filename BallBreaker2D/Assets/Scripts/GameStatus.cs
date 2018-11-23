using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStatus : MonoBehaviour {

    //Game Speed Slider
    [Range(1,5)][SerializeField] float gameSpeed = 1f;
    [SerializeField] int pointsForBlockDestroyed = 2;
    [SerializeField] Text displayedScore;


    [SerializeField] int currentScore = 0;
    // Use this for initialization

    private void Awake()
    {
        int gameStatusScore = FindObjectsOfType<GameStatus>().Length;
        if (gameStatusScore > 1){
            Destroy(gameObject);
        }else{
            DontDestroyOnLoad(gameObject);
        }
    }

   private void Start () {
        displayedScore.text = currentScore.ToString();
	}
	
	// Update is called once per frame
	private void Update () {
        Time.timeScale = gameSpeed;
        displayedScore.text = currentScore.ToString();
    }

    public void AddToScore(){
        currentScore += pointsForBlockDestroyed;
    }

    public void ResetGame(){
        Destroy(gameObject);
    }
}
