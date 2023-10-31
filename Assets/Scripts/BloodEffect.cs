using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodEffect : MonoBehaviour
{
    public GameObject bloodPrefab; // The prefab for the blood effect
    public int numberOfBloodEffects = 3; // Number of blood effects to spawn
    public float bloodEffectDuration = 10.0f; // Duration for blood effect to stay on the screen
    public Canvas canvas; // Reference to the canvas where the blood effects will be spawned
    public AudioSource audioSource;
    public AudioClip clip;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            audioSource.PlayOneShot(clip);
            for (int i = 0; i < numberOfBloodEffects; i++)
            {
                ShowBloodEffect();
            }
        }
    }

    void ShowBloodEffect()
    {
        // Instantiate the blood effect within the canvas
        GameObject bloodEffect = Instantiate(bloodPrefab, Vector3.zero, Quaternion.identity, canvas.transform);

        // Set the position of the blood effect within the canvas
        RectTransform bloodRectTransform = bloodEffect.GetComponent<RectTransform>();
        bloodRectTransform.anchoredPosition = GetRandomPositionWithinCanvas();

        StartCoroutine(DestroyBloodEffect(bloodEffect, bloodEffectDuration));
    }

    Vector2 GetRandomPositionWithinCanvas()
    {
        // Get random X and Y positions within the canvas size
        float randomX = Random.Range(-canvas.pixelRect.width / 2, canvas.pixelRect.width / 2);
        float randomY = Random.Range(-canvas.pixelRect.height / 2, canvas.pixelRect.height / 2);

        return new Vector2(randomX, randomY);
    }

    IEnumerator DestroyBloodEffect(GameObject bloodEffect, float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(bloodEffect);
    }
}
