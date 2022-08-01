using UnityEngine;

public class Map : MonoBehaviour {
    public static Map Instance { get; private set; }
    public LayerMask obstacleLayers;
    public LayerMask walkableLayers;

    [SerializeField]private Collider2D _walkableMap;

    private void Awake() {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this.gameObject);
    }

    private bool IsPointInsideMap(Vector3 point) => _walkableMap.OverlapPoint(point);

    public bool IsPointWalkable(Vector3 point) {
        if (!IsPointInsideMap(point))
            return false;

        Collider2D[] obstacleSeek = Physics2D.OverlapCircleAll(point, .25f, obstacleLayers);
        Collider2D[] walkableSeek = Physics2D.OverlapCircleAll(point, .25f, walkableLayers);
        if (walkableSeek.Length > 0 && obstacleSeek.Length <= 0)
            return true;

        return false;
    }
}
