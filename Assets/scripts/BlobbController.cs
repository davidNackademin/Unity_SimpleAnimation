using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlobbController : MonoBehaviour {


    Animator animator;

    int rollHash = Animator.StringToHash("Roll");
    int rollTriggerHash = Animator.StringToHash("roll");
    float rollPressedTime = 0;
    int rollPressedHash = Animator.StringToHash("rollPressedTime");

    private void Start()
    {
        animator = GetComponent<Animator>();
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




    //private void OnMouseDown()
    //{
    //    // play roll animation

    //    //animator.Play(rollHash);

    //    animator.SetTrigger(rollTriggerHash);

    //}


}
