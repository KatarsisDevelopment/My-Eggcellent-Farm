using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class JumpAnim : MonoBehaviour
{
    private void OnEnable()
    {
        transform.DOLocalJump(transform.localPosition, 0.3f, 0, 0.3f).SetLoops(0,LoopType.Yoyo);
    }
}
