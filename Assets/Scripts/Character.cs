﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public bool IsMoving { get; private set; }

    [SerializeField]
    private float moveSpeed;

    private CharacterAnimator animator;

    private void Awake()
    {
        animator = GetComponent<CharacterAnimator>();
    }

    public IEnumerator Move(Vector2 moveVec)
    {
        animator.MoveX = moveVec.x;
        animator.MoveY = moveVec.y;

        var targetPos = transform.position;
        targetPos.x += moveVec.x;
        targetPos.y += moveVec.y;

        if (!IsWalkable(targetPos))
            yield break;

        IsMoving = true;

        while ((targetPos - transform.position).sqrMagnitude >= Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
            yield return null;
        }
        transform.position = targetPos;

        IsMoving = false;
    }

    public void HandleUpdate()
    {
        animator.IsMoving = IsMoving;
    }

    private bool IsWalkable(Vector3 targetPos)
    {
        if (Physics2D.OverlapCircle(targetPos, 0.2f, GameLayers.i.SolidLayer | GameLayers.i.InteractablesLayer | GameLayers.i.SellerLayer) != null)
        {
            return false;
        }

        return true;
    }

    public CharacterAnimator Animator
    {
        get => animator;
    }

}
