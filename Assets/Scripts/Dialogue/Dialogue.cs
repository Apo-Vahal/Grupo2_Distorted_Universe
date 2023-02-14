using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    [System.Serializable]
    struct Conver
    {
        public string[] lineas;
    }

    //[SerializeField] private GameObject dialogueNPC;
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TMP_Text dialogueText;
    private float typingTime = 0.05f;
    [SerializeField] private Conver[] dialogueLines;
    private bool isPlayerInRange;
    private bool didDialoguelogueStart;
    private int lineIndex;
    public int converIndex = 0;
    private bool didDialogueStart;

    //Update is called once per frame
    void Update()
    {
        if (isPlayerInRange && Input.GetKey(KeyCode.V))
        {
            if (!didDialoguelogueStart)
            {
                StartDialogue();
            }
            else if (dialogueText.text == dialogueLines[converIndex].lineas[lineIndex])
            {
                NextConver();
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
    private void NextConver()
    {
        if (lineIndex == dialogueLines.Length)
        {
            converIndex++;
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
    //if (lineIndex == dialogueLines.Length)
    //{
    //    didDialogueStart = false;
    //    dialoguePanel.SetActive(false);
    //    //dialogueNPC.SetActive(true);
    //    Time.timeScale = 1f;

    //}


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
        foreach (char ch in dialogueLines[converIndex].lineas[lineIndex])
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
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using TMPro;

//public class Dialogue : MonoBehaviour
//{
//    [System.Serializable,]
//    struct Conver
//    {
//        [SerializeField, TextArea(4, 6)] public string[] dialogueLines; //Lineas que tiene el convers
//    }

//    //[SerializeField] private GameObject dialogueNPC;
//    [SerializeField] private GameObject dialoguePanel;
//    [SerializeField] private TMP_Text dialogueText;
//    private float typingTime = 0.05f;
//    [SerializeField] private Conver[] convers;
//    private bool isPlayerInRange;
//    private bool didDialoguelogueStart; // Indica el dialogo esta activo
//    private int lineIndex; // Indica que linea se esta mostrando
//    public int converIndex = 0;
//    private bool didDialogueStart;

//    //Update is called once per frame
//    void Update()
//    {
//        {
//            if (isPlayerInRange && Input.GetKey(KeyCode.V))
//            {
//                if (!didDialoguelogueStart) // si el dialogo no esta activo
//                {
//                    StartDialogue(); //se activa
//                }
//                else if (dialogueText.text == convers[converIndex].dialogueLines[lineIndex]) // para saber que se esta mostrando toda la linea
//                {
//                    NextDialogueLines();
//                    NextConverIndex();
//                }
//                // return;
//            }
//        }
//    }
//    private void NextDialogueLines()
//    {
//        lineIndex++; // para mostrar la siguiente linea
//        if (lineIndex < convers[converIndex].dialogueLines[lineIndex].Length) // para saber que aun no llegamos a la ultima linea de dialogo
//        {
//            StartCoroutine(Showline());
//        }
//        else // para cuando ya no haya mas linea de dialogo
//        {

//            didDialogueStart = false;
//            dialoguePanel.SetActive(false);
//            // dialogueNPC.SetActive(true);
//            Time.timeScale = 1f;
//        }
//    }

//    private void NextConverIndex()
//    {
//        converIndex++;
//        if ()
//        {
//            StartCoroutine(Showline());
//        }
//    }

//    private void StartDialogue()
//    {
//        didDialoguelogueStart = true;
//        dialoguePanel.SetActive(true);
//        // dialogueNPC.SetActive(false);
//        lineIndex = 0; // Para que se muestre la primera linea de dialogo
//        Time.timeScale = 0f;
//        StartCoroutine(Showline());
//    }
//    private IEnumerator Showline() // Para el efecto de escritura 
//    {
//        dialogueText.text = string.Empty;
//        foreach (char ch in convers[converIndex].dialogueLines[lineIndex]) // caracter a caracter
//        {
//            dialogueText.text += ch;
//            yield return new WaitForSecondsRealtime(typingTime);
//        }
//    }
//    private void OnTriggerEnter(Collider collision)
//    {
//        if (collision.gameObject.CompareTag("Player"))
//            isPlayerInRange = true;
//        //dialogueNPC.SetActive(true);
//    }

//    private void OnTriggerExit(Collider collision)
//    {
//        if (collision.gameObject.CompareTag("Player"))
//            isPlayerInRange = false;
//        //dialogueNPC.SetActive(false);
//    }
//}

