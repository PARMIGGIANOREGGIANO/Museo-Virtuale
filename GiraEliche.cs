using UnityEngine;
using Microsoft.MixedReality.Toolkit.Input;
using System.Diagnostics;
using System.Collections.Specialized;

public class GiraEliche : MonoBehaviour, IMixedRealityPointerHandler
{
    public GameObject prop01_1;
    private Vector3 pos;
    private float posX, posY, posZ;
    private int i;

    void Start()
    {
        
        posX = prop01_1.transform.position.x;
        posY = prop01_1.transform.position.y;
        posZ = prop01_1.transform.position.z;
        i = 0;

    }
    void Gira()
    {
        for (i = 1; i <= 200; i++) {
            prop01_1.transform.Rotate(Vector3.down * i * 40f);
            wa
        }
    }

    public void OnPointerClicked(MixedRealityPointerEventData eventData)
    {
        Gira();
    }

    // Interfacce richieste ma non usate
    public void OnPointerDown(MixedRealityPointerEventData eventData) { }
    public void OnPointerDragged(MixedRealityPointerEventData eventData) { }
    public void OnPointerUp(MixedRealityPointerEventData eventData) { }
}




