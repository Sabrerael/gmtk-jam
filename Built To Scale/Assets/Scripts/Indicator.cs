using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Indicator : MonoBehaviour {
    [SerializeField] PizzaMode indicatorType;

    private bool isTouched = false;

    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log(indicatorType.ToString());
        Debug.Log("tag is " + other.tag);
        if (!isTouched && other.CompareTag(indicatorType.ToString())) {
            isTouched = true;
            Debug.Log("indicator has been triggered");
        }
    }

    public bool GetIsTouched() {
        return isTouched;
    }

}
