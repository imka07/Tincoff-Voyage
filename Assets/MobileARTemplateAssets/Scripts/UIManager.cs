using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    [SerializeField] private GameObject messages, greetingPanel, map, pausePanel, finalPanel;
    [SerializeField] private Monologe monologe;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip[] audioClips;

    public AudioSource musicSource;
    public Toggle musicToggle;

    public void StartMessage()
    {
        messages.SetActive(true);
        monologe.StartDialog();
        PlaySounds(0);
        greetingPanel.SetActive(false);
    }

    public void PlaySounds(int index)
    {
        audioSource.clip = audioClips[index];
        audioSource.Play();
    }

    public void PauseController(bool active)
    {
        pausePanel.SetActive(active);
    }

    public void RestartScene()
    {
        // Получаем индекс текущей сцены
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Перезагружаем текущую сцену
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void FinalPanel()
    {
        finalPanel.SetActive(true);
    }

    public void JuniorLink()
    {
        Application.OpenURL("https://www.tinkoff.ru/cards/debit-cards/tinkoff-black/junior/");
    }

    private void Start()
    {
        musicToggle.isOn = musicSource.isPlaying;
        Instance = this;
        map.SetActive(false);
        messages.SetActive(false);
    }

    public void ToggleMusic()
    {
        if (musicToggle.isOn)
        {
            // Включаем музыку
            musicSource.Play();
        }
        else
        {
            // Выключаем музыку
            musicSource.Stop();
        }




    }
}
