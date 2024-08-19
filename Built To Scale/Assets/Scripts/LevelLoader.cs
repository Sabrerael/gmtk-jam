using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour {
    public void LoadMainMenu() {
        Debug.Log("Loading Level");
        SceneManager.LoadScene(0);
    }

    public void LoadGameScene() {
        Debug.Log("Loading Level");
        SceneManager.LoadScene(1);
    }

    public void LoadUpgradeScreen() {
        Debug.Log("Loading Level");
        SceneManager.LoadScene(2);
    }

    public void LoadWinScreen() {
        Debug.Log("Loading Level");
        SceneManager.LoadScene(3);
    }
}
