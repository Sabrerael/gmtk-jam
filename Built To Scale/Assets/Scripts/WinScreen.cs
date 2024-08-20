using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WinScreen : MonoBehaviour {
    [SerializeField] TextMeshProUGUI winText;

    // Start is called before the first frame update
    void Start()
    {
        winText.text = "You made $" + GameManager.instance.GetMoney() + "!\nYou win!";
    }
}
