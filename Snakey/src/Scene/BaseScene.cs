using System.Collections.Generic;
using System.Linq;
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
    /// <summary>
    /// Tries adding the parameter's GameObject.
    /// </summary>
    /// <param name="pGameObject">The new GameObject.</param>
    public void TryAddObject(GameObject pGameObject) {
        if (objectsInScene.Any(x => ReferenceEquals(x, pGameObject))) return;
        objectsInScene.Add(pGameObject);
    }
}