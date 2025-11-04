using UnityEngine;

public class Shoot : MonoBehaviour
{
    private SpriteRenderer sr;
    [SerializeField] private Vector2 initalShotVelocity = Vector2.zero;
    [SerializeField] private Transform spawnPointRight;
    [SerializeField] private Transform spawnPointLeft;
    [SerializeField] private Projectile projectilePrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();

        if (initalShotVelocity == Vector2.zero)
        {
            initalShotVelocity = new Vector2(10f, 0f);
            Debug.LogWarning("Initial shot velocity not set on Shoot component of " + gameObject.name + ", defaulting to " + initalShotVelocity);
        }

        if (spawnPointLeft == null || spawnPointRight == null || projectilePrefab == null)
        {
            Debug.LogError("Spawn points or projectile not set on Shoot component of " + gameObject.name);
        }
    }
    public void Fire()
    {
        Projectile curProjectile;
        if (!sr.flipX)
        {
            curProjectile = Instantiate(projectilePrefab, spawnPointRight.position, Quaternion.identity);
            curProjectile.SetVelocity(initalShotVelocity);
        }
        else
        {
            curProjectile = Instantiate(projectilePrefab, spawnPointLeft.position, Quaternion.identity);
            curProjectile.SetVelocity(initalShotVelocity);
        }
    }
}
