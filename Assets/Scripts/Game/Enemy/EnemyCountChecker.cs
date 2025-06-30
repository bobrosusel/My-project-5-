using System;
using UnityEngine;

public class EnemyCountChecker : MonoBehaviour
{
    public event Action EnemyDone;

    private void OnTransformChildrenChanged()
    {
        if (transform.childCount == 0)
        {
            EnemyDone.Invoke();
        }
    }

    public int GetChildrenCount()
    {
        return transform.childCount;
    }
}
