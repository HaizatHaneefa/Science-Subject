using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceCarData : MonoBehaviour
{
    public class FirstCar
    {
        public string carName = "BMW";

        public float topSpeed = 0.7f;
        public float accel = 0.6f;
        public float control = 0.8f;
        public float strength = 0.8f;
    }

    public FirstCar c1 = new FirstCar();

    public class SecondCar
    {
        public string carName = "Proton";

        public float topSpeed = 0.3f;
        public float accel = 0.4f;
        public float control = 0.2f;
        public float strength = 0.4f;
    }

    public SecondCar c2 = new SecondCar();

    public class ThirdCar
    {
        public string carName = "Perodua";

        public float topSpeed = 0.8f;
        public float accel = 0.6f;
        public float control = 0.4f;
        public float strength = 0.2f;
    }

    public ThirdCar c3 = new ThirdCar();
}
