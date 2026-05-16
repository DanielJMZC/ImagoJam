using UnityEngine;

[CreateAssetMenu(fileName = "New Speaker", menuName = "Dialogue System/Speaker")]
public class Speaker : ScriptableObject
{
    [Header("Character Identity")]
    public string characterName;
    public string characterID; 

    [Header("Visual Representation")]
    public Sprite defaultPortrait;
    public Sprite happyPortrait;
    public Sprite sadPortrait;
    public Sprite angryPortrait;
    public Sprite surprisedPortrait;

    [Header("Audio Configuration")]
    public AudioClip greetingSound;
    public AudioClip farewellSound;

    [Header("UI Styling")]
    public Color nameColor = Color.white;
    public Font customFont;

    public Sprite GetPortraitForEmotion(string emotion)
    {
        switch (emotion.ToLower())
        {
            case "happy": return happyPortrait ?? defaultPortrait;
            case "sad": return sadPortrait ?? defaultPortrait;
            case "angry": return angryPortrait ?? defaultPortrait;
            case "surprised": return surprisedPortrait ?? defaultPortrait;
            default: return defaultPortrait;
        }
    }
}