using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventBus 
{

    private static Hashtable EventHashtable = new Hashtable();

    private static Dictionary<string,Hashtable> EventHashtableChannel = new Dictionary<string, Hashtable>();

    private static void AddListenToHashtable<T>(Hashtable hashtable,UnityAction<T> action) where T : class
    {
        Type key = typeof(T);
        if (hashtable.ContainsKey(key))
        {
            UnityEvent<T> unityEvent = (UnityEvent<T>)hashtable[key];
            unityEvent.AddListener(action);
        }
        else
        {
            UnityEvent<T> unityEvent = new UnityEvent<T>();
            unityEvent.AddListener(action);
            hashtable.Add(typeof(T), unityEvent);
        }
    }
    public static void AddListenOnce<T>(UnityAction<T> action) where T : class
    {
        AddListen<T>(action);
        AddListen<T>(
            (_) => { 
            RemoveListen<T>(action);
        });
    }
    public static void AddListen<T>(UnityAction<T> action) where T : class
    {
        AddListenToHashtable<T>(EventHashtable, action);
    }
    public static void AddListenWithChannelOnce<T>(string channel, UnityAction<T> action) where T : class
    {
        AddListenWithChannel<T>(channel, action);
        AddListenWithChannel<T>(channel, 
            (_) => {
            RemoveListenWithChannel<T>(channel, action); 
        });
    }
    public static void AddListenWithChannel<T>(string channel,UnityAction<T> action) where T : class
    {
        if (string.IsNullOrEmpty(channel))
        {
            Debug.LogError("channel is Null");
            return;
        }

        if (EventHashtableChannel.ContainsKey(channel))
        {
            AddListenToHashtable<T>(EventHashtableChannel[channel], action);
        }
        else
        {
            Hashtable tmpHashtable = new Hashtable();
            EventHashtableChannel.Add(channel, tmpHashtable);
            AddListenToHashtable<T>(tmpHashtable, action);
        }
    }

    private static void RemoveListenWithHashtable<T>(Hashtable hashtable,UnityAction<T> action) where T : class
    {
        Type key = typeof(T);

        if (hashtable.ContainsKey(key))
        {
            UnityEvent<T> unityEvent = (UnityEvent<T>)hashtable[key];
            if (unityEvent != null)
            {
                unityEvent.RemoveListener(action);
            }
        }
    }

    public static void RemoveListen<T>(UnityAction<T> action) where T:class
    {
        RemoveListenWithHashtable<T>(EventHashtable,action);
    }
    public static void RemoveListenWithChannel<T>(string channel,UnityAction<T> action) where T : class
    {
        if (string.IsNullOrEmpty(channel))
        {
            Debug.LogError("channel is Null");
            return;
        }

        Type key = typeof(T);
        if (EventHashtableChannel.ContainsKey(channel))
        {
            RemoveListenWithHashtable<T>(EventHashtableChannel[channel], action);
        }
    }

    private static void FireWithHashtable<T>(Hashtable hashtable,T msg)
    {
        Type key = typeof(T);
        if (hashtable.ContainsKey(key))
        {
            UnityEvent<T> unityEvent = (UnityEvent<T>)hashtable[key];
            unityEvent.Invoke(msg);
        }
    }

    public static void Fire<T>(T msg) where T : class
    {
        FireWithHashtable<T>(EventHashtable, msg);
    }
    public static void FireWithChannel<T>(string channel,T msg) where T : class
    {
        if (string.IsNullOrEmpty(channel))
        {
            Debug.LogError("channel is Null");
            return;
        }

        if (EventHashtableChannel.ContainsKey(channel))
        {
            FireWithHashtable(EventHashtableChannel[channel], msg);
        }
    }
    public static void FireAllChannel<T>(T msg) where T : class
    {
        foreach (var item in EventHashtableChannel)
        {
            FireWithHashtable<T>(item.Value, msg);
        }
    }

    public static void RemoveAllListen()
    {
        EventHashtable.Clear();
        EventHashtableChannel.Clear();
    }
}
