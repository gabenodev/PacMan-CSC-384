using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static public class ServiceLocator 
{
   static IGameManager gameManager;
   static NullGameManager nullGameManager;

   public static void Init()
   {
       gameManager = nullGameManager;
   }

  public static void Provide (IGameManager nullGameManager)
   {

       gameManager = nullGameManager;

   }

  public static IGameManager GetGameManager()
   {
       return gameManager;
   }

}
