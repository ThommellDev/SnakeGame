using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Snakey.Components;
using Snakey.Components.Default;
using Snakey.GameObjects;
using IUpdateable = Snakey.Components.IUpdateable;

namespace Snakey;

public class CollisionManager : Component, IUpdateable {
    private CollisionManager instance;
    private BaseScene activeScene;
    private Dictionary<GameObject, BoxCollider2D> boxColliderMap = new();
    public CollisionManager Instance => instance;
   
    private void GetAllActiveColliders() {
        activeScene = SceneHandler.Instance.ActiveScene;
        boxColliderMap = GetActiveColliders();
    }
    private Dictionary<GameObject, BoxCollider2D> GetActiveColliders() {
        Dictionary<GameObject, BoxCollider2D> colliders = new();
        List<GameObject> activeObjects = activeScene.ObjectsInScene.FindAll(x => x.Transform.IsActive);
        
        foreach (GameObject obj in activeObjects) {
            if (obj.GetComponent<BoxCollider2D>() is { } collider) {
                colliders.Add(collider.Owner, collider);
            }
        }
        return colliders;
    }

    // TEMPORARY: Should be improved in the future!
    private void CollisionCheck() {
        GetAllActiveColliders();
        bool hasCollidedInFrame = false;

        var colliderArray = boxColliderMap.Values.ToArray();
        
        for (int pointerOne = 0; pointerOne < colliderArray.Length; pointerOne++) {
            for (int pointerTwo = pointerOne + 1; pointerTwo < colliderArray.Length; pointerTwo++) {
                
                BoxCollider2D colliderOne = colliderArray[pointerOne];
                BoxCollider2D colliderTwo = colliderArray[pointerTwo];
                
                if (DoCollidersIntersect(colliderOne, colliderTwo)){
                    CallCollision(colliderOne.Owner.Collider, colliderTwo.Owner);
                    CallCollision(colliderTwo.Owner.Collider, colliderOne.Owner);
                    hasCollidedInFrame = true;
                }
            }
            // Fast exit loop
            if (hasCollidedInFrame) break;
        }
    }
  
    /// <summary>
    /// The collision call.
    /// </summary>
    /// <param name="pCollider"><see cref="ICollider"/>'s implementation.</param>
    /// <param name="pOtherObject">The collided <see cref="GameObject"/>.</param>
    private void CallCollision(ICollider pCollider, GameObject pOtherObject) {
        pCollider.Collide(pOtherObject);
    }
    private static bool DoCollidersIntersect(BoxCollider2D collider1, BoxCollider2D collider2) {
        return collider1.Bounds.Intersects(collider2.Bounds);
    }

    public void Update(GameTime pGameTime) {
        CollisionCheck();
    }

   
}