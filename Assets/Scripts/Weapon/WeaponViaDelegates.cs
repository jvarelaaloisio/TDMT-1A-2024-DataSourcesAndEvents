using System.Collections;
using UnityEngine;

public delegate void FireDelegate();
public class WeaponViaDelegates : MonoBehaviour
{
    public FireDelegate onFire;

    public void Fire()
    {
        //...
        onFire?.Invoke();
        //Option 2
        if (onFire != null)
        {
            onFire.Invoke();
        }
        //...
    }
}
public class WeaponSfxViaDelegate : MonoBehaviour
{
    [SerializeField] private WeaponViaDelegates weapon;
    private void OnEnable()
    {
        weapon.onFire += HandleEvent;
    }
    private void OnDisable()
    {
        weapon.onFire -= HandleEvent;
    }

    public void HandleEvent()
    {
        //...
        Debug.Log($"{name}: I Handled the event :D");
        //...
    }
}