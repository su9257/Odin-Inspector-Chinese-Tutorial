using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAttributeExample : MonoBehaviour
{


    [Button]
    private void Default()
    {
    }
    [Button]
    private void Default(float a, float b, GameObject c)
    {
    }

    [Button]
    private void Default(float t, float b, float[] c)
    {
    }
    public string ButtonName = "Dynamic button name";

    public bool Toggle;

    [Button("$ButtonName")]
    private void DefaultSizedButton()
    {
        this.Toggle = !this.Toggle;
    }

    [Button("@\"Expression label: \" + DateTime.Now.ToString(\"HH:mm:ss\")")]
    public void ExpressionLabel()
    {
        this.Toggle = !this.Toggle;
    }

    [Button("Name of button")]
    private void NamedButton()
    {
        this.Toggle = !this.Toggle;
    }

    [Button(ButtonSizes.Small), GUIColor(0.3f, 0.8f, 1)]
    private void SmallButton()
    {
        this.Toggle = !this.Toggle;
    }

    [Button(ButtonSizes.Medium), GUIColor(0.4f, 0.4f, 1)]
    private void MediumSizedButton()
    {
        this.Toggle = !this.Toggle;
    }

    [Button(ButtonSizes.Large), GUIColor(0.5f, 0.8f, 0.5f)]
    private void LargeButton()
    {
        this.Toggle = !this.Toggle;
    }

    [Button(ButtonSizes.Gigantic),GUIColor(0.6f, 0.8f, 0)]
    private void GiganticButton()
    {
        this.Toggle = !this.Toggle;
    }


    [Button(90)]
    private void CustomSizedButton()
    {
        this.Toggle = !this.Toggle;
    }


    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    private int FoldoutButton(int a = 2, int b = 2)
    {
        return a + b;
    }

    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    private void FoldoutButton(int a, int b, ref int result)
    {
        result = a + b;
    }

    [Button(ButtonSizes.Large, ButtonStyle.Box)]
    private void Box(float a, float b, out float c)
    {
        c = a + b;
    }

    [Button(ButtonSizes.Large, ButtonStyle.Box)]
    private void Box(int a, float b, out float c)
    {
        c = a + b;
    }
    [Button(ButtonSizes.Large, ButtonStyle.CompactBox)]
    public void CompactBox(int a, float b, out float c)
    {
        c = a + b;
    }


    [Button(ButtonStyle.CompactBox, Expanded = true)]
    private void CompactExpanded(float a, float b, GameObject c)
    {
    }

    [Button(ButtonSizes.Medium, ButtonStyle.Box, Expanded = true)]
    private void FullExpanded(float a, float b)
    {
    }
}