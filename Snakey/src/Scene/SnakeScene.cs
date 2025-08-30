using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Snakey.GameObjects;

namespace Snakey;

public class SnakeScene : BaseScene {
    public void Initialize() {
        
    }

    public void Load() {
        GameObject textureTest = new GameObject("");
    }
    
    /// <summary>
    /// Updates every GameObject in the scene.
    /// </summary>
    public void Update(GameTime pGameTime) {
    }

    /// <summary>
    /// Renders every GameObject in the scene.
    /// </summary>
    public void Render(SpriteBatch pSpriteBatch) {
    }

    /// <summary>
    /// Tries adding a new object in the Scene's GameObject list.
    /// </summary>
    /// <param name="pGameObject">The new object.</param>
    public void TryAddObject(GameObject pGameObject) {
        if (objectsInScene.Any(x => ReferenceEquals(x, pGameObject))) return;
        objectsInScene.Add(pGameObject);
    }
}