using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.Rendering;

public class EffectManager : MonoBehaviour
{
    public static EffectManager Instance { get; private set; }
    public List<GameObject> effects = new List<GameObject>();

    private void Awake()
    {
        EffectManager.Instance = this;
        this.LoadEffects();
    }

    protected virtual void LoadEffects()
    {
        foreach(Transform child in transform)
        {
            this.effects.Add(child.gameObject);
            child.gameObject.SetActive(false);
        }
    }

    public virtual void SpawnVFX(string effectName, Vector3 position, Quaternion rotation)
    {
        GameObject effects = this.Get(effectName);
        GameObject newEffect = Instantiate(effects, position, rotation);
        newEffect.gameObject.SetActive(true);
    }

    protected virtual GameObject Get(string effectName)
    {
        foreach (GameObject child in this.effects)
        {
            if (child.name == effectName)
            {
                return child;
            }
        }
        Debug.LogWarning($"Effect {effectName} not found.");
        return null;
    }
}
