using System;
using System.Collections.Generic;
using UnityEngine;

public class WeaponViaInterface : MonoBehaviour
{
    public List<IEventHandler> onFireHandlers = new();
    
    public void Fire()
    {
        //...
        foreach (var handler in onFireHandlers)
        {
            handler.HandleEvent();
        }
        //...
    }
}

public class WeaponSfxViaInterface : MonoBehaviour, IEventHandler
{
    [SerializeField] private WeaponViaInterface weapon;
    private void OnEnable()
        => weapon.onFireHandlers.Add(this);

    private void OnDisable()
        => weapon.onFireHandlers.Remove(this);

    public void HandleEvent()
    {
        //...
        //Play sound
        Debug.Log($"{name}: played explosion sound :D");
        //...
    }
}public class WeaponVfxViaInterface : MonoBehaviour, IEventHandler
{
    [SerializeField] private WeaponViaInterface weapon;
    private void OnEnable()
        => weapon.onFireHandlers.Add(this);

    private void OnDisable()
        => weapon.onFireHandlers.Remove(this);

    public void HandleEvent()
    {
        //...
        //Show muzzle brake
        //Show explosion
        //Show sparks
        Debug.Log($"{name}: rendered shot :D");
        //...
    }
}

public interface IEventHandler
{
    void HandleEvent();
}
public interface IEventHandlerOneParameter
{
    void HandleEvent(int param);
}
