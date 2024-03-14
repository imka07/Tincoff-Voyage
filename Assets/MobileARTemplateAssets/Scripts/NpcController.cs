using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NpcController : MonoBehaviour
{
    int index;
    bool hasMet = false;
    public int npcIndex;

    [Header("Audio Settings")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip[] audioClips;
    [SerializeField] private AudioClip lastClip;

    [Space(10)]

    [Header("UI Settings")]
    [SerializeField] private Text dialogTxt;
    [SerializeField] private GameObject dialogBubble, nexButton, backward;
    [SerializeField] private float dialogTxtSpeed;
    [SerializeField] private string[] linesFirstInteraction;
    [SerializeField] private string[] linesSecondInteraction;
    [SerializeField] private string[] linesQuestCompleted;


    private void Start()
    {
        dialogTxt.text = string.Empty;
    }

    public void NextMessage()
    {
        if (dialogTxt.text == linesFirstInteraction[index] || dialogTxt.text == linesSecondInteraction[index])
        {
            IsNextLine();
        }
        else
        {
            StopAllCoroutines();
            dialogTxt.text = linesFirstInteraction[index];

        }
    }

    public void BackWardController(bool inScene)
    {
        backward.SetActive(inScene);
    }

    public void StartDialog()
    {
        dialogBubble.SetActive(true);
        dialogTxt.text = string.Empty;
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in linesFirstInteraction[index].ToCharArray())
        {
            dialogTxt.text += c;
            yield return new WaitForSeconds(dialogTxtSpeed);
        }
    }

    void IsNextLine()
    {
        if (index < linesFirstInteraction.Length - 1 || index < linesSecondInteraction.Length - 1)
        {
            index++;
            dialogTxt.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            dialogBubble.SetActive(false);
            dialogTxt.text = string.Empty;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (!hasMet)
            {
                StartDialog();
                hasMet = true;
                QuestManager.instance.StartQuest(npcIndex);
            }
            else if (QuestManager.instance.questCompleted[npcIndex])
            {
                // Выводите строки после выполнения квеста
                linesFirstInteraction = linesQuestCompleted;
                StartDialog();
                QuestManager.instance.ControlBackward(npcIndex, false);
            }
            else
            {
                linesFirstInteraction = linesSecondInteraction;
                StartDialog();
            }
        }
    }
}
