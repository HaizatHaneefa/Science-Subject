using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARClass : MonoBehaviour
{
    public class Lungs
    {
        public string option1 = "Quick Note 1";

        public string showInfo1 = "Animals that breathe through lungs mostly live on land except for whales and dolphins.";
    }

    public Lungs d1 = new Lungs();

    public class Gills
    {
        public string option1 = "Quick Note 1";
        public string option2 = "Quick Note 2";

        public string showInfo1 = "ALL animals that breathe through gills live in the water.";
        public string showInfo2 = "The gills capture the dissolved oxygen in the water by using the filtering technique. At the same time, the carbon dioxide is expelled from the gills to the water.";
    }

    public Gills d2 = new Gills();

    public class Spiracle
    {
        public string option1 = "Quick Note 1";
        public string option2 = "Quick Note 2";

        public string showInfo1 = "Animals that breathe through spiracles are called insects.";
        public string showInfo2 = "Spiracles are the small ‘spots’ that can be found on the abdomen section of the animals.";
    }

    public Spiracle d3 = new Spiracle();

    public class MoistSkin
    {
        public string option1 = "Quick Note 1";
        public string option2 = "Quick Note 2";

        public string showInfo1 = "Earthworms and amphibians such as frogs breathe through moist skin.";
        public string showInfo2 = "While completely under water, the frog’s respiration happens through the skin.The membrane under the skin allows the gases to pass through it and enter the blood vessels around the body.";
    }

    public MoistSkin d4 = new MoistSkin();

    public class LungsAndMoistSkin
    {
        public string option1 = "Quick Note 1";
        public string option2 = "Quick Note 2";

        public string showInfo1 = "There are three kinds of animal that can breathe through both lungs and moist skin in the animal kingdom that known to human.";
        public string showInfo2 = "These three kinds of animal use the lungs to breathe when they are in land. When they are under water, the breathing changes from using the lungs to their most skins.";
    }

    public LungsAndMoistSkin d5 = new LungsAndMoistSkin();
}


