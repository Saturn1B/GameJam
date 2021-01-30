using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class GameManager : MonoBehaviour
{
    public List<Material> materials;
    public List<Color> colors;
    public bool cyan, magenta, yellow;
    public int colorRestored;
    // Start is called before the first frame update
    void Awake()
    {
        for (int i = 0; i < materials.Count; i++)
        {
            colors.Add(materials[i].color);
            materials[i].color = new Color(1, 1, 1);
        }
        cyan = false;
        magenta = false;
        yellow = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RestoreColor(int c)
    {
        if (c == 0)
        {
            for (int i = 0; i < materials.Count; i++)
            {
                materials[i].color = new Color(colors[i].r, materials[i].color.g, materials[i].color.b);
            }
        }
        if (c == 1)
        {
            for (int i = 0; i < materials.Count; i++)
            {
                materials[i].color = new Color(materials[i].color.r, colors[i].g, materials[i].color.b);
            }
        }
        if (c == 2)
        {
            for (int i = 0; i < materials.Count; i++)
            {
                materials[i].color = new Color(materials[i].color.r, materials[i].color.g, colors[i].b);
            }
        }
    }

    public void RestoreBaseColor()
    {
        for (int i = 0; i < materials.Count; i++)
        {
            materials[i].color = colors[i];
        }
    }


    void OnEnable()
    {
#if UNITY_EDITOR
        EditorApplication.playmodeStateChanged += StateChange;
#endif
    }
#if UNITY_EDITOR
    void StateChange()
    {
        if (!EditorApplication.isPlayingOrWillChangePlaymode && EditorApplication.isPlaying)
        {
            RestoreBaseColor();
        }
 }
#endif
}
