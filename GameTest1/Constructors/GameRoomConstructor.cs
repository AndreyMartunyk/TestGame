using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTest1
{
    class GameRoomConstructor
    {
        public GameRoom Init()
        {
            GameRoom level_1 = new GameRoom();
            level_1.CreateLevelStorage();

            CharacterConstructor characterConstructor = new CharacterConstructor();
            GameObject player = characterConstructor.CreatePlayer(10, 30);
            level_1.AddGameObject(player);
            level_1.AddGameObject(characterConstructor.CreateBlindBeagle(12, 16));
            level_1.AddGameObject(characterConstructor.CreateBlindBeagle(30, 16));
            level_1.AddGameObject(characterConstructor.CreateBlindBeagle(50, 16));

            level_1.AddMap(new MapConstructor().Tutorial_1());

            return level_1;
        }
    }
}
