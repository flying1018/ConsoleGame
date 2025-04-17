
namespace RtanRPG.RPG
{
    internal class GameManager
    {
        public Profile.PlayerInfo Player { get; private set; }

        public void InputPlayer(string name, Profile.Job job, string jobName)
        {
            Player = new Profile.PlayerInfo(name, job, jobName);
        }
        public List<Item.ItemInfo> Inventory { get; private set; } = new List<Item.ItemInfo>();

        public Map.MapInfo CurrentMap { get; private set; }

        public int Turn { get; private set; } = 1;

        public bool GameOver { get; private set; } = true;

        public void ShowPlayerStats()
        {
            Player.ShowStats();
        }

        public void ShowPlayerInventory()
        {
            
        }

        public void NextMap()
        {
            Turn++;
        }

        public void EndGame()
        {
            GameOver = false;
        }
    }
}