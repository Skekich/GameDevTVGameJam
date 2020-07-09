using System.Collections.Generic;
using UnityEngine;

public class InstantiateList
{
   private List<GameObject> objArray;

   public List<GameObject> CreateList(int capacity)
   {
      objArray = new List<GameObject>(capacity);
      return objArray;
   }
   
   public void AddToList(GameObject gameObj)
   {
      if(CheckIfFull()) return;
      objArray.Add(gameObj);
   }

   public void RemoveFromList()
   {
      if (objArray.Count < 1) return;
      objArray.RemoveAt(objArray.Count - 1);
   }

   public bool CheckIfFull()
   {
      if (objArray.Count < objArray.Capacity) return false;
      Debug.LogWarning("Array is full");
      return true;
   }

   public int FreePlaces()
   {
      return objArray.Capacity - objArray.Count;
   }
}
