using UnityEngine;

public class OpenLink : MonoBehaviour {
    [SerializeField] private string url;
    public void OnClick() {
        Application.OpenURL(url);
    }
}
