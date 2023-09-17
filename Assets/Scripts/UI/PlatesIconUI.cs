using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatesIconUI : MonoBehaviour {

    [SerializeField] private PlateKitchenObject plateKitchenObject;
    [SerializeField] private Transform iconTemplate;

    private void Awake() {
        iconTemplate.gameObject.SetActive(false);
    }

    private void Start() {
        plateKitchenObject.OnIgredientAdded += PlateKitchenObject_OnIgredientAdded;
    }

    private void PlateKitchenObject_OnIgredientAdded(object sender, PlateKitchenObject.OnIgredientAddedEventArgs e) {
        VisualUpdate();
    }

    private void VisualUpdate() {
        foreach (Transform child in transform) {
            if (child == iconTemplate) continue;
            Destroy(child.gameObject);
        }
        foreach(KitchenObjectSO kitchenObjectSO in plateKitchenObject.GetKitchenObjectSOList()) {
           Transform iconTransform =  Instantiate(iconTemplate, transform);
            iconTransform.gameObject.SetActive(true);
            iconTransform.GetComponent<PlateIconSingleUI>().SetKitchenObjectSO(kitchenObjectSO);
        }
    }
}