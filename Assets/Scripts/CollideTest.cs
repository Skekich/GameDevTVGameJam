using UnityEngine;

public class CollideTest : MonoBehaviour
{
   private void Start()
   {
      print("It's working!");
   }

   private void OnCollisionEnter2D(Collision2D other)
   {
      print("this is test");
      print(other.gameObject.tag);
   }
}
