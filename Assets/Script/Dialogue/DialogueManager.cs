﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
   public Text nameofText;
   public Text dialogueText;
public Animator animator;

   private Queue<string> sentences;

    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("IsOpen",true);
        nameofText.text = dialogue.name;

        sentences.Clear();
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextsentence();
    }

    public void DisplayNextsentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text ="";
        foreach(char letter in sentence.ToCharArray())
        {
                dialogueText.text += letter;
                yield return  null;        }
    }
    void EndDialogue()
    {
                animator.SetBool("IsOpen",false);

    }
   
}
