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
	public int WordAnimationSpeed;
	public string[] ValidWords;

	private string mCurrentWord;
	private int mScore;
	private string[] mUsedWords;
	private bool mCanMoveLabel;
	private Vector2 mCurrentWordStartPosition;

	void Start() {
		Instance = this;
		CurrentWordLabel.text = "_";

		mUsedWords = new string[3];
		mCanMoveLabel = false;
		mCurrentWordStartPosition = CurrentWordLabel.gameObject.GetComponent<RectTransform>().localPosition;
	}

	void Update() {
		if (mCanMoveLabel) {
			Vector2 oldPosition = CurrentWordLabel.gameObject.GetComponent<RectTransform>().localPosition;

			if (oldPosition.x < 0) {
				Vector2 newPosition = new Vector2(oldPosition.x + Time.deltaTime * WordAnimationSpeed, oldPosition.y);
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
		if (!IsUsedWord(mCurrentWord)) {
			if (IsValidWord(mCurrentWord)) {
				SwapUsedWords (mCurrentWord);
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
		else {
			ClearCurrentText();
			MessageManager.Instance.ShowMessage(Color.yellow);
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

	private void SwapUsedWords(string pNewWord) {
		mUsedWords[2] = mUsedWords[1];
		mUsedWords[1] = mUsedWords[0];
		mUsedWords[0] = pNewWord;
	}

	private bool IsUsedWord(string pWord) {
		foreach (string word in mUsedWords) {
			if (word == pWord) {
				return true;
			}
		}
		return false;
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
