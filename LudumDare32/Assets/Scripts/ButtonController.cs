using UnityEngine;
using System.Collections;

public class ButtonController : MonoBehaviour {

	public void ClearCurrentText() {
		GameScene.Instance.ClearCurrentText();
	}

	public void SendCurrentText() {
		GameScene.Instance.SendCurrentText();
	}
}
