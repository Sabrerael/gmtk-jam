using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour {
    [SerializeField] Animator crossfade;

    public void LoadMainMenu() {
        StartCoroutine(LoadLevel(0));
    }

    public void LoadGameScene() {
        StartCoroutine(LoadLevel(1));
    }

    public void LoadUpgradeScreen() {
        StartCoroutine(LoadLevel(2));
    }

    public void LoadWinScreen() {
        StartCoroutine(LoadLevel(3));
    }

    public IEnumerator LoadLevel(int index) {
        crossfade.SetTrigger("Crossfade");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(index);
    }
}
