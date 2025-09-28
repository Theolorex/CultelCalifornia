using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class allDialogue : MonoBehaviour
{
    public string[] allDial =
    {
        "AAAAAAAAAAAAAAAAAAAH", //all 3 talking at once, index 0
        "AAAAAAAH-", //wizard
        "Wait… it appears I might not be as dead as I thought.", //wizard
        "WHO THE HECK SAID THAT!? WHAT IS GOING ON?!", //tank
        "Yeah… I don’t remember inviting you people to my brain… How did I- or we get here?", //bard
        "Well it doesn’t seem this is the work of your regular necromancer.", //wiz
        "It appears we’ve been gathered together as one collective consciousness.", //wiz
        "SO THEY PUT YOU GUYS IN MY HEAD??!?!", //tank
        "Potentially… but this body doesn’t seem quite as… brutish as yours.", //wiz
        "Well surely we’re all in my head.", //bard
        "There’s no WAY they’d lump us into one of your guys’ bodies.", //bard, index 10
        
        "...no offence though?", //bard
        "We are definitely not in that husk of a physique, no", //wiz
        "I think we’re in a brand new body", //wiz
        "WHY AM I STANDING!?!?", //tank
        "I didn’t try to do that either… strange.", //bard
        "Well that solves it. We’re not in our own bodies.", //wiz
        "It appears that this thing has free will.", //wiz 
        "Welp, I for one want to get out of it leave this dreadful room", //wiz
        "Erm… wait. So we’re all in the same brain?", //tank, 
        "Wow, with that head of yours it's no wonder you got stuck here.", //wiz, index 20
        
        "You trying to start something little guy??", //tank
        "please don't... i might cry", //tank
        "Guys, there’s no use in fighting now. Not like you can brawl each other anyways.", //bard
        "Hey buddy, the one that stood up. Wanna try and get a move on?", //bard
        "Ah geez… oh man… which key was it…", //f-cultist
        "Geez, get a look at that guy. With that many keys he’ll never get out of here", //bard
        "He's clearly a shmuck of the ranks. I bet all we need to get to him is a severe reprimanding", //wiz
        "NO WAY, that guy KILLED me!?!", //tank
        "uh…", //tank
        "knock him out?", //tank, index 30
        
        "Man for being such a brute you are one wet blanket...", //bard
        "Regardless, let's beat him up and get out of here.", //bard
    "Oh man… I guess we gotta fight him…", //tank
    "Its either him or us, lets get him!", //bard
    "AHHHH! Y-Y-You’re the familiar-demon thing we summoned, r-r-right??", //f-cultist
    "DON’T HURT ME!!! IT'S THE MONSTER YOU’RE AFTER, I SWEAR!", //f-cultist
    "HOOOLD ON YOU BRUTES! Let’s just slow it down and converse with the man.", //wiz
    "Listen you thing, do NOT fight that guy. Certainly not yet that is.", //wiz
    "We still have the upper hand though, let’s find out what he knows.", //bard
    "Brute man, teach it how to intimidate them.", //bard, index 40

    "Good, it has some sense to it.", //wiz
    "Ask him about the goal of this cult, and why we were combined this way", //wiz
    "A-ah! You were just confused! For a moment I was scared for my life!", //f-cultist
    "The Boss is awaiting your arrival further down the dungeon.", //f-cultist
    "...And why does he need us?", //wiz
    "...Right, nobody has introduced you yet!", //f-cultist
    "Well, we have combined 3 skilled minds here in need of your skills.", //f-cultist
    "In the depths of this dungeon, there is a Beast that needs to be killed.", //f-cultist
    "That’s where you come in!", //f-cultist
    "...Fascinating…", //wiz, index 50

    "We can definitely take it! We’re all pretty skilled, right?", //bard
    "I could try to beat him up… BUT I can’t control the muscles!", //tank
    "Here, I think one of you guys had an item that’d really help.", //f-cultist
    "Not sure which room it was in though, go take a look around.", //f-cultist
    "I’ll be here to let you through whenever you’re done. :)", //f-cultist
    "There, you found the item.", //f-cultist
    "Here, let me usher you toward the rest of the dungeon. The Boss should be pleased.", //f-cultist
    "Now where could this lead…", //wiz
    "F-f-fine! But we’re NOT hurting this guy.", //tank
    "Okay, lift him by the collar and yell at him. That usually works.", //tank, index 60

    "PLEASE PLEASE PLEASE DON’T HURT ME! I-I-I’ll tell you ANYTHING!", //f-cultist
    "L-l-look… J-just down that door and take a right down to the library!", //f-cultist
    "The boss is there waiting for you… I AM NOT THE BEAST HE NEEDS YOU TO KILL!", //f-cultist
    "Now this I can work with, drop him on the ground and find my cell.", //wiz
    "I’m certain that I left an item hidden in there", //wiz
    "GAH! H-h-h-here.", //f-cultist
    "This is the k-k-key! J-just unlock the door and you’ll be good!", //f-cultist
    "Shame, and here I was hoping to learn something.", //wiz
    "I’M SORRY, I’M SORRY, I’M SORRY!", //tank
    "Wimp.", //bard, index 70

    "Well, there’s no use hanging around here now.", //wiz
    "I suggest we make our way out of here now, before more of them show up.", //wiz
    "Hopefully there’s somewhere civilized out there…", //bard
    "This whole puppetry act is harder than I thought…", //bard
    "It's probably because I held back! I’m sorry guys...", //tank
    "What good were those muscles of yours if you couldn’t harm a toad?!", //wiz
    "No matter, this body seems too beat up to do anything now…", //wiz
    "N-n-no way! That was waaaaaaay easier than I thought!", //f-cultist
    "We really summoned this thing to fight for us? HAH", //f-cultist
    "There’s no way you’re getting out of there now!", //f-cultist, index 80

    "Man, thought I’d never see this night sky again!", //bard
    "And the air smells so clean! It's so good to be back!", //bard
    "Well don't get too settled in, we still haven’t a clue where we are.", //wiz
    "Look over there! I can see a fire through the trees.", //tank
    "Welp, where there’s light, there’s people. Let's go!", //bard
    "Oh thank the Heavens! A Tavern!", //tank
    "Couldn’t agree more, you thinkin’ what I’m thinkin’?", //bard
    "Oh Lord… Couldn’t we look for something less indulgent…?", //wiz
    "I need a drink!", //bard and tank
    "Awwwwww, whaaat?!?!!", //bard and tank, index 90

    "You’re really gonna listen to that NERD’s suggestion??", //bard
    "Glad somebody here has their head on straight!", //wiz
    "...however we can't really go anywhere in particular.", //wiz
    "Surely that’s a proper village now!", //wiz
    "No, surely it can’t be…", //wiz
    "OHHHHHH YEAH!", //bard and tank
    "Well what are we waiting for! Let’s get hammered!!!", //tank
    "Well this is definitely one seedy looking establishment…", //wiz
    "You definitely look worse for wear, long night?", //barkeep
    "Yeah yeah, cut to the chase and ‘beer me’ already", //bard, index 100

    "Here, it looks like you could use this.", //barkeep
    "A glass of this liquid courage will fix you right up, I’m sure.", //barkeep
    "Are you two dolts that idiotic?", //wiz
    "Take a closer look at this guy and THINK about his intent.", //wiz
    "C’mon buddy, I just poured you a perfect glass of beer.", //barkeep
    "The least you could do is give it a try?", //barkeep
    "YESSSSSSSSS", //bard and tank
    "Don’t you dare…", //wiz
    "Now we’re TALKIN’, alright!", //bard
    "Now that’s the stuff. Hey bub… I like your style…", //tank, index 110

    "You better keep these drinks flowin’!", //tank
    "YEAAAAAH, that’s what I like to hear!", //bard
    "Isn’t that the most refreshing beer you’ve ever had?", //barkeep
    "Now go on, make yourself at home. I’ll bring you another soon.", //barkeep
    "Woah woah woah, what’s with the hostility friend?", //barkeep
    "Well… maybe this thing does have its wits about it.", //wiz
    "Tell you what, you can have this… one on-the-house.", //barkeep
    "FREE BEER!!!", //bard and tank
    "Only an IDIOT says no to FREE!", //tank
    "...Intimidate it some more.", //wiz, index 120

    "Look, you. I’m not appreciating this hostility.", //barkeep
    "You come into my tavern, sit at my bar, get offered a FREE beer. What audacity…", //barkeep
    "You see, we don’t take kindly to people that disrespect us like you have.", //barkeep
    "Can’t have anything nice today, huh…", //bard
    "Alright, let's get this over with.", //bard
    "Big guy, if you have that beer, will you loosen up?", //bard
    "You don't wanna know what I've done after one beer", //tank
    "Then chug the thing so we can get on with this!", //bard
    "WOOOOOOO, GET DESTROYED!!! OH YEAH!!!", //tank
    "Wow, who woulda thought one drink was enough to get you going.", //tank, index 130

    "It’s only logical, he lost what little brain activity he had and went primal.", //wiz
    "YOU’RE DARN RIGHT I’M IN MY PRIME!!! WOOOOO!!!", //tank
    "...you sure are bud. You sure are…", //bard
    "HEY WIZARD, GET A LOAD OF THIS MAGIC.", //tank
    "FOR MY NEXT TRICK, BURN THIS HELLHOLE DOWN!!!", //tank
    "That’s a tad bit extreme, don’t you think?!", //wiz
    "They killed our regular selves and made us stuck like this...", //bard
    "...", //wiz
    "Set this place aflame, we haven’t got all night.", //wiz
    "You guys ready?", //tank, index 140

    "Hit it.", //bard and wiz
    "Finally, let's get this party started.", //tank
    "You’re telling me pal, who should we chat up first?", //bard
    "Hmmm… well that guy seems… interesting.", //tank
    "Oooh another cultist, let’s go find out what he knows.", //bard
    "Shoot, let's hope he doesn’t recognize us.", //bard
    "Man… buurp I can’t hic -believe I showed my face here again…", //d-cultist
    "I’ll show the boss hic that I’m… WORTH being a cultist…", //d-cultist
    "He’s not recognizing squat.", //bard
    "Welp, what are you waiting for! What’s his deal?", //tank, index 150

    "Hey you, care for a glass? hic I should probably cut myself off soon… soon…", //d-cultist
    "Why am I drinking you ask? burp I’LL TELL YOU WHY!", //d-cultist
    "I brought the boss a PERFECTLY GOOD SACRIFICE!", //d-cultist
    "And he threw me out! hic Like what!?", //d-cultist
    "I mean… he was pretty mundane… didn’t put up a fight at all.", //d-cultist
    "BUT HE WAS COOL! He bought me this bottle… He had a cool smile…", //d-cultist
    "I'm know I'll show the boss I'm worthy..." //d-cultist, index 157
    };

    
}
