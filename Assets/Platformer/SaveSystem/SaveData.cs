﻿using System;
using UnityEngine;

namespace Platformer.SaveSystem
{
    
    [Serializable]
    public class SaveData
    {
        private static SaveData _current;
        // if(Curent = null){ _current = saveData();}
        public static SaveData Current => _current ??= new SaveData();
        
        public int xp;
        public Vector3 playerPosition;
        public Quaternion playerRotation;
    }
}

 