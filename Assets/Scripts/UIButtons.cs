using UnityEngine;
using UnityEngine.UI;

public class UIButtons : MonoBehaviour
{
    [SerializeField] private AudioSource bgm;
    [SerializeField] private AudioSource narration;
    [SerializeField] private Sprite sound;
    [SerializeField] private Sprite noSound;
    [SerializeField] private Image volumeButton;
    [SerializeField] private GameObject instructions;

    private bool isSoundOff = false;
    private float originalNarrationVol;
    private bool isInstructionsOpen = false;

    void Start() {
        instructions.GetComponent<Button>().onClick.AddListener(HideInstructions);
        originalNarrationVol = narration.volume;
        HideInstructions();
    }

    public void OpenInstructions() {
        instructions.SetActive(!isInstructionsOpen);
        isInstructionsOpen = !isInstructionsOpen;
    }

    private void HideInstructions() {
        instructions.SetActive(false);
        isInstructionsOpen = false;
    }
    
    public void ToggleSound() {
        if (isSoundOff) {
            // Make sound on
            volumeButton.sprite = sound;
            bgm.Play();
            narration.volume = originalNarrationVol;
            isSoundOff = false;
        } else {
            // Make sound off
            volumeButton.sprite = noSound;
            bgm.Pause();
            narration.volume = 0f;
            isSoundOff = true;
        }

    }

    public void OffSound() {
        isSoundOff = false;
        ToggleSound();
    }
}
