using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Snakey.GameObjects;

namespace Snakey;

public class BaseScene {
    private List<GameObject> objectsInScene = new();

    /// <summary>
    /// Override this method and create your objects in here using TryAddObject.
    /// </summary>
    public virtual void CreateObjects() {
    }
    public virtual void Initialize() {
        foreach (GameObject obj in objectsInScene) {
            obj.Initialize();
        }
    }
    public virtual void Load() {
        foreach (GameObject obj in objectsInScene){
            if (!obj.Transform.IsActive) continue;
            obj.Load();
        }
    }
    public virtual void Update(GameTime pGameTime) {
        foreach (GameObject obj in objectsInScene) {
            if (!obj.Transform.IsActive) continue;
            obj.Update(pGameTime);
        }
    }

    public virtual void Render(SpriteBatch pSpriteBatch) {
        foreach (GameObject obj in objectsInScene) {
            if (!obj.Transform.IsActive) continue;
            obj.Render(pSpriteBatch);
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