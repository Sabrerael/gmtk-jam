using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pizza : MonoBehaviour {
    [SerializeField] Transform sauceLayerTransform;
    [SerializeField] Transform cheeseLayerTransform;
    [SerializeField] Transform toppingsLayerTransform;

    private PlayerController player;

    private void Start() {
        player = FindObjectOfType<PlayerController>();
        player.GetComponent<SauceDropper>().SetPizza(this);
        player.GetComponent<CheeseDropper>().SetPizza(this);
    }

    public Transform GetSauceLayerTransform() {
        return sauceLayerTransform;
    }

    public Transform GetCheeseLayerTransform() {
        return cheeseLayerTransform;
    }

    public Transform GetToppingsLayerTransform() {
        return toppingsLayerTransform;
    }
}
