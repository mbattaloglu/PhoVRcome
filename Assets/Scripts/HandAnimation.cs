using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HandAnimation : MonoBehaviour
{
    //Right click
    public InputActionProperty pinchAnimationAction;
    //G 
    public InputActionProperty gripAnimationAction;

    public Animator handAnimator;
    private void Update()
    {
        TriggerAnimation();
        GripAnimation();
    }

    private void TriggerAnimation()
    {
        float triggerValue = pinchAnimationAction.action.ReadValue<float>();
        handAnimator.SetFloat("Trigger", triggerValue);
    }

    private void GripAnimation()
    {
        float gripValue = gripAnimationAction.action.ReadValue<float>();
        handAnimator.SetFloat("Grip", gripValue);
    }
}
