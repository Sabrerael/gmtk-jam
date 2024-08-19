using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetGame : MonoBehaviour {
    private void Start() {
        GameManager.instance.ResetGameState();
    }
}
