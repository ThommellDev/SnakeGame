using Microsoft.Xna.Framework;

namespace Snakey.Components.Custom;

public class Transform : Component {
    private bool isActive;
    private Vector2 position;
    private Vector2 origin;
    private float rotation;
    private Vector2 scale;
    
    public bool IsActive => isActive;
    public Vector2 Position => position;
    public Vector2 Scale => scale;
    public Vector2 Origin => origin;

    public float Rotation => rotation;

    public Transform(bool pIsActive = true, Vector2 pPosition = default, Vector2 pScale = default, Vector2 pOrigin = default, float pRotation = 0) {
        isActive = pIsActive;
        position = pPosition;
        scale = pScale;
        origin = pOrigin;
        rotation = pRotation;
        CheckValues();
    }

    private void CheckValues() {
        if (origin == default) 
            origin = new Vector2(0.5f, 0.5f);
        if (scale == default) 
            scale = Vector2.One;
    }
    public void SetOrigin(Vector2 pOrigin) {
        origin = pOrigin;
    }

    public void Translate(Vector2 pAddedPosition) {
        position += pAddedPosition;
    }
}
