using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private const string PLAYER_RUN_ANIM = "isRunning";

    [Header("Player script")]
    [SerializeField] private PlayerController controller;

    [Header("Animator")]
    [SerializeField] private Animator anim;

    // Update is called once per frame
    void Update()
    {
        anim.SetBool(PLAYER_RUN_ANIM, controller.isRunning);
    }
}
