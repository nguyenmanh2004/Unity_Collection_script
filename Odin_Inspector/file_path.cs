using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Sirenix.OdinInspector;
public class file_path : MonoBehaviour
{
    [FilePath]
    public string UnityProjectPath;
    [FolderPath]
    public string UnityProjectPath1;

}
