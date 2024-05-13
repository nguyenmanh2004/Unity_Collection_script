using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using System;
public class Color_Palette : MonoBehaviour
{
    // tạo thanh chọn màu
    [ColorPalette]
    public Color ColorOptions;
    // chọn màu cố định 
    [ColorPalette("Underwater")]
    public Color UnderwaterColor;
    // tự set màu 
    [ColorPalette("My Palette")]
    public Color MyColor;
    // tạo biến tên màu x
    public string DynamicPaletteName = "Clovers";
    // lấy tên color của biến để gán vào giá trị 
    [ColorPalette("$DynamicPaletteName")]
    public Color DynamicPaletteColor;
    public SpriteRenderer spriteRenderer;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void Update()
    {
        spriteRenderer.color = ColorOptions;
    }
}
