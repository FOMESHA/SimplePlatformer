using UnityEngine;

[RequireComponent(typeof(Animator))]
public class DeathEffect : MonoBehaviour
{
    public void ActivateEffect()
    {
        transform.parent = null;
        gameObject.SetActive(true);
    }

    private void DestroyAfterPlayClip()
    {
        Destroy(gameObject);
    }
}
