using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Snakey.Components.Custom;

public class SpriteRenderer : Component, IRenderable {
    private Transform transform;
    private TextureType textureType;
    private Texture2D texture;
    private Color color;
    private float layerDepth;
    private SpriteEffects effects;
    
    public Color Color => color;
    public float LayerDepth => layerDepth;
    public SpriteEffects Effects => effects;
    public Texture2D Texture => texture;
    public SpriteRenderer(TextureType pType, Color pColor = default, float pLayerDepth = 0, SpriteEffects pEffects = SpriteEffects.None) {
        textureType = pType;
        color = pColor;
        layerDepth = pLayerDepth;
        effects = pEffects;
    }
    public override void Initialize() {
        transform = GetComponent<Transform>();
        CheckValues();
        base.Initialize();
    }
    private void CheckValues() {
        // IMPORTANT: Set this as highest hierarchy in code, Transform's SetOrigin depends on this.
        texture = TextureHandler.Instance.GetTexture(textureType); 
        if (color == default)
            color = Color.White;
        Vector2 temp = GetOriginValue();
        transform.SetOrigin(temp);
    }
    private Vector2 GetOriginValue() {
        return new Vector2(texture.Bounds.Width * transform.Origin.X, texture.Bounds.Height * transform.Origin.Y);
    }
    #region Setters

    public void SetTexture(TextureType pNewTexture) {
        texture = TextureHandler.Instance.GetTexture(pNewTexture);
    }
    #endregion
    public void Render(SpriteBatch pSpriteBatch) {
        pSpriteBatch.Draw(texture, transform.Position, null, color, transform.Rotation, transform.Origin, transform.Scale, SpriteEffects.None, 0f);
    }
}