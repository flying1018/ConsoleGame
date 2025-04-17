
namespace RtanRPG.RPG
{
    internal class GameManager
    {
        public Profile.PlayerInfo Player { get; set; } // 플레이어 프로필 불러오는 객체
        public void NewPlayer(string name, Profile.Job job, string jobName) // 메인에서 플레이어 프로필을 초기화 하는 함수
        {
            Player = new Profile.PlayerInfo(name, job, jobName);
        }

        public Item.ItemInfo PlayerInventory { get; set; } // 플레이어 인벤토리 불러오는 객체
        public void NewInventory(Item.ItemType name, int index) // 메인에서 인벤토리를 초기화 하는 함수
        {
            PlayerInventory = new Item.ItemInfo(name, index);
        }

        public List<Item.ItemInfo> Inventory { get; private set; } = new List<Item.ItemInfo>();




        public Map.MapInfo CurrentMap { get; private set; } // 현재 맵 위치

        public int Turn { get; private set; } = 1; // 턴 저장 변수

        public bool GameOver { get; private set; } = true; // 게임루프 관리하는 불리언 변수

        public void ShowPlayerStats() // 플레이어 스탯창 표시 함수
        {
            Player.ShowStats();
        }

        public void ShowPlayerInventory() // 플레이어 인벤토리 표시 함수
        {

        }

        public void NextMap() // 다음 맵갈때마다 실행 (턴+1)
        {
            Turn++;
        }

        public void EndGame() // 게임종료 함수
        {
            GameOver = false;
        }
    }
}