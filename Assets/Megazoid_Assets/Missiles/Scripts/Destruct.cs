using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruct : MonoBehaviour
{
    public GameObject explosionPrefab;
    public float explosionForce = 50.0f;
    public List<AudioClip> _audioClips;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LowerVolumeOverTime(3.0f, GetComponent<AudioSource>()));
    }

    // Update is called once per frame
    void Update()
    {
        transform.forward = GetComponent<Rigidbody>().velocity;
    }

    private void OnCollisionEnter(Collision collision)
    {

        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.pitch = 1.0f + Random.Range(-0.25f, -0.1f);
        audioSource.volume = 1.0f + Random.Range(-0.1f, 0.2f);
        audioSource.clip = _audioClips[(int)Random.Range(0.0f, _audioClips.Count - 0.1f)];
        audioSource.Play();

        GetComponent<MeshCollider>().enabled = false;
        GetComponent<MeshRenderer>().enabled = false;
        GameObject.Destroy(gameObject, 3);
        StartCoroutine(BlastAfterFrame(collision));
    }

    private IEnumerator BlastAfterFrame(Collision collision)
    {
        yield return new WaitForEndOfFrame();

        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Collider[] colliders = Physics.OverlapSphere(transform.position, 20.0f / 5.0f);
        for (int i = 0; i < colliders.Length; i++)
        {
            Rigidbody rBody = colliders[i].GetComponent<Rigidbody>();
            if (rBody)
            {
                rBody.gameObject.SendMessage("DestroyBuilding", SendMessageOptions.DontRequireReceiver);
                rBody.AddExplosionForce(explosionForce, transform.position, 50.0f / 5.0f);
            }
        }
    }

    private IEnumerator LowerVolumeOverTime(float time, AudioSource audioSource)
    {
        float startVolume = audioSource.volume;
        float startTime = time;
        while (time > 0.0f)
        {
            yield return new WaitForSeconds(Time.deltaTime);
            time -= Time.deltaTime;
            audioSource.volume -= Time.deltaTime * 0.5f;
        }
    }
}
