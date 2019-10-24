using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberOfHennamon : MonoBehaviour
{
	public Text scoreText;
	

	// Start is called before the first frame update
	void Start()
    {

		// スコアのロード
		NetController.number = PlayerPrefs.GetInt("SCORE", 0);

		SetScore();

    }

    // Update is called once per frame
    void Update()
    {

	}

    void SetScore()
	{

		scoreText.text = string.Format("捕獲数:{0}", NetController.number);
	}
}
