using UnityEngine;

public class NarrationManager : MonoBehaviour
{
    [SerializeField] private AudioClip w1;
    [SerializeField] private AudioClip w2;
    [SerializeField] private AudioClip w4;
    [SerializeField] private AudioClip w5;
    [SerializeField] private AudioClip w6;
    [SerializeField] private AudioClip w7;
    [SerializeField] private AudioClip w8;
    [SerializeField] private AudioClip w9;
    [SerializeField] private AudioClip w10;
    [SerializeField] private AudioClip w11;
    [SerializeField] private AudioClip w12;
    [SerializeField] private AudioClip w13;
    [SerializeField] private AudioClip w14;
    [SerializeField] private AudioClip w15;
    [SerializeField] private AudioClip w16;
    [SerializeField] private AudioClip w19;

    [SerializeField] private AudioSource aud;
    public float narrationDist = 1.2f;
    private int lastWall = -1;

    public void StartNarration(int num) {
        if (!aud.isPlaying) {
            if (lastWall != num) {
                switch (num) {
                    case 1:
                        aud.clip = w1;
                        aud.Play();
                        break;
                    
                    case 2:
                        aud.clip = w2;
                        aud.Play();
                        break;

                    case 4:
                        aud.clip = w4;
                        aud.Play();
                        break;

                    case 5:
                        aud.clip = w5;
                        aud.Play();
                        break;

                    case 6:
                        aud.clip = w6;
                        aud.Play();
                        break;
                    
                    case 7:
                        aud.clip = w7;
                        aud.Play();
                        break;

                    case 8:
                        aud.clip = w8;
                        aud.Play();
                        break;

                    case 9:
                        aud.clip = w9;
                        aud.Play();
                        break;

                    case 10:
                        aud.clip = w10;
                        aud.Play();
                        break;
                    
                    case 11:
                        aud.clip = w11;
                        aud.Play();
                        break;

                    case 12:
                        aud.clip = w12;
                        aud.Play();
                        break;

                    case 13:
                        aud.clip = w13;
                        aud.Play();
                        break;

                    case 14:
                        aud.clip = w14;
                        aud.Play();
                        break;
                    
                    case 15:
                        aud.clip = w15;
                        aud.Play();
                        break;

                    case 16:
                        aud.clip = w16;
                        aud.Play();
                        break;

                    case 19:
                        aud.clip = w19;
                        aud.Play();
                        break;
                }

                lastWall = num;
            }
        }
    }
            
}
