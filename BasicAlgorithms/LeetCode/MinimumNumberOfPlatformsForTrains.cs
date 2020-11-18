/**

Given arrival and departure times of all trains that reach a railway station, the task is to find the minimum number of platforms required for the railway station so that no train waits.
We are given two arrays which represent arrival and departure times of trains that stop.

    Examples 
    Input: arr[] = {9:00, 9:40, 9:50, 11:00, 15:00, 18:00}
    dep[] = {9:10, 12:00, 11:20, 11:30, 19:00, 20:00}
    Output: 3
    Explantion: There are at-most three trains at a time (time between 11:00 to 11:20)

    Input: arr[] = {9:00, 9:40}
    dep[] = {9:10, 12:00}
    Output: 1
    Explantion: Only one platform is needed.
**/
using System;
using System.Collections.Generic;

public interface ITrain : IIntersect<ITrain>
{
    float arrival { get; set; }

    float departure { get; set; }
}

public class Train : ITrain
{
    public float arrival { get; set; }

    public float departure { get; set; }

    private Train(float arrival, float departure)
    {
        this.arrival = arrival;
        this.departure = departure;
    }

    public static ITrain GetTrain(float arrival, float departure)
    {
        return new Train(arrival, departure);
    }

    public bool IsIntersection(ITrain train)
    {
        return (
        train.arrival >= this.arrival &&
        this.departure <= train.departure &&
        train.arrival <= this.departure
        );
    }
}

public interface IIntersect<T>
{
    bool IsIntersection(T t);
}

public class Platform
{
    public int GetPlatformCount(float[] arrivals, float[] departures)
    {
       IList<ITrain> trains = BuildTrains(arrivals, departures);
       
        int counter = 1;
        int i=0;
        //--------------> Commenting out this exponential logic (that is do 'j') we don't need to do this if the array is sorted 
        // for (int i = 0; i < trains.Count; i++)
        // {
        //     temp = trains[i];
        //     int j = i + 1;
        //     while (j < trains.Count)
        //     {
        //         counter += temp.IsIntersection(trains[j]) ? 1 : 0;
        //         j++;
        //     }
        // }

        // -----------> This is possible if the input arrivals , departures sorted . Secondly, we can avoid one predicate condition due to the for-loop.
        while (i+1 < trains.Count )
        {
            counter += trains[i].IsIntersection(trains[i+1]) ? 1 :0 ;
            i+=1; 
        }
       
        return counter;
    }

    private IList<ITrain> BuildTrains(float[] arrivals, float[] departures)
    {
        IList<ITrain> trains = new List<ITrain>(arrivals.Length);

        for (int i = 0; i < arrivals.Length; i++)
        {
            trains.Add(Train.GetTrain(arrivals[i], departures[i]));
        }
        return trains;
    }
}

public class PlatformTester
{
    public int TestPlatformCounter()
    {
        Platform platform = new Platform();
        int count =
            platform
                .GetPlatformCount(new float[] {
                    9.0F,
                    9.4F,
                    9.5F,
                    11F,
                    15F,
                    18F
                },
                new float[] { 9.1F, 12F, 11.2F, 11.3F, 19F, 20F });
        return count;
    }
}
