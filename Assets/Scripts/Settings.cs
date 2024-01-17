using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] GameObject backgroundMusic;
    [SerializeField] Transform settingCloud;
    [SerializeField] Toggle fullscreentoggle;
    [SerializeField] Slider volumeSlider;
    public static float volume;
    static bool backgroundMusicIsOn;
    Vector3 camStartPos;
    bool inSettings;

    private void Start()
    {
        if (!backgroundMusicIsOn)
        {
            backgroundMusicIsOn = true;
            volume = 1;
            GameObject spawnedMusic = Instantiate(backgroundMusic, Vector3.zero, Quaternion.identity);
            DontDestroyOnLoad(spawnedMusic);
        }
        camStartPos = cam.transform.position;
        volumeSlider.value = volume;
    }

    public void Update()
    {
        if (inSettings && cam.transform.position.y < settingCloud.position.y)
        {
            cam.transform.position += transform.up * Time.deltaTime * 10;
        }
        
        if (!inSettings && cam.transform.position.y > camStartPos.y)
        {
            cam.transform.position -= transform.up * Time.deltaTime * 10;
        }

        Screen.fullScreen = fullscreentoggle.isOn;

        volume = volumeSlider.value;
        AudioListener.volume = volume;
    }

    public void StartGame()
    {
        LevelManager.ResetGame();
        StartCoroutine(SceneTransition());
    }

    public void GoToSettings()
    {
        inSettings = true;
    }

    public void ReturnToMainMenu()
    {
        inSettings = false;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    IEnumerator SceneTransition()
    {
        cam.orthographicSize -= 0.09f;
        yield return new WaitForSeconds(0.01f);
        if (cam.orthographicSize > 0)
        {
            StartCoroutine(SceneTransition());
        }
        else
        {
            SceneManager.LoadScene("Game");
        }
    }
}
