using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager instance = null;

    private string sauceHintText = "Put sauce on the pizza: ";
    private string cheeseHintText = "Put cheese on the pizza: ";
    private string toppingsHintText = "Put toppings on the pizza: ";

    [SerializeField] TextMeshProUGUI moneyTextField;
    [SerializeField] TextMeshProUGUI tutorialTextField;

    [SerializeField] private int money = 0;
    private float dayTimer = 0;
    private int dayNumber = 0;
    private bool runTimer = false;

    private bool fasterWalkUpgradeUnlocked = false;
    private bool biggerSauceUpgradeUnlocked = false;
    private bool biggerCheeseUpgradeUnlocked = false;
    private bool biggerToppingsUpgradeUnlocked = false;

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
        if (runTimer) {
            dayTimer += Time.deltaTime;
            if (dayTimer >= 120) {
                Debug.Log("Day Over");
                dayTimer = 0;
                dayNumber++;
                if (dayNumber >= 5) {
                    LoadWinScreen();
                } else {
                    LoadUpgradeScreen();
                }
            }
        }
    }

    private void LoadWinScreen() {
        LevelLoader ll = FindObjectOfType<LevelLoader>();
        ll.LoadWinScreen();
    }

    private void LoadUpgradeScreen() {
        LevelLoader ll = FindObjectOfType<LevelLoader>();
        ll.LoadUpgradeScreen();
    }

    public bool GetFasterWalkUnlock() {
        return fasterWalkUpgradeUnlocked;
    }

    public bool GetBiggerSauceUnlock() {
        return biggerSauceUpgradeUnlocked;
    }

    public bool GetBiggerCheeseUnlock() {
        return biggerCheeseUpgradeUnlocked;
    }

    public bool GetBiggerToppingsUnlock() {
        return biggerToppingsUpgradeUnlocked;
    }

    public int GetMoney() {
        return money;
    }

    public float getTimer(){
        return dayTimer;
    }

    public void SetFasterWalkUnlock(bool value) {
        fasterWalkUpgradeUnlocked = value;
    }

    public void SetBiggerSauceUnlock(bool value) {
        biggerSauceUpgradeUnlocked = value;
    }

    public void SetBiggerCheeseUnlock(bool value) {
        biggerCheeseUpgradeUnlocked = value;
    }

    public void SetBiggerToppingsUnlock(bool value) {
        biggerToppingsUpgradeUnlocked = value;
    }

    public void SetRunTimer(bool value) {
        runTimer = value;
        dayTimer = 0;
    }

    public void ResetUI() {
        GameObject moneyObject = GameObject.Find("Money");
        GameObject tutorialObject = GameObject.Find("Info Text");
        if (moneyObject != null) { 
            moneyTextField = moneyObject.GetComponent<TextMeshProUGUI>();
            moneyTextField.text = "$" + money;
        }

        if (tutorialObject != null) { 
            tutorialTextField = tutorialObject.GetComponent<TextMeshProUGUI>();
            tutorialTextField.text = "Put sauce on the pizza: 0%";
        }
    }

    public void ResetGameState() {
        money = 0;
        dayTimer = 0;
        dayNumber = 0;
    }

    public void UpdateMoney(int value) {
        money += value;
        if (moneyTextField != null) { 
            moneyTextField.text = "$" + money;
        }
    }

    public void UpdateTutorialText(PizzaMode pizzaMode, int percent) {
        Debug.Log(tutorialTextField);
        Debug.Log("Updating info text, " + pizzaMode + ", " + percent);
        if (pizzaMode == PizzaMode.Sauce) {
            tutorialTextField.text = sauceHintText + percent + "%";
        } else if (pizzaMode == PizzaMode.Cheese) {
            tutorialTextField.text = cheeseHintText + percent + "%";
        } else if (pizzaMode == PizzaMode.Toppings) {
            tutorialTextField.text = toppingsHintText + percent + "%";
        } else {
            tutorialTextField.text = "Hit the green button to finish the pizza";
        }
    }
}
