using Sirenix.OdinInspector;
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
    public int A1;
    [BoxGroup("Titles/Boxed")]
    public int B1;
    public int C1;
    [ButtonGroup("Titles/Buttons")]
    public void FirstButton() { }
    [ButtonGroup("Titles/Buttons")]
    public void SecondButton() { }
}