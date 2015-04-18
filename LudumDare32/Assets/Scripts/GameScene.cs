using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameScene : MonoBehaviour {

	public static GameScene Instance;

	public GameObject WordPanel;
	public GameObject WordPrefab;
	public Text CurrentWordLabel;
	public Text ScoreLabel;
	public int DefaultScore;
	public string[] ValidWords;

	private string[] mUsedWords;
	private string mCurrentWord;
	private int mScore;
	private bool mCanMoveLabel;
	private Vector2 mCurrentWordStartPosition;

	void Start() {
		Instance = this;
		CurrentWordLabel.text = "_";
		mCanMoveLabel = false;
		mCurrentWordStartPosition = CurrentWordLabel.gameObject.GetComponent<RectTransform>().localPosition;
	}

	void Update() {
		if (mCanMoveLabel) {
			Vector2 oldPosition = CurrentWordLabel.gameObject.GetComponent<RectTransform>().localPosition;

			if (oldPosition.x < 0) {
				Vector2 newPosition = new Vector2(oldPosition.x + Time.deltaTime * 1000, oldPosition.y);
				CurrentWordLabel.gameObject.GetComponent<RectTransform>().localPosition = newPosition;
			}
			else {
				mCanMoveLabel = false;
				AddTextToPanel();
			}
		}
	}

	public void PrintLetter(string pWord) {
		mCurrentWord += pWord;
		CurrentWordLabel.text = mCurrentWord + "_";
	}

	public void SendCurrentText() {
		if (IsValidWord(mCurrentWord)) {
			mCanMoveLabel = true;
			// Remove the _ before the action
			CurrentWordLabel.text = mCurrentWord;

			MessageManager.Instance.ShowMessage(Color.green);
		}
		else {
			ClearCurrentText();

			MessageManager.Instance.ShowMessage(Color.red);
		}
	}

	public void ClearCurrentText() {
		mCurrentWord = string.Empty;
		CurrentWordLabel.text = "_";
		CurrentWordLabel.gameObject.GetComponent<RectTransform>().localPosition = mCurrentWordStartPosition;
	}

	private void AddTextToPanel() {
		GameObject text = Instantiate<GameObject>(WordPrefab);
		text.transform.SetParent(WordPanel.transform, false);
		text.GetComponent<Text>().text = mCurrentWord;
		
		mScore += DefaultScore;
		ScoreLabel.text = mScore.ToString();

		EnemyManager.Instance.CreateEnemy();
		ClearCurrentText();
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
