using Snakey.GameObjects;

namespace Snakey.Components;

public class Component {
    private bool isActive = true;
    private GameObject owner;
    public virtual void Initialize() {}
    public virtual void Load() {}
    protected T GetComponent<T>() where T : Component {
        return owner.GetComponent<T>();
    }
    public void SetOwner(GameObject pGameObject) {
        owner = pGameObject;
    }
}