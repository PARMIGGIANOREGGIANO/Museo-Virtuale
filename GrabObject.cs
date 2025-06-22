using UnityEngine;
using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit.Utilities;

public class GrabObject : MonoBehaviour, IMixedRealityPointerHandler, IMixedRealityTouchHandler
{
    private bool isGrabbed = false;
    private Vector3 grabOffset;
    private Quaternion grabRotationOffset;
    private Vector3 handPosition;
    private Quaternion handRotation;

    public void OnPointerDown(MixedRealityPointerEventData eventData)
    {
        StartGrabbing(eventData.Pointer.Position, eventData.Pointer.Rotation);
    }

    public void OnPointerUp(MixedRealityPointerEventData eventData)
    {
        StopGrabbing();
    }

    public void OnPointerDragged(MixedRealityPointerEventData eventData) { }
    public void OnPointerClicked(MixedRealityPointerEventData eventData) { }

    public void OnTouchStarted(HandTrackingInputEventData eventData)
    {
        StartGrabbing(eventData.InputData, Quaternion.identity);
    }

    public void OnTouchCompleted(HandTrackingInputEventData eventData)
    {
        StopGrabbing();
    }

    public void OnTouchUpdated(HandTrackingInputEventData eventData) { }

    private void StartGrabbing(Vector3 position, Quaternion rotation)
    {
        if (!isGrabbed)
        {
            handPosition = position;
            handRotation = rotation;
            grabOffset = transform.position - position;
            grabRotationOffset = Quaternion.Inverse(rotation) * transform.rotation;
            isGrabbed = true;
        }
    }

    private void StopGrabbing()
    {
        isGrabbed = false;
    }

    void Update()
    {
        if (isGrabbed)
        {
            transform.position = handPosition + grabOffset;
            transform.rotation = handRotation * grabRotationOffset;
        }
    }
}
