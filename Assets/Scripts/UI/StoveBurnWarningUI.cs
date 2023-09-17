using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveBurnWarningUI : MonoBehaviour {

    public static StoveBurnWarningUI Instance {get; private set;}

    [SerializeField] private StoveCounter stoveCounter;



    private void Awake() {
        Instance = this;
    }


    private void Start() {
        stoveCounter.OnProgressChanged += StoveCounter_OnProgressChanged;

        Hide();
    }

    private void StoveCounter_OnProgressChanged(object sender, IHasProgress.OnProgressChangedEventArgs e) {
        float burnShowProgressAmount = .5f;
        bool show = stoveCounter.IsFried() && e.progressNormalized >= burnShowProgressAmount;

        if (show) {

            Show();
            

        } else {

            Hide();
            

        }
    }

    public bool GetBurnWarning() {
        return gameObject;
    }

    private void Show() {
        gameObject.SetActive(true);
    }
    private void Hide() {
        gameObject.SetActive(false);
    }
}
