using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionsHolderFractions : MonoBehaviour
{
    // 1
    public class First
    {
        public string question = "11/9 in mixed numbers";

        public string ans1 = "1 1/9";
        public string ans2 = "2 1/9";
        public string ans3 = "1 2/9";
        public string ans4 = "3/23";

        public int num = 3;
    }
    public First q1 = new First();

    // 2
    public class Second
    {
        public string question = "1 3/7 in improper fraction";

        public string ans1 = "10/7";
        public string ans2 = "21/7";
        public string ans3 = "7/4";
        public string ans4 = "4/22";

        public int num = 1;
    }
    public Second q2 = new Second();

    // 3
    public class Third
    {
        public string question = "2/5 in percentage";

        public string ans1 = "4%";
        public string ans2 = "40%";
        public string ans3 = "25%";
        public string ans4 = "50%";

        public int num = 2;
    }
    public Third q3 = new Third();

    // 4
    public class Forth
    {
        public string question = "0.70 in percentage";

        public string ans1 = "7%";
        public string ans2 = "70%";
        public string ans3 = "700%";
        public string ans4 = "71%";

        public int num = 2;
    }
    public Forth q4 = new Forth();

    // 5
    public class Fifth
    {
        public string question = "36/7 in mixed numbers";

        public string ans1 = "5 1/7";
        public string ans2 = "4 2/7";
        public string ans3 = "3 6/7";
        public string ans4 = "4/23";

        public int num = 1;
    }
    public Fifth q5 = new Fifth();

    // 6
    public class Sixth
    {
        public string question = "5/6 - 1/3";

        public string ans1 = "1/6";
        public string ans2 = "2/3";
        public string ans3 = "1/2";
        public string ans4 = "4/2";

        public int num = 3;
    }
    public Sixth q6 = new Sixth();

    // 7
    public class Seventh
    {
        public string question = "0.07 + 0.77";

        public string ans1 = "0.84";
        public string ans2 = "1.70";
        public string ans3 = "0.70";
        public string ans4 = "4.30";

        public int num = 1;
    }
    public Seventh q7 = new Seventh();

    // 8
    public class Eighth
    {
        public string question = "35% - 0.15";

        public string ans1 = "0.50";
        public string ans2 = "0.20";
        public string ans3 = "0.10";
        public string ans4 = "0.80";

        public int num = 2;
    }
    public Eighth q8 = new Eighth();

    // 9
    public class Ninth
    {
        public string question = "1/4 + 1/2";

        public string ans1 = "3/4";
        public string ans2 = "1/6";
        public string ans3 = "2/6";
        public string ans4 = "5/6";

        public int num = 1;
    }
    public Ninth q9 = new Ninth();

    // 10
    public class Tenth
    {
        public string question = "0.9 + 1.7 - 0.9";

        public string ans1 = "2.6";
        public string ans2 = "0.9";
        public string ans3 = "1.7";
        public string ans4 = "4.3";

        public int num = 3;
    }
    public Tenth q10 = new Tenth();

    // 11
    public class Eleventh
    {
        public string question = "5.45 - 3.25";

        public string ans1 = "2.7";
        public string ans2 = "2.2";
        public string ans3 = "2.6";
        public string ans4 = "2.4";

        public int num = 2;
    }
    public Eleventh q11 = new Eleventh();

    // 12
    public class Twelveth
    {
        public string question = "0.8 x 2";

        public string ans1 = "1.6";
        public string ans2 = "16.0";
        public string ans3 = "0.16";
        public string ans4 = "3.0";

        public int num = 1;
    }
    public Twelveth q12 = new Twelveth();

    // 13
    public class Thirteenth
    {
        public string question = "9.0 ÷ 3";

        public string ans1 = "0.27";
        public string ans2 = "3.0";
        public string ans3 = "2.7";
        public string ans4 = "4.0";

        public int num = 2;
    }
    public Thirteenth q13 = new Thirteenth();

    // 14
    public class Forteenth
    {
        public string question = "4.91 x 100 ";

        public string ans1 = "4.91";
        public string ans2 = "491";
        public string ans3 = "0.491";
        public string ans4 = "4.53";

        public int num = 2;
    }
    public Forteenth q14 = new Forteenth();

    // 15
    public class Fifteenth
    {
        public string question = "56% in decimal";

        public string ans1 = "0.56";
        public string ans2 = "56";
        public string ans3 = "5.60";
        public string ans4 = "5.6";

        public int num = 1;
    }
    public Fifteenth q15 = new Fifteenth();

    // 16
    public class Sixteenth
    {
        public string question = "8/3 in mixed numbers";

        public string ans1 = "1 2/3";
        public string ans2 = "2 1/2";
        public string ans3 = "2 2/3";
        public string ans4 = "2 2/5";

        public int num = 3;
    }
    public Sixteenth q16 = new Sixteenth();

    // 17
    public class Seventeenth
    {
        public string question = "4 1/3 in improper fraction";

        public string ans1 = "5/3";
        public string ans2 = "13/3";
        public string ans3 = "12/3";
        public string ans4 = "13/4";

        public int num = 2;
    }
    public Seventeenth q17 = new Seventeenth();

    // 18
    public class Eighteenth
    {
        public string question = "0.21 in fraction";

        public string ans1 = "21/100";
        public string ans2 = "21/1000";
        public string ans3 = "21/10";
        public string ans4 = "21/400";

        public int num = 1;
    }
    public Eighteenth q18 = new Eighteenth();

    // 19
    public class Nineteenth
    {
        public string question = "What is the value for number 5 in 87503?";

        public string ans1 = "Thousandth";
        public string ans2 = "Hundredth";
        public string ans3 = "Ten thousandth";
        public string ans4 = "Hundred thousandth";

        public int num = 2;
    }
    public Nineteenth q19 = new Nineteenth();

    // 20
    public class Twentieth
    {
        public string question = "66/9 in proper fraction";

        public string ans1 = "6 6/9";
        public string ans2 = "6 3/9";
        public string ans3 = "7 3/9";
        public string ans4 = "5/06";

        public int num = 3;
    }
    public Twentieth q20 = new Twentieth();

    // 21
    public class Twentifirst
    {
        public string question = "1/5 + 0.9";

        public string ans1 = "1.1";
        public string ans2 = "0.6";
        public string ans3 = "2.4";
        public string ans4 = "1.19";

        public int num = 1;
    }
    public Twentifirst q21 = new Twentifirst();

    // 22
    public class Twentisecond
    {
        public string question = "53% = ___ ÷ 100";

        public string ans1 = "5.3";
        public string ans2 = "53";
        public string ans3 = "530";
        public string ans4 = "533";

        public int num = 2;
    }
    public Twentisecond q22 = new Twentisecond();

    // 24
    public class Twentiforth
    {
        public string question = "0.4% in fraction";

        public string ans1 = "4/100";
        public string ans2 = "4/1000";
        public string ans3 = "40/100";
        public string ans4 = "4.4";

        public int num = 1;
    }
    public Twentiforth q23 = new Twentiforth();

    // 25
    public class Twentififth
    {
        public string question = "2.064 in fraction";

        public string ans1 = "2 64/100";
        public string ans2 = "2 64/10";
        public string ans3 = "2 64/1000";
        public string ans4 = "2 64/1";

        public int num = 3;
    }
    public Twentififth q24 = new Twentififth();

    // 26
    public class Twentisixth
    {
        public string question = "7.2 ÷ 8";

        public string ans1 = "0.8";
        public string ans2 = "0.9";
        public string ans3 = "0.7";
        public string ans4 = "0.5";

        public int num = 2;
    }
    public Twentisixth q25 = new Twentisixth();

    // 27
    public class Twentiseventh
    {
        public string question = "2/3 + 5/6";

        public string ans1 = "9/6";
        public string ans2 = "7/6";
        public string ans3 = "7/3";
        public string ans4 = "3/4";

        public int num = 1;
    }
    public Twentiseventh q26 = new Twentiseventh();

    // 28
    public class Twentieighth
    {
        public string question = "907/1000 in decimals";

        public string ans1 = "0.907";
        public string ans2 = "90.7";
        public string ans3 = "9.07";
        public string ans4 = "90.70";

        public int num = 1;
    }
    public Twentieighth q27 = new Twentieighth();

    // 29
    public class Twentininth
    {
        public string question = "7/10 in decimal";

        public string ans1 = "0.07";
        public string ans2 = "0.777";
        public string ans3 = "0.7";
        public string ans4 = "0.007";

        public int num = 3;
    }
    public Twentininth q28 = new Twentininth();
}
