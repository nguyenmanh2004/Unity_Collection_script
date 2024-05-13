using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using System;

public class Toggles : MonoBehaviour
{
    // b?t toggle
    [Toggle("Enabled")] 
    // t?o toggle m?i 
    public MyToggleable Toggler = new MyToggleable();

    public ToggleableClass Toggleable = new ToggleableClass();
    // khai báo l?p 
    [Serializable]
    public class MyToggleable
    {
        
        public bool Enabled;
        public int MyValue;
    }

    // khi b?t toggle s? show ra 
    [Serializable, Toggle("Enabled")]
    public class ToggleableClass
    {
        public bool Enabled;
        public string Text;
    }



}
