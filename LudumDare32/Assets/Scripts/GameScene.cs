using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameScene : MonoBehaviour {

	public static GameScene Instance;

	public GameObject WordPanel;
	public GameObject WordPrefab;
	public Text CurrentWordLabel;
	public Text ScoreLabel;
	public int DefaultScore = 10;

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

			mScore += DefaultScore;
			ScoreLabel.text = mScore.ToString();

			EnemyManager.Instance.CreateEnemy();
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
