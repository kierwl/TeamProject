using UnityEngine;

[CreateAssetMenu(fileName = "TMI_Details", menuName = "TMI_Details", order = int.MaxValue)]
public class TMI_Details : ScriptableObject 
{
    [SerializeField]
    private string owner;
    public string Owner { get { return owner; } }
    [SerializeField]
    private string detail;
    public string Detail { get { return detail; } }
    [SerializeField]
    private Sprite image;
    public Sprite Image { get { return image; } }
}

