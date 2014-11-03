namespace BattleShip
{
    using BattleShip.Common;

    public interface IRenderer
    {
        void AddSeaToRender(Sea sea);

        void AddMessageToRender(string message);

        void RenderAll(Position position);

        void RenderAll();

        void ClearRenderObjects();
    }
}
