namespace PleaseReturntheRobot;

public sealed class RobotApi(GameWorld world)
{
    public void HatchBot() => world.SpawnRobotAtDock();
}
