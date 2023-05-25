using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
	private string sceneName;
	private void OnEnable()
	{
		StartCoroutine(Test());
	}

	private IEnumerator Test()
	{
		yield return new WaitForSeconds(0.75f);
		base.StartCoroutine(this.WaitLoad());
	}


	private IEnumerator WaitLoad()
	{
	
		sceneName = "MainScene";
		var _asyncOperation = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
		while (!_asyncOperation.isDone)
		{
			yield return null;
		}
		yield break;
	}
}
