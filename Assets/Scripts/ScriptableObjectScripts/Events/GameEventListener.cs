using System;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class CustomResponse : UnityEvent<Component, object, string> { }

public class GameEventListener : MonoBehaviour
{
    public GameEvent gameEvent;

    public CustomResponse response;

    private void OnEnable()
    {
        gameEvent.RegisterListeners(this);
    }
    private void OnDisable()
    {
        gameEvent.UnregisterListeners(this);
    }
    public void OnEventRaised(Component sender, object data, string tag)
    {
        response.Invoke(sender, data, tag);
    }
}
