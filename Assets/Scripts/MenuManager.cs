using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    private TutorialManager tutorialManager;
    


    void Start() {
        tutorialManager = gameObject.GetComponent<TutorialManager>();
        menu.SetActive(true);
    }

    public void DisableMenu() {
        menu.SetActive(false);
        tutorialManager.StartTut();
    }

}
