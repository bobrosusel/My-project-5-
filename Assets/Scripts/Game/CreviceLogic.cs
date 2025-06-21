using UnityEngine;

public class CreviceLogic : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IHealth health))
            health.TakeDamage(10000000);
    }
}
