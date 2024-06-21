using UnityEngine.UI;
using UnityEngine;
using Unity.VisualScripting;

public class TutorialManager : MonoBehaviour
{
    [SerializeField] private GameObject tutCanvas;
    [SerializeField] private Image blocking;
    [SerializeField] private Sprite i0;
    [SerializeField] private Sprite i1;
    [SerializeField] private Sprite i2;
    [SerializeField] private Sprite i3;

    [SerializeField] private GameObject t0;
    [SerializeField] private GameObject t1;
    [SerializeField] private GameObject t2;
    [SerializeField] private GameObject t3;

    [SerializeField] private PlayerMovement player;
    [SerializeField] private CamLook cam;

    void Start() {
        tutCanvas.SetActive(false);
    }

    // Start is called before the first frame update
    public void StartTut() {
        tutCanvas.SetActive(true);
        blocking.sprite = i0;
        t0.SetActive(true);
        t1.SetActive(false);
        t2.SetActive(false);
        t3.SetActive(false);

        player.canWalk = false;
        cam.hasStarted = false;
        blocking.GetComponent<Button>().onClick.AddListener(Zero);
    }

    public void Zero() {
        blocking.sprite = i1;
        t0.SetActive(false);
        t1.SetActive(true);
        t2.SetActive(false);
        t3.SetActive(false);
        blocking.GetComponent<Button>().onClick.AddListener(One);
    }

    public void One() {
        blocking.sprite = i2;
        t1.SetActive(false);
        t2.SetActive(true);
        t3.SetActive(false);
        blocking.GetComponent<Button>().onClick.AddListener(Two);
    }

    public void Two() {
        blocking.sprite = i3;
        t1.SetActive(false);
        t2.SetActive(false);
        t3.SetActive(true);
        blocking.GetComponent<Button>().onClick.AddListener(Three);
    }

    public void Three() {
        tutCanvas.SetActive(false);
        player.canWalk = true;
        cam.hasStarted = true;
    }
}
