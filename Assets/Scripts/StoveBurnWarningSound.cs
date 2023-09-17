using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveBurnWarningSound : MonoBehaviour {

    [SerializeField] private StoveCounter stoveCounter;
    [SerializeField] private Canvas stoveBurnWarningUI;
    private AudioSource audioSource;


    private void Awake() {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start() {
        if (StoveBurnWarningUI.Instance.GetBurnWarning() == true) { 

            audioSource.Play();
        }else{
            audioSource.Pause();
        }
    }
}
