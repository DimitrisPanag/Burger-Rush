using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerCounter : BaseCounter{

    [SerializeField] private KitchenObjectSO kitchenObjectSO;

    public event EventHandler onPlayerGrabbedObject;

    public override void Interact(Player player) {

        if (!player.HasKitchenObject()) {
            //Player is not carrying anything
            KitchenObject.SpawnKitchenObject(kitchenObjectSO, player);

            onPlayerGrabbedObject?.Invoke(this, EventArgs.Empty);
        }
    }
}
