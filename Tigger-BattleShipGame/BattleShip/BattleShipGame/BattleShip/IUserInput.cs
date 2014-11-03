namespace BattleShip
{
    using BattleShip.Common;
    public interface IUserInput
    {
        Ship ReadInputShip(int length);
        Position ReadShootCommand();
    }
}
