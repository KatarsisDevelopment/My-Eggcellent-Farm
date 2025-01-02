using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Follower : MonoBehaviour
{
    public Transform MovePos;
    private void OnEnable()
    {
       transform.DOJump(MovePos.position, 1f, 1, 1f);
    }
    private void Update()
    {
        transform.position = MovePos.transform.position;
    }
}
