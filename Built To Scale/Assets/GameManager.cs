using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public static GameManager instance = null;

    private int money = 0;
    private float dayTimer = 0;
    private int dayNumber = 1;

    // Unity Functions
    private void Awake() {
        if (instance == null) {
            instance = this;
        }
        else if (instance != this) {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }

    private void Update() {
        dayTimer += Time.deltaTime;
        if (dayTimer >= 120) {
            Debug.Log("Day Over");
            dayTimer = 0;
            dayNumber++;
            if (dayNumber == 5) {
                Debug.Log("The end of the week!");
            } else {
                LoadMainLevel();
            }
        }
    }

    public void LoadMainLevel() {
        Debug.Log("Loading Level");
        SceneManager.LoadScene(0);
    }

    public void UpdateMoney(int value) {
        money += value;
        Debug.Log("money is $" + money);
    }
}
