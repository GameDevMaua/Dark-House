using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class KeyCounterManager : MonoBehaviour
{
    public InputAction actionEvent;
    public GameObject keys;
    public List<AudioClip> AudioClips = new List<AudioClip>();
    public List<GameObject> keys2;
    public AudioSource audioSource;
    void Start()
    {
        actionEvent.Enable();
        actionEvent.performed += CallBack;

        foreach (Transform key in keys.transform)
        {
            if (key.gameObject.activeInHierarchy)
            {
                keys2.Add(key.gameObject);
            }
        }
    }

    private void CallBack(InputAction.CallbackContext obj)
    {
        /*print(obj.phase);
        int count = 0;
        foreach (Transform key in keys.transform)
        {
            var active = key.GetComponent<Collider2D>().enabled && key.gameObject.activeInHierarchy;
            if (active)
            {
                count += 1;
            }
        }
        
        print(count);*/

        var count = keys2.Count((o => !o.GetComponent<Collider2D>().enabled));
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
    // Update is called once per frame
    void Update()
    {
        
    }
}