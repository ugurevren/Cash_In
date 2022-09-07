using TMPro;
using UnityEngine;
public class doorScript : MonoBehaviour
{
    private enum DoorType {adder, substracter, multiplier, divider, chance};
    [SerializeField] DoorType Type;
    [SerializeField] int doorValue;
    [Space(2)] 
    [SerializeField] TextMeshProUGUI valueText;

    void Start()
    {
        valueText.text = Type == DoorType.adder ? '+' +doorValue.ToString():
            Type == DoorType.substracter? '-' + doorValue.ToString():
            Type == DoorType.multiplier ? 'x' +doorValue.ToString():
            Type == DoorType.divider ? '÷' +doorValue.ToString(): "Chance";
    }

    public void UpdateCash(AudioHandler audioHandler)
    {
        switch (Type)
        {
            case DoorType.adder:
                audioHandler.greenDoor.Play();
                Collectibles.cash += doorValue;
                Debug.Log(Collectibles.cash);
                break;
            case DoorType.substracter:
                audioHandler.redDoor.Play();
                Collectibles.cash -= doorValue;
                Debug.Log(Collectibles.cash);
                break;
            case DoorType.multiplier:
                audioHandler.greenDoor.Play();
                Collectibles.cash *= doorValue;
                Debug.Log(Collectibles.cash);
                break;
            case DoorType.divider:
                audioHandler.redDoor.Play();
                Collectibles.cash /= doorValue;
                Debug.Log(Collectibles.cash);
                break;
            case DoorType.chance:
                audioHandler.purpDoor.Play();
                float dice = Random.Range(0, 100f);
                Collectibles.cash += (playerStats.chance + dice) >= 50f ? doorValue : -doorValue;
                Debug.Log(Collectibles.cash);
                break;
        }
    }
}
