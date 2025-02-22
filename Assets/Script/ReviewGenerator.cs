using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ReviewGenerator
{
    public struct Review {
        public String text;
        public int stars;
    };
    public static Review[] reviewList = new Review[] {
        new Review { text = "bread, tomato, steak and salad, nothing original", stars = 1 },
        new Review { text = "FINALLY a burger place that takes some risk !! The bicyle tire was delicious", stars = 5 },
        new Review { text = "Excellent ! The meat was delicious, I wonder what it was !", stars = 5 },
        new Review { text = "I love this bakery they make excellent bread!!!", stars = 5 },
        new Review { text = "A bold choice to serve a burger without the bun… or the patty… just a plate.", stars = 2 },
        new Review { text = "The secret sauce is actually a secret. Even the chef doesn't know what's in it.", stars = 1 },
        new Review { text = "I asked for medium rare, but I think they served me 'still mooing'.", stars = 3 },
        new Review { text = "Where is the bath duck topping ???", stars = 1 },
        new Review { text = "I came for a burger and left with enlightenment. 10/10 experience.", stars = 5 },
        new Review { text = "The chef clearly trained in France…", stars = 4 },
        new Review { text = "I ordered a vegan burger. The duck was actually vegan. Authentic.", stars = 5 },
        new Review { text = "Finally, a restaurant that understands the importance of a good pickle-to-bun ratio!", stars = 5 },
        new Review { text = "They replaced my burger bun with a bicycle tire. My arteries are suing, but my taste buds are thrilled.", stars = 4 },
        new Review { text = "The service was so fast, I suspect they saw me coming and pre-made my order.", stars = 1 },
    };

    public Review randomReview() {
        return reviewList[UnityEngine.Random.Range(0, reviewList.Length)];
    }
}