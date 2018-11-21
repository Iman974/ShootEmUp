using UnityEngine;
using System.Collections.Generic;

public class BulletPool : MonoBehaviour {

    [SerializeField] private int bulletCount = 50;
    [SerializeField] private Rigidbody2D bulletPrefab;

    private static List<Rigidbody2D> unavailableBullets = new List<Rigidbody2D>();
    private static List<Rigidbody2D> availableBullets = new List<Rigidbody2D>();

    private void Start() {
        for (int i = 0; i < bulletCount; i++) {
            Rigidbody2D newBullet = Instantiate(bulletPrefab, transform);
            availableBullets.Add(newBullet);
        }
	}

    public static Rigidbody2D GetAvailableBullet() {
        Rigidbody2D bullet = availableBullets[availableBullets.Count - 1];
        availableBullets.RemoveAt(availableBullets.Count - 1);
        unavailableBullets.Add(bullet);
        bullet.gameObject.SetActive(true);
        return bullet;
    }

    public static void ReleaseBullet(Rigidbody2D bullet) {
        unavailableBullets.Remove(bullet);
        availableBullets.Add(bullet);
        bullet.gameObject.SetActive(false);
    }
}
