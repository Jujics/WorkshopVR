using UnityEngine;

public class BreakableObject : MonoBehaviour
{
    public GameObject brokenObjectPrefab; 
    public float breakForceThreshold = 5.0f; 

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogWarning("BreakableObject: No Rigidbody found. Adding one.");
            rb = gameObject.AddComponent<Rigidbody>();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude >= breakForceThreshold)
        {
            BreakObject();
        }
    }

    private void BreakObject()
    {
        
        GameObject Exemple = Instantiate(brokenObjectPrefab, transform.position, transform.rotation);
        Exemple.gameObject.tag = "Medaille1";
        
        foreach(Transform child in Exemple.transform) {
            child.tag = "Medaille1";
        }
        
        Rigidbody[] brokenPieces = brokenObjectPrefab.GetComponentsInChildren<Rigidbody>();
        foreach (var piece in brokenPieces)
        {
            if (piece != null)
            {
                piece.AddExplosionForce(300f, transform.position, 2f);
                //son casse
            }
        }
        Destroy(gameObject);
    }
}

