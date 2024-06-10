 
using UnityEngine;

namespace Platformer.SaveSystem
{   
    
    
    public class SaveTester : MonoBehaviour
    {
        public GameObject player;
        public SaveData SaveData;
        public CharacterController playerCharacterController;
        public HealthComponent healthComponent;
        public PointScript pointScript;
        
        
        public void OnClickedSave()
        {
            SaveData.playerPosition = player.transform.position;
            
            SaveData.playerRotation = player.transform.rotation;
            
            SaveData.points = healthComponent.points;

            SaveData.listId = healthComponent.pointsId;

           
            Debug.Log("saving");
            SerializationManager.Save("test", SaveData);
        }

        public void OnClickedLoad()
        {
            Debug.Log("Loading");
            SaveData = (SaveData) SerializationManager.Load("test");
            
            playerCharacterController.enabled = false;
            
            player.transform.position = SaveData.playerPosition;
            
            player.transform.rotation = SaveData.playerRotation;
            
            healthComponent.points = SaveData.points;

            healthComponent.pointsId = SaveData.listId;

            
            playerCharacterController.enabled = true;

        }
 
    }
}
                                                            