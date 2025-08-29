using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Snakey.GameObjects;

public class GameObject {
    private bool isActive = true;
    private Vector2 position;
    private Vector2 origin;
    private Vector2 size;
    private Texture2D texture;

    public bool IsActive => isActive;
    public Vector2 Position => position;
    public Vector2 Size => size;
    public Vector2 Origin => origin;

    public GameObject() {
        
    }
    public void RenderObject(SpriteBatch pSpriteBatch) {
    }
    public void UpdateObject(GameTime pGameTime) {
    }
}