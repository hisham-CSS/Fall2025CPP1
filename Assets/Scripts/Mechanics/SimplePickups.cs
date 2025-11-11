using UnityEngine;

public class SimplePickups : MonoBehaviour
{
    public enum PickupType
    {
        Life,
        Powerup
    }

    public PickupType pickupType;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerController pc = collision.GetComponent<PlayerController>();

            switch (pickupType)
            {
                case PickupType.Life:
                    pc.lives++;
                    break;
                case PickupType.Powerup:
                    pc.ApplyJumpForcePowerup();
                    break;
            }
            // Destroy the pickup after collection
            Destroy(gameObject);
        }
    }
}
