using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData 
{
    public float[] positionPacMan;

public enum GhostType {
        Red,
        Pink,
        Blue,
        Orange
    }
    public GhostType ghostType;
    public float[] positionGhostRed;
  
   
   public PlayerData(PacMan pacMan, Ghost ghostRed)
   {
      positionPacMan = new float[3];
      positionPacMan[0]=pacMan.transform.position.x;
      positionPacMan[1]=pacMan.transform.position.y;
      positionPacMan[2]=pacMan.transform.position.z;

      positionGhostRed = new float[3];
        
        if(ghostType == GhostType.Red)
        {
            positionGhostRed[0] = ghostRed.transform.position.x;
            positionGhostRed[1] = ghostRed.transform.position.y;
            positionGhostRed[2] = ghostRed.transform.position.z;
        }
      
   }
}
