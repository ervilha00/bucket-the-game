using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BadLuckTextHandler : MonoBehaviour
{
    private TextMeshProUGUI textComponent;
    private string[] badLuckQuotes =
    {
        "\"Aren't I lucky, to have survived so much bad luck.\" ~ Ashleigh Brilliant",
        "\"Bad luck either destroys you or it makes you the man you really are.\" ~ Miguel Torres",
        "\"My bad luck got tangled up with my bad decisions, and I'm paying for it.\" ~ Patrick Rothfuss",
        "\"Destiny is a good thing to accept when it's going your way. When it isn't, don't call it destiny; call it injustice, treachery, or simple bad luck.\" ~ Joseph Heller",
        "\"You never know what worse luck your bad luck has saved you from.\" ~ Cormac McCarthy",
        "\"You can't avoid mistakes and bad luck.\" ~ Mikhail Tal",
        "\"You never can tell whether bad luck may not after all turn out to be good luck.\" ~ Winston Churchill",
        "\"I don't believe in superstition, I think it's bad luck.\" ~ Dan Henderson",
        "\"Your karma should be good, and everything else will follow. Your good karma will always win over your bad luck.\" ~ Rohit Shetty",
        "\"A man forgets his good luck next day, but remembers his bad luck until next year.\" ~ E. W. Howe",
        "\"When you think things are bad, when you feel sour and blue, when you start to get mad... you should do what I do! Just tell yourself, Duckie, you're really quite lucky! Some people are much more... oh, ever so much more... oh, muchly much-much more unlucky than you!\" ~ Dr. Seuss",
        "\"If not for bad luck we'd have no luck at all.\" ~ Edna Buchanan",
        "\"Most bad luck is the misfortune of not being an exception.\" ~ Mason Cooley",
        "\"Nobody gets justice. People only get good luck or bad luck.\" ~ Orson Welles",
        "\"Luck never made a man wise.\" ~ Seneca the Younger",
        "\"All of us have bad luck and good luck. The man who persists through the bad luck - who keeps right on going - is the man who is there when the good luck comes - and is ready to receive it.\" ~ Robert Collier",
        "\"Luck is what happens when preparation meets opportunity.\" ~ Seneca the Younger",
        "\"I've had bad luck with both my wives. The first one left me and the second one didn't.\" ~ Patrick Murray",
        "\"Winning a lottery may prove to be bad luck.\" ~ James Cook",
        "\"If a man who can’t count finds a four leaf clover, is he lucky?\" ~ Stanislaw Lem",
        "\"I sometimes think we consider too much the good luck of the early bird and not enough the bad luck of the early worm.\" ~ Franklin D. Roosevelt",
        "\"Luck is not chance, it's toil; fortune's expensive smile is earned.\" ~ Emily Dickinson",
        "\"To a brave man, good and bad luck are like his left and right hand. He uses both.\" ~ St. Catherine of Siena",
        "\"At gambling, the deadly sin is to mistake bad play for bad luck.\" ~ Ian Fleming",
        "\"Luck has a peculiar habit of favoring those who do not depend on it.\" ~ George S. Clason"
    };

    void Start()
    {
        textComponent = GetComponent<TextMeshProUGUI>();
        int choosenQuote = Random.Range(0, badLuckQuotes.Length);
        textComponent.text = badLuckQuotes[choosenQuote];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
