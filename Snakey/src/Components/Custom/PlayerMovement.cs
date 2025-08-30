using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Snakey.Components.Custom;

public class PlayerMovement : Component, IUpdateable{
    private Transform transform;
    private float speed;

    public PlayerMovement(float pSpeed = 10f) {
        speed = pSpeed;
    }

    public override void Initialize() {
        transform = GetComponent<Transform>();
        base.Initialize();
    }

    public void Update(GameTime pGameTime) {
        transform.Translate(GetDirection() * speed * (float)pGameTime.ElapsedGameTime.TotalSeconds);
    }

    private Vector2 GetDirection() {
        KeyboardState state = Keyboard.GetState();
        Vector2 velocity = Vector2.Zero;
        if (state.IsKeyDown(Keys.W))
            velocity.Y -= 1;
        if (state.IsKeyDown(Keys.S))
            velocity.Y += 1;
        if (state.IsKeyDown(Keys.A))
            velocity.X -= 1;
        if (state.IsKeyDown(Keys.D))
            velocity.X += 1;

        if (velocity == Vector2.Zero) return Vector2.Zero;
        velocity.Normalize();
        return velocity;
    }
}