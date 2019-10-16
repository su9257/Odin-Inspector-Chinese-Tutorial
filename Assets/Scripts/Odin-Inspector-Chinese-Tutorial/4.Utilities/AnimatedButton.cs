using Sirenix.OdinInspector.Editor;
using Sirenix.OdinInspector;
using Sirenix.OdinValidator;
using Sirenix.Serialization;
using Sirenix.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Image), typeof(Animator))]
public class AnimatedButton : UIBehaviour, IPointerClickHandler
{
    [Serializable]
    public class ButtonClickedEvent : UnityEvent { }
    [SerializeField]
    private ButtonClickedEvent m_animationClick = new ButtonClickedEvent();
    public ButtonClickedEvent onClick { get; set; } = new ButtonClickedEvent();

    public bool interactable = true;

    [Required("则此属性不能为null", MessageType = InfoMessageType.Error)]
    [BoxGroup("Editor")]
    [ShowInInspector, ReadOnly]
    [SerializeField]
    private Animator animator;

    [BoxGroup("Editor")]
    [ShowInInspector, ReadOnly]
    private bool blockInput;

    [BoxGroup("Editor/Time")]
    [SuffixLabel("单位时间：秒", Overlay = true)]
    [ProgressBar(0.0, 2.0f, 0, 1, 0, DrawValueLabel = true, Height = 20)]
    [LabelText("按钮动画播放时间")]
    public float animationTime = 0.2f;

    [BoxGroup("Editor/Time")]
    [SuffixLabel("单位时间：秒", Overlay = true)]
    [ProgressBar(0.0, 2.0f, 0, 1, 0, DrawValueLabel = true, Height = 20)]
    [LabelText("频繁点击按钮触发间隔")]
    [MinValue("@animationTime")]
    public float invokeIntervalTime = 0.5f;


    public virtual void OnPointerClick(PointerEventData eventData)
    {
        if (Application.isPlaying)
        {
            if (eventData.button != PointerEventData.InputButton.Left || !interactable)
            {
                return;
            }
        }
        if (!blockInput)
        {
            blockInput = true;
            Press();
            StartCoroutine(BlockInputTemporarily());
        }
    }
    private void Press()
    {
        if (!IsActive())
        {
            return;
        }
        m_animationClick?.Invoke();
        StartCoroutine(InvokeOnClickAction());
    }

    private IEnumerator InvokeOnClickAction()
    {
        yield return new WaitForSeconds(animationTime);
        onClick?.Invoke();
    }

    private IEnumerator BlockInputTemporarily()
    {
        yield return new WaitForSeconds(invokeIntervalTime);
        blockInput = false;
    }

    private void PressedAnimation()
    {
        // Do Something....
        animator.SetTrigger("Pressed");
    }

#if UNITY_EDITOR

    [BoxGroup("Editor/Button", showLabel: false)]
    [GUIColor(1, 0.9370f, 0)]
    [Button("初始化", ButtonSizes.Large, ButtonStyle.FoldoutButton)]
    [HideIf("@animator!=null&& m_animationClick.GetPersistentEventCount()>0")]
    public void InitEditorModel()
    {
        animator = GetComponent<Animator>();
        UnityAction unityAction = new UnityAction(PressedAnimation);
        UnityEditor.Events.UnityEventTools.AddPersistentListener(m_animationClick, unityAction);
    }

    [BoxGroup("Editor/Button", showLabel: false)]
    [GUIColor(0, 1, 0.9596f)]
    [Button("重置", ButtonSizes.Large, ButtonStyle.FoldoutButton)]
    [HideIf("@animator == null || m_animationClick.GetPersistentEventCount() == 0")]
    public void ResetEditorModel()
    {
        animator = null;
        animationTime = 0.2f;
        invokeIntervalTime = 0.5f;
        int count = m_animationClick.GetPersistentEventCount();
        for (int i = 0; i < count; i++)
        {
            UnityEditor.Events.UnityEventTools.RemovePersistentListener(m_animationClick, 0);
        }
    }
#endif
}