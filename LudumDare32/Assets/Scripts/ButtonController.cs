using UnityEngine;
using System.Collections;

public class ButtonController : MonoBehaviour {

	public void ClearCurrentText() {
		GameScene.Instance.ClearCurrentText();
	}

	public void SendCurrentText() {
		GameScene.Instance.SendCurrentText();
	}

	public void PlayAgain() {
		Application.LoadLevel("Menu");
	}

	public void PlayGame() {
		if (GameData.CanShowTutorial) {
			GameData.CanShowTutorial = false;
			MenuScene.Instance.ShowMenuTutorialPanel();
		}
		else {
			Application.LoadLevel("Game");
		}
	}

	public void ShowMenuSecondPanel() {
		MenuScene.Instance.ShowMenuSecondPanel();
	}

	public void SetDificultEasy() {
		MenuScene.Instance.ShowMenuThirdPanel(GameDifficult.Easy);
	}

	public void SetDificultNormal() {
		MenuScene.Instance.ShowMenuThirdPanel(GameDifficult.Normal);
	}

	public void SetDificultHard() {
		MenuScene.Instance.ShowMenuThirdPanel(GameDifficult.Hard);
	}
}
