using System;

class MissCat
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        int[] votes = new int[11];
        int votesLength = votes.Length;

        for (int i = 0; i < N; i++)
        {
            byte vote = byte.Parse(Console.ReadLine());
            votes[vote]++;
        }

        int maxVote = 0;
        int maxVoteCat = 0;
        for (int i = 1; i < votesLength; i++)
        {
            if (maxVote < votes[i])
            {
                maxVote = votes[i];
                maxVoteCat = i;
            }
        }
        Console.WriteLine(maxVoteCat);
    }
}