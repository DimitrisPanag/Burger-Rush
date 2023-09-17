using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : BaseCounter{

    [SerializeField] private KitchenObjectSO kitchenObjectSO;
    

    public override void Interact(Player player) {

        if (!HasKitchenObject()) {
            //There is no kitchenObject here
            if (player.HasKitchenObject()) {
                //Player is caring something
                player.GetKitchenObject().SetKitchenObjectParent(this);
            } else {
                //Player not carrying anything
            }
        } else {
            //There is a kitchenObject here
            if (player.HasKitchenObject()) {
                //Player is carrying something
                if (player.GetKitchenObject().TryGetPlate(out PlateKitchenObject plateKitchenObject)) {
                    //Player is holding a Plate
                    if (plateKitchenObject.TryAddIngredient(GetKitchenObject().GetKitchenObjectSO())) {
                        GetKitchenObject().DestroySelf();
                    }
                } else {
                    //Player is not carrying a plate but something else
                    if (GetKitchenObject().TryGetPlate(out plateKitchenObject)) {
                        //Counter has a plate on it
                        if (plateKitchenObject.TryAddIngredient(player.GetKitchenObject().GetKitchenObjectSO())) { 
                            player.GetKitchenObject().DestroySelf();
                        }
                    }
                }
            } else {
                //Player is not carrying anything
                GetKitchenObject().SetKitchenObjectParent(player);
            }
        }
    }
}
