using UnityEngine;

public class GameManager : MonoBehaviour {

    public Game gameData;

    public static GameManager Instance { get; private set; }
    public static Game GameData { get { return Instance.gameData; } }

    private void Awake() {
        if (Instance == null) {
            Instance = this;
        } else if (Instance != this) {
            throw new System.Exception("More than one game manager exists.");
        }
    }
}
