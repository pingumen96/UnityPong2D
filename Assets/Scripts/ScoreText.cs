using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour {
    private Text text;

	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		if(gameObject.tag == "Player") {
            text.text = GameManager.instance.PlayerScore.ToString();
        } else {
            text.text = GameManager.instance.CpuScore.ToString();
        }
	}
}
