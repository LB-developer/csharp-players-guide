namespace Challenges.TheFountainOfObjects;

internal class Rooms
{
    private GameRoom[,] _Rooms { get; init; }
    internal int _FountainRow { get; set; }
    internal int _FountainCol { get; set; }

    internal Rooms(int difficulty)
    {
        this._Rooms = new GameRoom[difficulty, difficulty];
        this.InitializeBoard(difficulty);
    }


    private void InitializeBoard(int difficulty)
    {
        for (int i = 0; i < difficulty; i++)
        {
            for (int j = 0; j < difficulty; j++)
            {
                this._Rooms[i, j] = GameRoom.Normal;
            }
        }

        this.InitializeFountain(difficulty);
    }

    private void InitializeFountain(int difficulty)
    {
        // Fountains spawn at least halfway to ensure players can't spawn too close for balanced gameplay.
        int min = difficulty / 2;
        int max = difficulty;

        var random = new Random();
        int row;
        int col;

        row = random.Next(min, max);
        col = random.Next(min, max);
        this._Rooms[row, col] = GameRoom.Fountain;
        this._FountainCol = col;
        this._FountainRow = row;
    }

    enum GameRoom
    {
        Normal,
        Fountain
    }

}
