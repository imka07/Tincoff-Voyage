using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Monologe : MonoBehaviour
{
    public int index;
    [SerializeField] private TincoffHelper tincoffHelper;
    [SerializeField] private GameObject map;

    [Header("Audio Settings")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip[] audioClips;
    [SerializeField] private AudioClip lastClip;

    [Space(10)]

    [Header("UI Settings")]
    [SerializeField] private Text dialogTxt;
    [SerializeField] private GameObject dialogBubble, nexButton, tutorial;
    [SerializeField] private float dialogTxtSpeed;
    [SerializeField] private string[] lines;


    private void Start()
    {
        tutorial.SetActive(false);
        dialogTxt.text = string.Empty;
    }

    public void NextMessage()
    {
        if (dialogTxt.text == lines[index])
        {
            //StopAudio(); // Остановка воспроизведения аудио
            IsNextLine();
         // Воспроизводим аудио для нового предложения

            //if (index == lines.Length - 1 && nexButton != null)
            //{
            //    nexButton.SetActive(false); // Выключаем кнопку
            //}
        }
        else
        {
            StopAllCoroutines();
            dialogTxt.text = lines[index];

        }
    }


    public void StartDialog()
    {
        nexButton.SetActive(true);
        dialogTxt.text = string.Empty;
        index = 0;
        StartCoroutine(TypeLine());
    }

    //void PlayAudioForCurrentLine()
    //{
    //    // Проверяем, что индекс не выходит за пределы массива
    //    if (index < lines.Length && index >= 0 && audioSource != null)
    //    {
    //        // Воспроизводим аудио для текущего предложения
    //        audioSource.clip = audioClips[index];
    //        audioSource.Play();
    //    }
    //}


    //void StopAudio()
    //{
    //    if (audioSource != null && audioSource.isPlaying)
    //    {
    //        audioSource.Stop();
    //    }
    //}


    public void CloseDialog()
    {
        StopAllCoroutines();
        nexButton.SetActive(false);
        if (index < lines.Length - 1)
        {
            index = lines.Length - 1;
            dialogTxt.text = string.Empty;
            audioSource.clip = lastClip;
            audioSource.Play();
            StartCoroutine(CloseDialogCoroutine());
        }
        else
        {
            dialogTxt.text = string.Empty;
            dialogBubble.SetActive(false);
        }
    }


    IEnumerator CloseDialogCoroutine()
    {
        string onCloseSentence = "Приятно было провести с тобой время! Еще увидимся!";
        foreach (char c in onCloseSentence.ToCharArray())
        {
            dialogTxt.text += c;
            yield return new WaitForSeconds(dialogTxtSpeed);
        }
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            dialogTxt.text += c;
            yield return new WaitForSeconds(dialogTxtSpeed);
        }
    }
    
    void IsNextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            dialogTxt.text = string.Empty;
            StartCoroutine(TypeLine());  
        }
        else
        {
            UIManager.Instance.PlaySounds(1);
            map.SetActive(true);
            tutorial.SetActive(true);
            dialogBubble.SetActive(false);
            dialogTxt.text = string.Empty;
        }
    }
}
