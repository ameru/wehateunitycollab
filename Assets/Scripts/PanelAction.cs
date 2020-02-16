using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PanelAction : MonoBehaviour
{
    public UnityEvent onClick;

    public void DoAction()
    {
        onClick.Invoke();
        Destroy(gameObject);
    }
}
