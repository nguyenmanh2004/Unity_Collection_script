using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CopyPasteSystem : MonoBehaviour
{
    public TMP_InputField inputField;
    // copy từ trên game 
    public void CopyToClipboard()
    {
        TextEditor textEditor = new TextEditor();
        textEditor.text = inputField.text;
        textEditor.SelectAll();
        textEditor.Copy();  
    }
    // paste vào InputField những gì đã copy
    public void PasteFromClipboard()
    {
        TextEditor textEditor = new TextEditor();
        textEditor.multiline = true;
        textEditor.Paste();  //Copy string from Clipboard to textEditor.text
        inputField.text = textEditor.text;
    }
}
