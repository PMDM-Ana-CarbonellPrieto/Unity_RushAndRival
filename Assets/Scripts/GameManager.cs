public class GameManager
{
    public static int defaultSpeed = 70;
    public static int objectiveSpeed = 60;
    public static int boostSpeed = 140;
    public static int defaultTimer = 40;
    public static int defaultScore = 50;

    public static GameState gameState = GameState.PREPARED;
    public static string currentObjective = "";
    public static int currentCoins = 0;
    public static int currentTime = 0;
    public static int currentSpeed = 0;
    public static int currentLifes = 0;
    public static int currentEnemyLifes = 3;
}

public enum GameState
{
    PREPARED,
    STARTED,
    FINISHED
}