using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData 
{
  /*  public float[] positionPacMan;
    GameObject pacMan = GameObject.Find("PacMan");
    GameObject ghostRed = GameObject.Find("Ghost_Blinky");

public enum GhostType {
        Red,
        Pink,
        Blue,
        Orange
    }
    public GhostType ghostType;
    public float[] positionGhostRed;
  */


    public float[] positionPacMan;
  // GameObject pacMan = GameObject.Find("PacMan");
   PacMan pacMan;
   public PlayerData(PacMan pacMan)
   {
       pacMan = this.pacMan;
       positionPacMan = new float[2];
       positionPacMan[0] = pacMan.transform.position.x;
       positionPacMan[1] = pacMan.transform.position.y;





       /*
       pacMan = this.pacMan;
       ghostRed = this.ghostRed;
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

     */ 
   }
}
