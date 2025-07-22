using GameManager;

namespace Port {
    public interface IGameManager {
        ManagerStatus status {get;}

        void Startup();
    }
}