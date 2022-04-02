using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Game_Scripts.Keys_Manager;
using Player;
using UnityEngine;
using UnityEngine.InputSystem;

public class KeyCounterManager : MonoBehaviour
{
    public InputAction actionEvent;
    public List<AudioClip> AudioClips = new List<AudioClip>();
    public AudioSource audioSource;

    private KeyManager _keyManager;
    private List<KeyController> _collectedKeys = new List<KeyController>();

    void Start()
    {
        actionEvent.Enable();
        actionEvent.performed += CallBack;

        _keyManager = KeyManager.Instance;

        _keyManager.CollectedEvent += OnKeyCollected;
    }

    private void OnKeyCollected(KeyController key)
    {
        _collectedKeys.Add(key);
        PlayerKeyInventory.AddOneKey();
    }

    private void CallBack(InputAction.CallbackContext obj)
    {
        
        var count =_collectedKeys.Count;
        StartCoroutine(SoundCoroutine(count));
    }

    public IEnumerator SoundCoroutine(int size)
    {
        var wait = new WaitForSeconds(1.5f);
        for (int i = 0; i < size; i++)
        {
            audioSource.PlayOneShot(AudioClips[i]);
            yield return wait;
        } 
        yield break;
    }
}