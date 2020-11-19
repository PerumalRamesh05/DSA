/****** StonePile Game

https://community.topcoder.com/stat?c=problem_statement&pm=13113&rd=15852

int[] with N -> number of stones in one of the piles. 
Players take turns to :
>> Draw Pile X which is >=2 split optimally .
>> Add the pile A (X1) --> Pile Y  and pile  B (X2) ---> Pile Z . 
>> The player who cannot make a valid move loses the game. 
>> If Player1 --> return string "WIN" or "LOSE"
{1,2,50} -- "WIN"
{2,2}
{1,2,3,4,3,2,2,4,3,1,4,4,1,2,4,4,1,4,3,1,4,2,1} -- "WIN"

********/
using System.Collections.Generic;
using NUnit.Framework;

public class GameOperation
{
    IList<int> originalStonePiles;

    int countOfInvalidPiles;

    int countOfValidPiles;

    public GameOperation(int[] stonePiles)
    {
        System.Array.Sort(stonePiles); //Never do business logic in c'tor only and always assignments !!!!!
        originalStonePiles = new List<int>(stonePiles);
    }

    private void UpdateState(int currentItem)
    {
        countOfInvalidPiles += currentItem < 2 ? 1 : 0;
        countOfValidPiles += currentItem >= 2 ? 1 : 0;
    }

    private void MakeNextAvailableMove()
    {
        int currentItem = 0;
        int index = originalStonePiles.Count - 1;

        while (index >= 2)
        {
            currentItem = originalStonePiles[index];

            if (currentItem < 2)
            { originalStonePiles.RemoveAt(index); UpdateState(currentItem); index--; continue; }

            originalStonePiles[index - 1] = originalStonePiles[index - 1] + (currentItem - (currentItem / 2));
            originalStonePiles[index - 2] = originalStonePiles[index - 2] + (currentItem - (currentItem / 2));

            originalStonePiles.RemoveAt(index);
            UpdateState(currentItem);

            index--;
            break;
        }

    }

    private bool HasValidationFailed()
    {
        return originalStonePiles.Count <= 2 || countOfValidPiles == 0;
    }

    public int DrawResult(int player)
    {
        if (HasValidationFailed() && player != 1)
            return player - 1;

        MakeNextAvailableMove();

        player++;
        return DrawResult(player);
    }

}

[TestFixture]
public class Test_StonePilesGame
{
    [TestCase(new int[] { 1, 2, 3, 4, 3, 2, 2, 4, 3, 1, 4, 4, 1, 2, 4, 4, 1, 4, 3, 1, 4, 2, 1 })]
    [TestCase(new int[] { 1, 2, 50 })]
    [TestCase(new int[] { 1, 1, 2 })]
    [TestCase(new int[] { 2, 2 })]
    public void Player1_Wins_Test(int[] input)
    {
        GameOperation g = new GameOperation(input);
        int playerWinner = g.DrawResult(1);
        Assert.IsTrue(playerWinner % 2 > 0, "Player1 is the winner");
    }


    [TestCase(new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 1, 1, 1, 3, 1, 9, 1, 3, 1, 1, 1, 1, 1 })]
    public void Player2_Wins_Test(int[] input)
    {
        GameOperation g = new GameOperation(input);
        int playerWinner = g.DrawResult(1);
        Assert.IsTrue(playerWinner % 2 == 0, "Player2 is the winner");
    }


}
