namespace Challenges.PartTwo;

public class SimulasTest
{
    public void Solution()
    {

        Chest chest = Chest.Locked;

        while (true)
        {

            Console.Write($"The chest is {chest}. What do you want to do? ");
            var action = Console.ReadLine();

            switch (action)
            {
                case "unlock":
                    if (chest != Chest.Unlocked)
                    {
                        chest = Chest.Unlocked;
                    }
                    break;
                case "lock":
                    if (chest != Chest.Locked)
                    {
                        chest = Chest.Locked;
                    }
                    break;
                case "open":
                    if (chest != Chest.Open && chest != Chest.Locked)
                    {
                        chest = Chest.Open;
                    }
                    break;
                case "close":
                    if (chest != Chest.Closed)
                    {
                        chest = Chest.Closed;
                    }
                    break;


            }



        }

    }

}
