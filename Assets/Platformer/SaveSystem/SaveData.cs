using System;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.SaveSystem
{
    
    [Serializable]
    public class SaveData
    {
        private static SaveData _current;
        // if(Curent = null)
        // {
        //  _current = saveData();}
        public static SaveData Current => _current ??= new SaveData();
        
        public float points;
        public Vector3 playerPosition;
        public Quaternion playerRotation;
        public List<string> listId;
    }
}

 