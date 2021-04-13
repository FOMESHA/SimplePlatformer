using UnityEngine;

public class Collector : MonoBehaviour
{
    [SerializeField] private LayerMask _canCollect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var collisionLayerMask = 1 << collision.gameObject.layer;
        if (_canCollect.value == collisionLayerMask)
        {
            Destroy(collision.transform.parent.gameObject);
        }
    }
}
