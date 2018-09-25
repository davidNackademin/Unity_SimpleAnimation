using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlobbController : MonoBehaviour {


    Animator animator;

    int rollHash = Animator.StringToHash("Roll");
    int rollTriggerHash = Animator.StringToHash("roll");
    float rollPressedTime = 0;
    int rollPressedHash = Animator.StringToHash("rollPressedTime");
    int reactHash = Animator.StringToHash("react");

    ReactStateBehaviour[] reactStateBehaviours;
    RandomReactStateBeahaviour randomReactState;

    [HideInInspector]
    public GameObject particles;

    private void Start()
    {
        animator = GetComponent<Animator>();

        randomReactState = animator.GetBehaviour<RandomReactStateBeahaviour>();
        randomReactState.blobbController = this;

        reactStateBehaviours = animator.GetBehaviours<ReactStateBehaviour>();
        for (int i = 0; i < reactStateBehaviours.Length; i++) {
            reactStateBehaviours[i].blobbController = this;
        }
    }


    private void Update()
    {
        if ( Input.GetMouseButton(0) ) {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);

            if (hit.collider.gameObject == gameObject) {
                rollPressedTime += Time.deltaTime;
            }
        } else {
            rollPressedTime = 0;
        }
        animator.SetFloat(rollPressedHash, rollPressedTime);
    }




    private void OnMouseDown()
    {
        // play roll animation

        //animator.Play(rollHash);

        animator.SetTrigger(reactHash);

    }


}
