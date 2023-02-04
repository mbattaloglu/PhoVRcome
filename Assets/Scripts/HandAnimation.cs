using UnityEngine;
using UnityEngine.InputSystem;

public class HandAnimation : MonoBehaviour
{
    //Sağ click
    public InputActionProperty pinchAnimationAction;
    //G
    public InputActionProperty gripAnimationAction;
    public Animator animator;

    private void Update()
    {
        animator.SetFloat("Trigger", pinchAnimationAction.action.ReadValue<float>());
        animator.SetFloat("Grip", gripAnimationAction.action.ReadValue<float>());
    }
}


