using UnityEngine;

public class AngleSound : MonoBehaviour
{
    [Header("Rotation Settings")]
    [SerializeField] private Transform linkedDial; // L'objet lié qui tourne
    [SerializeField] private float angleStep = 45f; // Pas d'angle pour jouer le son
    [SerializeField] private float angleTolerance = 5f; // Tolérance pour détecter le changement

    [Header("Audio Settings")]
    [SerializeField] private AudioSource audioSource; // Composant AudioSource pour jouer le son
    [SerializeField] private AudioClip rotationSound; // Son joué à chaque étape

    private float lastAngle = 0f; // Dernier angle de rotation détecté

    private void Start()
    {
        if (!linkedDial)
        {
            Debug.LogError("LinkedDial is not assigned.");
            return;
        }

        if (!audioSource)
        {
            Debug.LogError("AudioSource is not assigned.");
            return;
        }

        // Initialisation de l'angle
        lastAngle = linkedDial.localEulerAngles.y;
    }

    private void Update()
    {
        // Récupère l'angle actuel
        float currentAngle = linkedDial.localEulerAngles.y;

        // Calcule la différence d'angle
        float angleDifference = Mathf.Abs(currentAngle - lastAngle);

        // Ajustement pour les angles autour de 360° (0° et 360° sont équivalents)
        if (angleDifference > 180f)
            angleDifference = 360f - angleDifference;

        // Vérifie si la différence dépasse le seuil
        if (angleDifference >= angleStep - angleTolerance)
        {
            // Joue le son
            PlaySound();

            // Met à jour le dernier angle
            lastAngle = currentAngle;
        }
    }

    private void PlaySound()
    {
        if (audioSource && rotationSound)
        {
            audioSource.clip = rotationSound;
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("AudioSource or RotationSound is missing.");
        }
    }
}
