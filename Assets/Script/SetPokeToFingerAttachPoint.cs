using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SetPokeToFingerAttachPoint : MonoBehaviour
{
    public Transform attachPoint;
    private XRPokeInteractor _xrPokeInteractor;
    void Start()
    {
        _xrPokeInteractor = transform.parent.parent.GetComponentInChildren<XRPokeInteractor>();
        SetPokeAttachPoint();
    }

    void SetPokeAttachPoint()
    {
        if (attachPoint == null)
        {
            Debug.LogError("attachPoint is null"); return;
        }

        if (_xrPokeInteractor == null)
        {
            Debug.LogError("xrPokeInteractor is null"); return;
        }
        _xrPokeInteractor.attachTransform = attachPoint;
    }
}
