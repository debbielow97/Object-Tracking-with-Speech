using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class SpeechRecognizer : MonoBehaviour
{

    KeywordRecognizer KeywordRecognizerObj;
    public string[] Keywords_array;

    private Animator anim;
    public AudioSource[] AnimeSound;

    // Start is called before the first frame update
    void Start()
    {
        KeywordRecognizerObj = new KeywordRecognizer(Keywords_array);
        KeywordRecognizerObj.OnPhraseRecognized += OnKeywordsRecognized;
        KeywordRecognizerObj.Start();

        anim = GetComponent<Animator>();
        AnimeSound = GetComponent<AudioSource[]>();
     
    }

    void OnKeywordsRecognized(PhraseRecognizedEventArgs args)
    {
        Debug.Log("keyword : " + args.text + "; Confidence " + args.confidence);
        ActionPerformer(args.text);
    }

    void ActionPerformer(string command)
    {
        if (command.Contains("attack"))
        {
            anim.Play("Attack", -1, 0.5f);
            AnimeSound[0].Play(0);
        }
        if (command.Contains("jump"))
        {
            anim.Play("Jump", -1, 0.5f);
            AnimeSound[1].Play(0);
        }
        if (command.Contains("run"))
        {
            anim.Play("Run", -1, 0.5f);
            AnimeSound[2].Play(0);
        }
        if (command.Contains("die"))
        {
            anim.Play("Die", -1, 0.5f);
            AnimeSound[3].Play(0);
        }
    }

}
