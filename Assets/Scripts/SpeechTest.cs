using System.Collections;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using Microsoft.CognitiveServices.Speech;
using Microsoft.CognitiveServices.Speech.Intent;

public class SpeechTest : MonoBehaviour
{
    string userName;

    async void Start()
    {
        await SpeechService.Say("Hello!");
        await SpeechService.Say("I'm Tom");
        await SpeechService.Say("What's your name?");
        
        try
        {
            var result = await SpeechService.Interpret();
            userName = GetName(result);
        }
        catch
        {
            userName = "";
        }

        await SpeechService.Say("Nice to meet you " + userName);
        await SpeechService.Say("Thank you for giving your time today to take care of me.");

        // Check the heart.

        // Give medicine.

        await SpeechService.Say("I'm feeling a bit under the weather.");
        await SpeechService.Say("Can you pass me my medicine?");

        await SpeechService.Say("Thank you so much, dear.");
        await SpeechService.Say("You're such an angel.");
    }

    string GetName(InterpretResult result)
    {
        foreach (Entity entity in result.entities)
        {
            if (entity.type == "builtin.personName")
            {
                return entity.entity;
            }
        }
        return "";
    }
}
