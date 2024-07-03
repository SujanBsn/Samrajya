using UnityEngine;
using UnityEngine.Events;
public class GameEventListener : MonoBehaviour
{
    public GameEvent gameEvent;

    public UnityEvent response;

    private void OnEnable()
    {
        gameEvent.RegisterListeners(this);
    }
    private void OnDisable()
    {
        gameEvent.UnregisterListeners(this);
    }
    public void OnEventRaised()
    {
        response.Invoke();
    }
}
