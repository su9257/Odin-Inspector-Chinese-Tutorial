using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonGroupAttributeExample : MonoBehaviour
{
    [ButtonGroup]
    private void A()
    {
    }

    [ButtonGroup]
    private void B()
    {
    }

    [ButtonGroup]
    private void C()
    {
    }

    [ButtonGroup]
    private void D()
    {
    }

    [Button(ButtonSizes.Large)]
    [ButtonGroup("My Button Group")]
    private void E()
    {
    }

    [GUIColor(0, 1, 0)]
    [ButtonGroup("My Button Group")]
    private void F()
    {
    }

    [BoxGroup("Titles", ShowLabel = false)]
    [TitleGroup("Titles/First Title")]
    public int A1;
    [BoxGroup("Titles/Boxed")]
    [TitleGroup("Titles/Boxed/Second Title")]
    public int B1;

    [TitleGroup("Titles/Boxed/Second Title")]
    public int C1;

    [TitleGroup("Titles/Horizontal Buttons")]
    [ButtonGroup("Titles/Horizontal Buttons/Buttons")]
    public void FirstButton() { }

    [ButtonGroup("Titles/Horizontal Buttons/Buttons")]
    public void SecondButton() { }
}
