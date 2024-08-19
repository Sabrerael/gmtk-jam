using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTimer : MonoBehaviour {
    [SerializeField] RectTransform foreground;

    private void Update() {
        float currentTime = GameManager.instance.getTimer();
        foreground.localScale = new Vector3(Mathf.Min(currentTime / 120, 1), 1, 1);
    }
}
