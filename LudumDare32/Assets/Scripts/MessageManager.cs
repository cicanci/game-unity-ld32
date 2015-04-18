using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MessageManager : MonoBehaviour {

	public static MessageManager Instance;

	public GameObject GameCanvas;
	public GameObject MessagePrefab;
	public float MessageTimer;
	public string PositiveMessage;
	public string WarningMessage;
	public string NegativeMessage;

	private bool mCanShowMessage;
	private float mMessageBoxTimer;
	private GameObject mMessageBox;

	void Start() {
		Instance = this;
		mCanShowMessage = false;
		mMessageBoxTimer = 0;
	}
	
	void Update() {
		if (mCanShowMessage) {
			if (mMessageBoxTimer < 0) {
				HideMessage();
			}
			else {
				mMessageBoxTimer -= Time.deltaTime;
			}
		}
	}

	public void ShowMessage(Color pColor) {
		if (pColor == Color.red) {
			ShowMessage(NegativeMessage, pColor);
		}
		else if (pColor == Color.green) {
			ShowMessage(PositiveMessage, pColor);
		}
		else if (pColor == Color.yellow) {
			ShowMessage(WarningMessage, pColor);
		}
	}

	public void ShowMessage(string pMessage, Color pColor) {
		HideMessage();

		mMessageBox = Instantiate<GameObject>(MessagePrefab);
		mMessageBox.transform.SetParent(GameCanvas.transform, false);
		
		mMessageBox.GetComponent<Image>().color = pColor;
		mMessageBox.GetComponentInChildren<Text>().text = pMessage;

		mMessageBoxTimer = MessageTimer;
		mCanShowMessage = true;
	}

	public void HideMessage() {
		if (mMessageBox != null) {
			Destroy (mMessageBox);
		}
		mMessageBoxTimer = 0;
		mCanShowMessage = false;
	}
}
