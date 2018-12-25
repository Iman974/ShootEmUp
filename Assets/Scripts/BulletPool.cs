using UnityEngine;
using System.Collections.Generic;

public class BulletPool : MonoBehaviour {

    [SerializeField] private int enemyBulletCount = 80;
    [SerializeField] private Rigidbody2D enemyBulletPrefab = null;
    [SerializeField] private int playerBulletCount = 20;
    [SerializeField] private Rigidbody2D playerBulletPrefab = null;

    private static List<Rigidbody2D> enemyBullets = new List<Rigidbody2D>();
    private static List<Rigidbody2D> playerBullets = new List<Rigidbody2D>();

    private void Start() {
        FillWithBullets(enemyBullets, enemyBulletPrefab, enemyBulletCount);
        FillWithBullets(playerBullets, playerBulletPrefab, playerBulletCount);
    }

    private void FillWithBullets(List<Rigidbody2D> bulletList, Rigidbody2D prefab, int size) {
        for (int i = 0; i < size; i++) {
            Rigidbody2D newBullet = Instantiate(prefab, transform);
            bulletList.Add(newBullet);
        }
    }

    private void Update() {
        if (enemyBullets.Count < 10) {
            FillWithBullets(enemyBullets, enemyBulletPrefab, enemyBulletCount);
        }
        if (playerBullets.Count < 5) {
            FillWithBullets(playerBullets, playerBulletPrefab, playerBulletCount);
        }
    }

    public static Rigidbody2D GetEnemyBullet() {
        Rigidbody2D bullet = enemyBullets[enemyBullets.Count - 1];
        enemyBullets.RemoveAt(enemyBullets.Count - 1);
        bullet.gameObject.SetActive(true);
        return bullet;
    }

    public static Rigidbody2D GetPlayerBullet() {
        Rigidbody2D bullet = playerBullets[playerBullets.Count - 1];
        playerBullets.RemoveAt(playerBullets.Count - 1);
        bullet.gameObject.SetActive(true);
        return bullet;
    }
}
