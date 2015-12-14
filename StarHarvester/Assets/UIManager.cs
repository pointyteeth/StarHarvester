using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIManager : MonoBehaviour {

	public int winScore;
	bool won;
	public Text scoreText;
	public PlayerMovement player;
	public GameObject finalExplosion;
	public Image fadeOut;
	public Text winMessage;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		scoreText.text = player.starsHarvested.ToString();
		if(player.starsHarvested >= winScore) {
			finalExplosion.SetActive(true);
			won = true;
		}
		if(won) {
			fadeOut.color = Color.Lerp(fadeOut.color, Color.black, 0.005f);
			winMessage.color = Color.Lerp(winMessage.color, Color.white, 0.003f);
		}
	}
}
