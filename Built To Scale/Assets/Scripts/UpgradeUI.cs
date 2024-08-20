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
        if (GameManager.instance.GetMoney() < 250) {
            upgrade1.interactable = false;
            upgrade2.interactable = false;
            upgrade3.interactable = false;
            upgrade4.interactable = false;
            return;
        } else if (GameManager.instance.GetMoney() >= 250 && GameManager.instance.GetMoney() < 350) {
            upgrade1.interactable = true;
            upgrade2.interactable = false;
            upgrade3.interactable = false;
            upgrade4.interactable = false;
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


    public void PurchaseUpgrade1() {
        GameManager.instance.SetFasterWalkUnlock(true);
        GameManager.instance.UpdateMoney(-250);
    }
    
    public void PurchaseUpgrade2() {
        GameManager.instance.SetBiggerSauceUnlock(true);
        GameManager.instance.UpdateMoney(-350);
    }

    public void PurchaseUpgrade3() {
        GameManager.instance.SetBiggerCheeseUnlock(true);
        GameManager.instance.UpdateMoney(-350);
    }

    public void PurchaseUpgrade4() {
        GameManager.instance.SetBiggerToppingsUnlock(true);
        GameManager.instance.UpdateMoney(-350);
    }
}
