using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(RawImage))]
[RequireComponent(typeof(AspectRatioFitter))]
[RequireComponent(typeof(AudioSource))]
public class SplashScreen : MonoBehaviour
{
    public MovieTexture[] movies;
    public float minWaitTime = 1.0f;
    public string nextScene = "MainMenu";

    RawImage _rawImage;
    AspectRatioFitter _aspectRatioFitter;
    AudioSource _audioSource;

    int _playingMovieIndex = -1;
    MovieTexture _playingMovie { get { return _playingMovieIndex < 0 ? null : movies[_playingMovieIndex]; } }

    void Start()
    {
        _rawImage = GetComponent<RawImage>();
        _aspectRatioFitter = GetComponent<AspectRatioFitter>();
        _audioSource = GetComponent<AudioSource>();
        Play(0);
    }

    void Play(int index)
    {
        if (_playingMovie != null)
        {
            _playingMovie.Stop();
            _audioSource.clip = null;
        }

        _playingMovieIndex = index;
        _aspectRatioFitter.aspectRatio = (float)_playingMovie.width / (float)_playingMovie.height;
        _rawImage.texture = _playingMovie;
        _audioSource.clip = _playingMovie.audioClip;
        _playingMovie.Play();
    }

    void Update()
    {
        minWaitTime -= Time.deltaTime;
        if ((minWaitTime <= 0 && Input.anyKeyDown) || !_playingMovie.isPlaying)
        {
            if (_playingMovieIndex + 1 < movies.Length)
                Play(_playingMovieIndex + 1);
            else
                SceneManager.LoadScene(nextScene);
        }
    }
}
