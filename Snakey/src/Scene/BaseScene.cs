using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Snakey.GameObjects;

namespace Snakey;

public class BaseScene {
    private List<GameObject> objectsInScene = new();
    public virtual void Initialize() {}
    public virtual void Load() {}

    public virtual void Update(GameTime pGameTime) {
        foreach (GameObject obj in objectsInScene) {
            if (!obj.IsActive) continue;
            obj.UpdateObject(pGameTime);
        }
    }

    public virtual void Render(SpriteBatch pSpriteBatch) {
        foreach (GameObject obj in objectsInScene) {
            if (!obj.IsActive) continue;
            obj.RenderObject(pSpriteBatch);
        }
    }
}