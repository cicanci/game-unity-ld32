using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour {

	public static EnemyManager Instance;

	public GameObject GameCanvas;
	public GameObject EnemyPrefab;
	public float TimeFactor;
	public float EnemyKillDistance;

	private GameObject mCurrentEnemy;
	private bool mGameOver;

	void Start() {
		Instance = this;
		mGameOver = false;
		CreateEnemy();
	}
	
	void Update() {
		if ((!mGameOver) && (mCurrentEnemy != null)) {
			Vector2 oldScale = mCurrentEnemy.GetComponent<RectTransform>().localScale;
			Vector2 newScale = new Vector2(oldScale.x + Time.deltaTime * TimeFactor, oldScale.y + Time.deltaTime * TimeFactor);

			if (newScale.x > EnemyKillDistance) {
				GameScene.Instance.ShowGameOver();
				mGameOver = true;
			}
			else {
				mCurrentEnemy.GetComponent<RectTransform>().localScale = newScale;
			}
		}
	}

	public void CreateEnemy() {
		DestroyEnemy();

		mCurrentEnemy = Instantiate<GameObject>(EnemyPrefab);
		mCurrentEnemy.transform.SetParent(GameCanvas.transform, false);
		mCurrentEnemy.GetComponent<RectTransform>().localScale = new Vector2(0, 0);
	}

	public void DestroyEnemy() {
		if (mCurrentEnemy != null) {
			Destroy(mCurrentEnemy);
		}
	}
}
