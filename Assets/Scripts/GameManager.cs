using UnityEngine;

public class GameManager : MonoBehaviour {

    [SerializeField] private Vector2 movementAreaOffset = new Vector2(0.55f, 0.35f);

    public static GameManager Instance { get; private set; }
    public static Game GameData { get { return Instance.gameData; } }
    public static Rect MovementArea { get; private set; }

    private Camera mainCamera;
    private Game gameData;

    private void Awake() {
        #region Singleton
        if (Instance == null) {
            Instance = this;
        } else if (Instance != this) {
            throw new System.Exception("More than one game manager exists.");
        }
        #endregion

        mainCamera = Camera.main;
        Vector2 bottomLeft = (Vector2)mainCamera.ViewportToWorldPoint(Vector2.zero) + movementAreaOffset;
        Vector2 topRight = (Vector2)mainCamera.ViewportToWorldPoint(Vector2.one) - movementAreaOffset;
        MovementArea = new Rect(bottomLeft.x, bottomLeft.y, topRight.x - bottomLeft.x, topRight.y - bottomLeft.y);
    }
}
