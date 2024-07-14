using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class CustomResponse : UnityEvent<Component, object> { }

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
    public void OnEventRaised(Component sender, object data)
    {
        response.Invoke(sender, data);
    }
}
