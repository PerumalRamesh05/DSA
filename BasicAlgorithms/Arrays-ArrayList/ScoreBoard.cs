// Build a ScoreBoard object that will hold an array of GameEntry and at all times hold only top 'n' scores of gameEntries
//  such that once is slot is reserved move every other GameEntries to the right.
//
public class ScoreBoard
{

    private GameEntry[] gameEntry;

    public ScoreBoard(int capacity)
    {
        gameEntry = new GameEntry[capacity];
    }

    public GameEntry[] ToGameEntryArray()
    {
        return gameEntry;
    }
    public void add(GameEntry ge)
    {
        GameEntry temp, temp1;
        int length = gameEntry.Length;
        for (int i = 0; i < length; i++)
        {
            //Once filled up , only keep the top "n" (where n=capacity) of scores 
            if (gameEntry[i] != null)
            {
                if (gameEntry[i].Score < ge.Score)
                {
                    temp = gameEntry[i];
                    gameEntry[i] = ge;
                    //Move to the right only until the penultimate one 
                    if (i < length - 1)
                    {
                        //Moving everything to right from the point of insertion impact 'i'
                        while (i < length - 1)
                        {
                            temp1 = gameEntry[i + 1];
                            gameEntry[i + 1] = temp;
                            temp = temp1;
                            i++;
                        }
                    }
                    break;
                }
            }
            //Filling up GameEntry until all of its capacity is open
            if (gameEntry[i] == null)
            {
                gameEntry[i] = ge;
                break;
            }
        }
    }
}

public class GameEntry
{
    public int Score { get; set; }

    public string Name { get; set; }
}