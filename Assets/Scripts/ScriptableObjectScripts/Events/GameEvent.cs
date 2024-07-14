using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameEventObject", menuName = "ScriptableObjects/GameEvent")]
public class GameEvent : ScriptableObject
{
    public List<GameEventListener> listeners = new();

    public void Raise(Component sender, object data)
    {
        foreach (GameEventListener listener in listeners)
        {
            listener.OnEventRaised(sender, data);
        }
    }

    public void RegisterListeners(GameEventListener listener)
    {
        if(!listeners.Contains(listener))
            listeners.Add(listener);
    } 
    public void UnregisterListeners(GameEventListener listener)
    {
        if(listeners.Contains(listener))
            listeners.Remove(listener);
    }

}
