using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    [SerializeField] private GameObject dialogueNPC;
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TMP_Text dialogueText;
    private float typingTime = 0.05f;
    [SerializeField, TextArea(4, 6)] private string[] dialogueLines;
    private bool isPlayerInRange;
    private bool didDialoguelogueStart;
    private int lineIndex;
    private bool didDialogueStart;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.V))
        {
            if (!didDialoguelogueStart)
            {
                StartDialogue();
            }
            else if (dialogueText.text == dialogueLines[lineIndex])
            {
                NextDialogueLines();
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
            //dialogueNPC.SetActive(true);
            Time.timeScale = 1f;
        }
    }

    private void StartDialogue()
    {
        didDialoguelogueStart = true;
        dialoguePanel.SetActive(true);
        //dialogueNPC.SetActive(false);
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




    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            isPlayerInRange = true;
        //dialogueNPC.SetActive(true);
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            isPlayerInRange = false;
        //dialogueNPC.SetActive(false);
    }
}
