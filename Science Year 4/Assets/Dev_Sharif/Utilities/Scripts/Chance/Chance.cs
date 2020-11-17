using UnityEngine;

public static class Chance {
    public static System.Random random = new System.Random();
    
    public static void SetSeed(int seed) {
        random = new System.Random(seed);
    }

    public static bool Roll(float threshold, out float result) {
        result = (float)random.NextDouble();
        return result >= threshold;
    }

    public static bool Roll(float threshold) {
        return Roll(threshold, out float result);
    }

    public static bool LuckyRoll(float threshold, int rolls) {
        return LuckyRoll(threshold, rolls, out float result);
    }

    public static bool LuckyRoll(float threshold, int rolls, out float result) {
        result = 0f;
        for (int i = 0; i < rolls; i++) {
            result = Mathf.Max(result, (float)random.NextDouble());
        }
        return result >= threshold;
    }

    public static bool UnluckyRoll(float threshold, int rolls, out float result) {
        result = Mathf.Infinity;
        for (int i = 0; i < rolls; i++) {
            result = Mathf.Min(result, (float)random.NextDouble());
        }
        return result >= threshold;
    }

    public static bool UnluckyRoll(float threshold, int rolls) {
        return UnluckyRoll(threshold, rolls, out float result);
    }

    public static bool AverageRoll(float threshold, int rolls, out float result) {
        result = 0;
        for (int i = 0; i < rolls; i++) {
            result += (float)random.NextDouble();
        }
        result = result / rolls;
        return result >= threshold;
    }

    public static bool AverageRoll(float threshold, int rolls) {
        return AverageRoll(threshold, rolls, out float result);
    }
}

public class EntropyChance {
    float entropy = 0f;
    public float threshold { set; get; }

    public EntropyChance(float threshold) {
        this.threshold = threshold;
    }

    public bool Evaluate() {
        entropy += (float)Chance.random.NextDouble();
        if (entropy >= threshold) {
            entropy = 0f;
            return true;
        } else {
            return false;
        }
    }
}