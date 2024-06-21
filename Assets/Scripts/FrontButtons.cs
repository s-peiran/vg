using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FrontButtons : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Color inactive;
    private Color active;
    [SerializeField] private float r;
    [SerializeField] private float g;
    [SerializeField] private float b;
    [SerializeField] private float r_;
    [SerializeField] private float g_;
    [SerializeField] private float b_;
    [SerializeField] private string guideUrl;
    [SerializeField] private string videoUrl;

    [SerializeField] private UIButtons uiBut;

    void Awake() {
        inactive = new Color(r/255f, g/255f, b/255f);
        active = new Color(r_/255f, g_/255f, b_/255f);
    }


    public void OnGuideClick() {
        Application.OpenURL(guideUrl);
    }

    public void OnVideoClick() {
        Application.OpenURL(videoUrl);
        uiBut.OffSound();
    }

    public void FB() {
        Application.OpenURL("https://www.facebook.com/people/MeetArts-Singapore/100082992986382/");
    }

    public void LI() {
        Application.OpenURL("https://www.linkedin.com/company/meetarts-singapore/");
    }

    public void IG() {
        Application.OpenURL("https://www.instagram.com/meetarts.official/");
    }

    public void YT() {
        Application.OpenURL("https://www.youtube.com/@meetarts_sg");
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        eventData.pointerEnter.GetComponent<Image>().color = active;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        eventData.pointerEnter.GetComponent<Image>().color = inactive;
    }
}
