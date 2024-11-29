using UnityEngine;

public class CursorManagerScript : MonoBehaviour
{
    public Texture2D customCursor; 
    public Vector2 hotSpot = Vector2.zero;
    public float scale = 5.0f;

    void Start()
    {
        Cursor.SetCursor(customCursor, hotSpot, CursorMode.Auto);
    }
}