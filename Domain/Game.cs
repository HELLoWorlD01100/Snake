using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.Domain
{
    public class Game
    {
        public GameStage Stage { get; private set; } = GameStage.NotStarted;
        public Field Field { get; private set; }
        
        private GameSettings _settings = new GameSettings();
        public event Action Win;
        public event Action<GameStage> StageChanged;

        public void Start()
        {
            if (_settings.Levels.Count <= 0)
            {
                ChangeStage(GameStage.Finished);
                Win?.Invoke();
            }
            else
            {
                Field = _settings.CreateField(_settings.Levels.Dequeue());
                ChangeStage(GameStage.Playing);
            }
        }

        public void Restart()
        {
            _settings = new GameSettings();
            Start();
        }
        public void ChangeStage(GameStage stage)
        {
            Stage = stage;
            StageChanged?.Invoke(stage);
        }
    }
}
