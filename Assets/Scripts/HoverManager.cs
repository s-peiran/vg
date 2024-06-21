using UnityEngine;
using UnityEngine.EventSystems;

public class HoverManager : MonoBehaviour {
    private Transform highlight;
    private RaycastHit raycastHit;
    private float distance = 5f;
    private NarrationManager narrationManager;


    int artworkLayer = 0;
    private Vector3 clickPos;

    void Awake() {
        artworkLayer = LayerMask.NameToLayer("Artwork");
        narrationManager = gameObject.GetComponent<NarrationManager>();
    }


    void Update() {
        if (highlight != null) {
            highlight.gameObject.GetComponent<Outline>().enabled = false;
            highlight = null;
        }

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (!EventSystem.current.IsPointerOverGameObject() && Physics.Raycast(ray, out raycastHit)) {
            float dist = raycastHit.distance;

            GameObject objHit = raycastHit.collider.gameObject;

            if (objHit.layer == artworkLayer) {

                // Highlight
                highlight = raycastHit.transform;
                Debug.Log(highlight.gameObject.GetComponent<Outline>());
                if (highlight.gameObject.GetComponent<Outline>() != null) {
                    highlight.gameObject.GetComponent<Outline>().enabled = true;
                }
                else {
                    Outline outline = highlight.gameObject.AddComponent<Outline>();
                    outline.enabled = true;
                    highlight.gameObject.GetComponent<Outline>().OutlineColor = Color.magenta;
                    highlight.gameObject.GetComponent<Outline>().OutlineWidth = 7.0f;
                }

                // Open URL when clicked
                if (Input.GetMouseButtonDown(0)) {
                    clickPos = Input.mousePosition;
                }
                
                if (Input.GetMouseButtonUp(0)){
                    if (Input.mousePosition.Equals(clickPos)) {
                            objHit.GetComponent<OpenLink>().OnClick();
                    }
                }


                // Start narration
/*
                if (dist < narrationManager.narrationDist) {
                    int tagNum = int.Parse(objHit.tag);
                    narrationManager.StartNarration(tagNum);
                }
                */
            }
            else {
                    highlight = null;
            }
            
            
        }
    }
}
