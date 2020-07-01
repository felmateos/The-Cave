using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogBox : MonoBehaviour
{
    public GameObject dialogBox;
    public TMP_Text dialogText;
    public Animator animator;

    public void Dialog(string text) {
        
        dialogBox.SetActive(true);
        dialogText.text = text;
        animator.SetTrigger("pop");
    }
}
