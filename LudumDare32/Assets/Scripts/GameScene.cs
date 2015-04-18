using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameScene : MonoBehaviour {

	public static GameScene Instance;

	public GameObject GameCanvas;
	public GameObject WordPanel;
	public GameObject WordPrefab;
	public Text CurrentWordLabel;
	public Text ScoreLabel;

	public string[] ValidWords;
	private string mCurrentWord;
	private int mScore = 0;

	void Start() {
		Instance = this;
	}

	public void PrintLetter(string pWord) {
		mCurrentWord += pWord;
		CurrentWordLabel.text = mCurrentWord;
	}

	public void SendCurrentText() {
		if (IsValidWord(mCurrentWord)) {
			GameObject text = Instantiate<GameObject>(WordPrefab);
			text.transform.SetParent(WordPanel.transform, false);
			text.GetComponent<Text>().text = mCurrentWord;

			mScore += 10;
			ScoreLabel.text = mScore.ToString();
		}

		ClearCurrentText ();
	}

	public void ClearCurrentText() {
		mCurrentWord = string.Empty;
		CurrentWordLabel.text = mCurrentWord;
	}

	private bool IsValidWord(string pWord) {
		foreach (string word in ValidWords) {
			if (word == pWord) {
				return true;
			}
		}
		return false;
	}
}
