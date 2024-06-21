using UnityEngine;

public class Minimap : MonoBehaviour
{
    [SerializeField] private RectTransform pt1;
    [SerializeField] private RectTransform pt2;

    [SerializeField] private Transform realpt1;
    [SerializeField] private Transform realpt2;


    [SerializeField] private RectTransform miniPlayer;
    [SerializeField] private Transform player;

    private float ratio = 0f;

    void Awake()
    {
        CalcMapRatio();
    }

    void Update()
    {
        Vector2 movement = new Vector2((player.position.x - realpt1.position.x) * ratio,
                                       (player.position.z - realpt1.position.z) * ratio);
        miniPlayer.anchoredPosition = pt1.anchoredPosition - movement;
    }

    private void CalcMapRatio() {
        // distance of world
        Vector3 worldDist = realpt1.position - realpt2.position;
        worldDist.y = 0f;
        float distWorld = worldDist.magnitude;

        // distance in minimap
        float distMinimap = Mathf.Sqrt(
            Mathf.Pow(pt1.anchoredPosition.x - pt2.anchoredPosition.x, 2) +
            Mathf.Pow(pt1.anchoredPosition.y - pt2.anchoredPosition.y, 2)
        );

        ratio = distMinimap / distWorld;
    }
}
