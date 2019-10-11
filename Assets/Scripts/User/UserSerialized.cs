using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UserSerialized
{
    public string characterName;    
    public SerializableVector3 position;        
    public int experience;
    public List<string> listArms;

    public UserSerialized(string characterName, SerializableVector3 position)
    {
        this.characterName = characterName;
        this.position = position;
        this.listArms = new List<string>();
    }      

    public string toString()
    {
        return MultiIdiomaManager.instance.GetTexto("MENUHUMANS_NAME") + ":" + characterName + "\n" +               
               "XP:" + experience + "\n" +
               "Armas: " + listArms;
    }

}

