using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TextIntro : MonoBehaviour
{

    //[SerializeField] private GameObject dialoguePlayer;//
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TMP_Text dialogueText;
    private float typingTime = 0.05f;
    [SerializeField, TextArea(10, 16)] private string[] dialogueLines;
    private bool isPlayerInRange;
    private bool didDialoguelogueStart;
    private int lineIndex;
    private bool didDialogueStart;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (!didDialoguelogueStart)
            {
                StartDialogue();
            }
            else if (dialogueText.text == dialogueLines[lineIndex])
            {
            
                SceneManager.LoadScene("Open_Wordl");
            }
        }
       
    }

    private void NextDialogueLines()
    {
        lineIndex++;
        if (lineIndex < dialogueLines.Length)
        {
            StartCoroutine(Showline());
        }
        else
        {
            didDialogueStart = false;
            dialoguePanel.SetActive(false);
            //dialoguePlayer.SetActive(true);//
            Time.timeScale = 1f;
        }
    }

    private void StartDialogue()
    {
        didDialoguelogueStart = true;
        dialoguePanel.SetActive(true);
        //dialoguePlayer.SetActive(false);//
        lineIndex = 0;
        Time.timeScale = 0f;
        StartCoroutine(Showline());
    }


    private IEnumerator Showline()
    {
        dialogueText.text = string.Empty;
        foreach (char ch in dialogueLines[lineIndex])
        {
            dialogueText.text += ch;
            yield return new WaitForSecondsRealtime(typingTime);
        }
    }
}


