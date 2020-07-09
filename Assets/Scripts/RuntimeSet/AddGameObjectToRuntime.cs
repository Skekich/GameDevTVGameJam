using UnityEngine;

public class AddGameObjectToRuntime : MonoBehaviour
{
    public GameObjectRuntimeSet gameObjectRuntimeSet;

    private void OnEnable()
    {
        gameObjectRuntimeSet.AddToList(this.gameObject);
    }

    private void OnDisable()
    {
        gameObjectRuntimeSet.RemoveFromList(this.gameObject);
    }
}
