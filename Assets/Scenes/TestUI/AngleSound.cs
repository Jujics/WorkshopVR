using UnityEngine;

public class AngleSound : MonoBehaviour
{
    [Header("Rotation Settings")]
    [SerializeField] private Transform linkedDial; // L'objet li� qui tourne
    [SerializeField] private float angleStep = 45f; // Pas d'angle pour jouer le son
    [SerializeField] private float angleTolerance = 5f; // Tol�rance pour d�tecter le changement

    [Header("Audio Settings")]
    [SerializeField] private AudioSource audioSource; // Composant AudioSource pour jouer le son
    [SerializeField] private AudioClip rotationSound; // Son jou� � chaque �tape

    private float lastAngle = 0f; // Dernier angle de rotation d�tect�

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
        // R�cup�re l'angle actuel
        float currentAngle = linkedDial.localEulerAngles.y;

        // Calcule la diff�rence d'angle
        float angleDifference = Mathf.Abs(currentAngle - lastAngle);

        // Ajustement pour les angles autour de 360� (0� et 360� sont �quivalents)
        if (angleDifference > 180f)
            angleDifference = 360f - angleDifference;

        // V�rifie si la diff�rence d�passe le seuil
        if (angleDifference >= angleStep - angleTolerance)
        {
            // Joue le son
            PlaySound();

            // Met � jour le dernier angle
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
