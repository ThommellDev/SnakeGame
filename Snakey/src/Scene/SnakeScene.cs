using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Snakey.GameObjects;

namespace Snakey;

public class SnakeScene {
    private List<GameObject> objectsInScene = new();
    public void Initialize() {
    }

    public void Load() {
        TextureHandler.Instance.AddTexture();
        GameObject textureTest = new GameObject();
    }
    
    /// <summary>
    /// 
    /// Updates every GameObject in the scene.
    /// </summary>
    public void Update(GameTime pGameTime) {
        foreach (GameObject obj in objectsInScene) {
            // Skip updating object if it's inactive.
            if (obj.IsActive) continue;
            obj.UpdateObject(pGameTime);
        }
    }

    /// <summary>
    /// Renders every GameObject in the scene.
    /// </summary>
    public void Render(SpriteBatch pSpriteBatch) {
        foreach (GameObject obj in objectsInScene) {
            // Skip rendering object if it's inactive.
            if (obj.IsActive) continue;
            obj.RenderObject(pSpriteBatch);
        }
    }

    /// <summary>
    /// Tries adding a new object the the Scene's GameObject list.
    /// </summary>
    /// <param name="pGameObject"></param>
    public void AddObject(GameObject pGameObject) {
        if (CheckIfObjectAlreadyExists(pGameObject)) return;
        objectsInScene.Add(pGameObject);
        
        return;
        
        // Quick look-up if the object already exists with the same memory address, if so it will cancel adding the object.
        bool CheckIfObjectAlreadyExists(GameObject pObject) {
            for (int i = 0; i < objectsInScene.Count; i++) {
                if (ReferenceEquals(pObject, objectsInScene[i])) return true;
            }
            return false;
        }
    }
}