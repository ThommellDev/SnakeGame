using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Snakey.Components;
using Snakey.Components.Custom;
using IUpdateable = Snakey.Components.IUpdateable;

namespace Snakey.GameObjects;

public class GameObject {
    private List<Component> components = new();
    List<IRenderable> renderables = new();
    List<IUpdateable> updateables = new();
    private Transform transform;
    public Transform Transform => transform;
    protected GameObject(Transform pTransform, params Component[] pComponents) {
        transform = pTransform;
        components.Add(transform);
        components.AddRange(pComponents);
        foreach (Component component in components) {
            AddTypeOfComponent(component);
            SetOwner(this, component);
        }
    }
    public void Initialize() {
        foreach (Component component in components) {
            component.Initialize();
        }
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
}