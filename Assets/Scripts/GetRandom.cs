using UnityEngine;

public static class CustomRnd
{
    public static float GetRnd(float valA, float valB)
    {
        //Seeds the random number generator to not give the same random result every time
        Random.InitState(Mathf.RoundToInt(Time.frameCount));
        //Return the random number that was generated
        return Random.Range(valA, valB);
    }

    public static int GetRnd(int valA, int valB)
    {
        //Seeds the random number generator to not give the same random result every time
        Random.InitState(Mathf.RoundToInt(Time.frameCount));
        //Return the random number that was generated
        return Random.Range(valA, valB);
    }
}