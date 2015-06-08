using UnityEngine;
using System.Collections;

public class ChangeTailArt : MonoBehaviour {

    public Sprite tailSprite;
    public Sprite bodySprite;
    private SpriteRenderer spriterenderer;

    void Awake() {
        spriterenderer = GetComponent<SpriteRenderer>();
    }

    public void ChangeArt(bool tail, float speed) {
        if (tail == true) {
            spriterenderer.sprite = tailSprite;
            Invoke("ChangeBack", speed);
        }
        else {
            spriterenderer.sprite = bodySprite;
        }
    }
    void ChangeBack() {
        ChangeArt(false, 0);
    }
}
