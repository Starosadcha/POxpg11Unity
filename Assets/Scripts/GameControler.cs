using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameControler : MonoBehaviour
{
    public string Word ="after";
    public int LivesCount = 10;
    public TextMeshProUGUI MainWord;
    public TextMeshProUGUI OurInput;
    public TextMeshProUGUI SuggestionText;
    public TMP_InputField InputField;

    // Start is called before the first frame update
    void Start()
    {
        MainWord.text = Word;
        OurInput.text = $"Zostalo prob: {LivesCount}.";
    }

    public void OnInputChanged(string input)
    {
        //OurInput.text = input;
    }
    
    public void OnClick()
    {
        Debug.Log($"Przycisk zostal kliknety.");
        LivesCount = LivesCount - 1;
        OurInput.text = $"Zostalo prob: {LivesCount}.";
        if(Word == InputField.text)
        {
            Debug.Log($"Correct guess");
            //TODO change text on canvas;
            return;
        }
        if (Word.Length != InputField.text.Length)
        {
            SuggestionText.text = $"Dlugosc nie zgadza.";
            return;
        }

        int bullsCount = CountBulls();
        int cowsCount = CountCows();

        SuggestionText.text = $"Bulls : {bullsCount} and Cows: {cowsCount}";
    }

    public int CountCows()

    {
        int result = 0;
        for (int i = 0; i < Word.Length; i++)
        {
            // || => or conajmniej ledna ze stron jest true => true, else false
            //&& (and)
            if (Word[i] == InputField.text[i] && Word.Contains(InputField.text[i]))
            {
                result++;
            }
               
        }

        return result;
    }
    public int CountBulls()
    {
        int result = 0;

        for (int i = 0; i < Word.Length; i++)
        {
            if(Word[i] == InputField.text[i])
            {
                result++;
            }

        }



        return result;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
