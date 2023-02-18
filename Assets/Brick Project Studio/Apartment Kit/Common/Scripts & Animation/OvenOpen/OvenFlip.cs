using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace SojaExiles
{
	public class OvenFlip: MonoBehaviour
	{
		private Animator animator;
		private bool isOpen;
		private Transform player;

		private void Start()
		{
			isOpen = false;
			gameObject.AddComponent<XRSimpleInteractable>();
			animator = GetComponent<Animator>();
			player = GameObject.FindWithTag("Player").transform;
			GetComponent<XRSimpleInteractable>().activated.AddListener(Interact);
		}

        private void Interact(ActivateEventArgs arg0)
        {
            float dist = Vector3.Distance(player.position, transform.position);
			if (dist < 15)
			{
				switch (isOpen)
				{
					case true:
						StartCoroutine(Close());
						break;
					case false:
						StartCoroutine(Open());
						break;
				}
			}
        }

		private IEnumerator Open()
		{
			animator.Play("OpenOven");
			isOpen = true;
			yield return new WaitForSeconds(.5f);
		}

		private IEnumerator Close()
		{
			animator.Play("ClosingOven");
			isOpen = false;
			yield return new WaitForSeconds(.5f);
		}
	}
}