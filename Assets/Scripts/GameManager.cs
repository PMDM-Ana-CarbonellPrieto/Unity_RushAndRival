public class GameManager
{
    public static int defaultSpeed = 60; // Velocidad normal
    public static int objectiveSpeed = 55; // Velocidad si tienes objetivo
    public static int boostSpeed = 80; // Velocidad con el boost
    public static int defaultTimer = 40; // Tiempo máximo carrera
    public static int defaultScore = 50; // Multiplicador de puntos finales

    public static GameState gameState = GameState.PREPARED; // Estado actual del juego
    public static string currentObjective = ""; // Quién tiene el objetivo
    public static int currentCoins = 0; // Modenas recogidas
    public static int currentTime = 0; // Tiempo que ha tardado en la carrera
    public static int currentSpeed = 0; // Velocidad máxima actual
    public static int currentLifes = 0; // Vidas del segundo nivel
    public static int currentEnemyLifes = 3; // Vidas del enemigo
}

public enum GameState
{
    PREPARED,
    STARTED,
    FINISHED
}