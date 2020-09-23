using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class data : MonoBehaviour
{
    public class FirstQuestion
    {
        public string hint1 = "Hint 1: Frog.";
        public string hint2 = "Hint 2: Toad.";
        public string hint3 = "Hint 3: Lungs and moist skins.";
    }

    public FirstQuestion d1 = new FirstQuestion();

    public class SecondQuestion
    {
        public string hint1 = "Hint 1: Spiral + Miracles = ____";
        public string hint2 = "Hint 2: Not found in mammals.";
        public string hint3 = "Hint 3: Small holes.";
    }

    public SecondQuestion d2 = new SecondQuestion();

    public class ThirdQuestion
    {
        public string hint1 = "Hint 1: A process.";
        public string hint2 = "Hint 2: Opposite of 'in.'";
        public string hint3 = "Hint 3: You do it, I do it. Everybody does it.";
    }

    public ThirdQuestion d3 = new ThirdQuestion();

    public class ForthQuestion
    {
        public string hint1 = "Hint 1: Long and Dangerous.";
        public string hint2 = "Hint 2: Breathes using lungs like humans.";
        public string hint3 = "Hint 3: Some of them are beautiful, some are not.";
    }

    public ForthQuestion d4 = new ForthQuestion();

    public class FifthQuestion
    {
        public string hint1 = "Hint 1: I cannot let it dry, or I will die.";
        public string hint2 = "Hint 2: Humid, moist, wet.";
        public string hint3 = "Hint 3: It's all over you.";
    }

    public FifthQuestion d5 = new FifthQuestion();
}
