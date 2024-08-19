using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeUI : MonoBehaviour {
    [SerializeField] Button upgrade1, upgrade2, upgrade3, upgrade4;

    private void Start() {
        GameManager.instance.SetRunTimer(false);
        GameManager.instance.ResetUI();
        CheckButtonsValidity();
    }

    public void CheckButtonsValidity() {
        if (GameManager.instance.GetMoney() < 100) {
            upgrade1.interactable = false;
            upgrade2.interactable = false;
            upgrade3.interactable = false;
            upgrade4.interactable = false;
            return;
        } else {
            upgrade1.interactable = true;
            upgrade2.interactable = true;
            upgrade3.interactable = true;
            upgrade4.interactable = true;
        }

        if (GameManager.instance.GetFasterWalkUnlock()) {
            upgrade1.interactable = false;
        }
        if (GameManager.instance.GetBiggerSauceUnlock()) {
            upgrade2.interactable = false;
        }
        if (GameManager.instance.GetBiggerCheeseUnlock()) {
            upgrade3.interactable = false;
        }
        if (GameManager.instance.GetBiggerToppingsUnlock()) {
            upgrade4.interactable = false;
        }
    }
}
