using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "StevenTypes/WeaponData", order = 1)]
public class Weapons : ScriptableObject
{
    public string weaponName;
    public int hitPoints;
    //assuming only one animation for the weapon
    public Animation weaponAnimation;
}
