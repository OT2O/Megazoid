using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleBuilding : MonoBehaviour
{
    public GameObject destroyedVersion;
    public List<AudioClip> _audioClips;

    //private void OnMouseDown() 
    //{
    //    Instantiate(destroyedVersion, transform.position, transform.rotation);
    //    Destroy(gameObject);
    //}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude > 20.0f)
        {
            DestroyBuilding();
        }

    }

    public void DestroyBuilding()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.clip = _audioClips[(int)Random.Range(0.0f, _audioClips.Count - 0.1f)];
        audioSource.pitch = audioSource.pitch + Random.Range(-0.75f, -0.65f);
        audioSource.volume = audioSource.volume + Random.Range(-0.1f, 0.2f);
        audioSource.Play();

        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<MeshCollider>().enabled = false;
        Instantiate(destroyedVersion, transform.position, transform.rotation);
        StartCoroutine(LowerVolumeOverTime(3.0f, audioSource));
        Destroy(gameObject, 3.0f);
    }

    private IEnumerator LowerVolumeOverTime(float time, AudioSource audioSource)
    {
        float startVolume = audioSource.volume;
        float startTime = time;
        while(time > 0.0f)
        {
            yield return new WaitForSeconds(Time.deltaTime);
            time -= Time.deltaTime;
            audioSource.volume -= Time.deltaTime * 0.5f;
        }
    }
}
