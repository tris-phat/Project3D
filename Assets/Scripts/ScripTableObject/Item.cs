using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "ScriptableObject/Item", order = 1)]
public class Item : ScriptableObject
{
    public int Id;
    public string Name;
    public Sprite Image;
    public string Descripsion;
    public ItemType itemType;
    public GemMagicType gemType;

    public int Count;

    public bool StackAble;
    
    
}
public enum ItemType
{
    None =0,
    HealthPotion = 1,
    ManaPotion = 2,
    Sword =3,
    Bow = 4,
    Shield =5,
    Hammer= 6,
    RockMagic =7,
    Bomb=8,
    Map

}
public enum GemMagicType
{
    None,
    Green,
    Red
}
