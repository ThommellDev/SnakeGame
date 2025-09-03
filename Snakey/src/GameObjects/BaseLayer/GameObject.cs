using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Snakey.Components;
using Snakey.Components.Custom;
using Component = Snakey.Components.Component;
using IUpdateable = Snakey.Components.IUpdateable;

namespace Snakey.GameObjects;

public class GameObject {
    private List<Component> components = new();
    List<IRenderable> renderables = new();
    List<IUpdateable> updateables = new();
    private ICollider collider;
    private Transform transform;
    private bool hasInitialized;
    private List<GameObject> inactivePool = new();
    public Transform Transform => transform;
    public List<Component> Components => components;
    public ICollider Collider => collider;

    public GameObject(Transform pTransform, params Component[] pComponents) {
        transform = pTransform;
        components.Add(transform);
        components.AddRange(pComponents);
        foreach (Component component in components) {
            AddTypeOfComponent(component);
            SetOwner(this, component);
        }
    }
    public void Initialize() {
        if (CheckInitialization())
            return;
        
        foreach (Component component in components) {
            component.Initialize();
        }
        
        hasInitialized = true;
    }
    public void Load() {
        foreach (Component component in components) {
            component.Load();
        }
    }
    public void Update(GameTime pGameTime) {
        foreach (IUpdateable updateable in updateables) {
            updateable.Update(pGameTime);
        }
        
        if (inactivePool.Count <= 0) return; 
        
        // AFTER Update call, set object inactive.
        foreach (GameObject obj in inactivePool) {
            obj.Transform.Toggle(false);
        }
        inactivePool.Clear();
    }
    public void Render(SpriteBatch pSpriteBatch) {
        foreach (IRenderable renderable in renderables) {
            renderable.Render(pSpriteBatch);
        }
    }
    private void AddTypeOfComponent(Component pComponent) {
        if (pComponent is IUpdateable updateable)
            updateables.Add(updateable);
        if (pComponent is IRenderable renderable)
            renderables.Add(renderable);
        if (pComponent is ICollider collidable)
            collider = collidable;
    }
    public T GetComponent<T>() where T : Component {
        foreach (Component component in components) {
            if (component is T val)
                return val;
        }
        return null;
    }
    private void SetOwner(GameObject pGameObject, Component pComponent) {
        pComponent.SetOwner(pGameObject);
    }
    public bool CheckInitialization() {
        return hasInitialized;
    }
    public void AddObjectToInactivePool(GameObject pObject = null) {
        if (pObject == null) {
            inactivePool.Add(this);
            return;
        }
        inactivePool.Add(pObject);
    }
}