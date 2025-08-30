using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Snakey.Components.Custom;

namespace Snakey.Components.Default;

/// <summary>
/// AABB Collision detection.
/// </summary>
public sealed class BoxCollider2D : Component, IRenderable {
    private SpriteRenderer spriteRenderer;
    private Rectangle bounds;
    public Rectangle Bounds => bounds;
    public override void Initialize() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        base.Initialize();
    }
    public override void Load() {
        OverlapBounds();
        base.Load();
    }
    public void OverlapBounds() {
        bounds = new Rectangle((int)Owner.Transform.Position.X - (int)Owner.Transform.Origin.X, (int)Owner.Transform.Position.Y - (int)Owner.Transform.Origin.Y, spriteRenderer.Texture.Width, spriteRenderer.Texture.Height);
        Console.WriteLine("Created bounds!");
    }
    public void Render(SpriteBatch pSpriteBatch) {
        pSpriteBatch.Draw(spriteRenderer.Texture, bounds, Color.Red);
    }
}