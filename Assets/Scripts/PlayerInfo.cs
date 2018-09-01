using UnityEngine;

public class PlayerInfo : MonoBehaviour {

    private GameObject playerGameObj;
    private Transform playerTransform;

    public static PlayerInfo Instance { get; private set; }

    public static Transform Transform {
        get { return Instance.playerTransform; }
    }

    private void Awake() {
        #region Singleton
        if (Instance == null) {
            Instance = this;
        } else if (Instance != this) {
            throw new System.Exception("More than one game manager exists.");
        }
        #endregion

        playerGameObj = GameObject.FindWithTag("Player");
        playerTransform = playerGameObj.transform;
    }
}
