using UnityEngine;
using Microsoft.MixedReality.Toolkit.Input;

public class Radiost: MonoBehaviour, IMixedRealityPointerHandler
{
    public AudioSource audioSource;
    public string Suono;

    void Start()
    {
        // Verifica o aggiunge automaticamente un AudioSource all'oggetto
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            UnityEngine.Debug.LogWarning("Nessun Audio Source trovata");
        }

        // Controlla che il clip sia stato caricato correttamente
        if (audioSource.clip == null)
        {
            UnityEngine.Debug.LogWarning("AudioClip non trovato! Assicurati che 'miosuono.wav' o .mp3 sia in 'Assets/Suoni/'");
        }
    }

    public void OnPointerClicked(MixedRealityPointerEventData eventData)
    {
        if (audioSource != null && audioSource.clip != null)
        {
            GetComponent<AudioSource>().Play();
        }
    }

    // Interfacce richieste ma non usate
    public void OnPointerDown(MixedRealityPointerEventData eventData) { }
    public void OnPointerDragged(MixedRealityPointerEventData eventData) { }
    public void OnPointerUp(MixedRealityPointerEventData eventData) { }
}



