using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoSingleton<GameManager> {

	public void Restart() {
		StartCoroutine(Reload());
	}

	IEnumerator Reload() {
		yield return new WaitForSeconds(2f);
		SceneManager.LoadScene("Game");
	}
}
