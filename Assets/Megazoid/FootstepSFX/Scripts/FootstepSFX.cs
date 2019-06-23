using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepSFX : MonoBehaviour
{
    public GameObject _dustParticlePrefab;
    public List<AudioClip> _audioClips;

    private AudioSource _audioSource;
    private AudioSource _stoneAudioSource;
    private float _audioPitch = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        AudioSource[] sources = GetComponentsInChildren<AudioSource>(false);
        _stoneAudioSource = sources[1];
    }

    // Update is called once per frame
    void Update()
    { 
        if(Input.GetKeyDown(KeyCode.Space))
        {
            _audioSource.clip = _audioClips[(int)Random.Range(0.0f, _audioClips.Count - 0.1f)];
            _audioSource.pitch = _audioPitch + Random.Range(-0.25f, 0.0f);
            _audioSource.volume = _audioPitch + Random.Range(-0.1f, 0.2f);
            _stoneAudioSource.pitch = _audioPitch + Random.Range(-0.5f, 0.25f);
            _audioSource.Play();
            _stoneAudioSource.Play();

            Instantiate(_dustParticlePrefab, transform.position, Quaternion.identity);
            StartCoroutine(LowerVolumeOverTime(1.0f, _audioSource));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            _audioSource.clip = _audioClips[(int)Random.Range(0.0f, _audioClips.Count - 0.1f)];
            _audioSource.pitch = _audioPitch + Random.Range(-0.4f, 0.25f);
            _audioSource.volume = _audioPitch + Random.Range(-0.1f, 0.2f);
            _stoneAudioSource.pitch = _audioPitch + Random.Range(-0.5f, 0.25f);
            _audioSource.Play();
            _stoneAudioSource.Play();

            Instantiate(_dustParticlePrefab, transform.position, Quaternion.identity);
        }

        StartCoroutine(LowerVolumeOverTime(1.0f, _audioSource));
    }

    private IEnumerator LowerVolumeOverTime(float time, AudioSource audioSource)
    {
        float startVolume = audioSource.volume;
        float startTime = time;
        while (time > 0.0f)
        {
            yield return new WaitForSeconds(Time.deltaTime);
            time -= Time.deltaTime;
            audioSource.volume -= Time.deltaTime;
        }
    }
}
