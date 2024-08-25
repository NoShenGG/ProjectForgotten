using UnityEngine;

public class TextInputHandler : MonoBehaviour
{
    public void HandleSatze(string input) {
        Satze satze = new Satze(input);
        satze.ParseSatzeString();
    }
}
