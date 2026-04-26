public abstract class FieldATD<TCell>
{
    public const int SWAP_NIL = 0;
    public const int SWAP_OK = 1;
    public const int SWAP_ERR_OUT_OF_BOUNDS = 2;
    public const int SWAP_ERR_NOT_ADJACENT = 3;

    public const int BONUS_NIL = 0;
    public const int BONUS_OK = 1;
    public const int BONUS_ERR_INVALID_POSITION = 2;
    public const int BONUS_ERR_NO_BONUS = 3;

    // конструктор
    // постусловие: создано инициализированное поле фиксированного размера
    protected FieldATD() { }

    // команды

    // предусловия: p1 и p2 принадлежат полю, позиции соседние,
    // в результате перемены мест хотя бы один элемент попадёт
    // в группу подлежащую удалению
    // постусловие: элементы в p1 и p2 поменялись местами
    public abstract void Swap(Position p1, Position p2);

    // предусловие: position принадлежит полю, в позиции есть бонус
    // постусловие: к полю применён эффект бонуса
    public abstract void ApplyBonus(Position position);

    // постусловие: все помеченные элементы удалены
    public abstract void RemoveMarked();

    // постусловие: пустые позиции заполнены по правилам игры
    public abstract void CollapseAndRefill();

    // постусловие: поле очищено и приведено в начальное состояние
    public abstract void Clear();

    // запросы

    public abstract TCell GetCell(Position position);
    public abstract bool IsInside(Position position);
    public abstract int Width();
    public abstract int Height();
    public abstract int CountMarked();

    // запросы статусов
    public abstract int GetSwapStatus();
    public abstract int GetApplyBonusStatus();
}

public abstract class GameStateATD
{
    public const int HANDLE_NIL = 0;
    public const int HANDLE_OK = 1;
    public const int HANDLE_ERR_COMMAND_NOT_ALLOWED = 2;
    public const int HANDLE_ERR_COMMAND_FAILED = 3;

    protected GameStateATD() { }

    // команды

    // постусловие: состояние обработало команду command
    public abstract void HandleCommand(GameCommandATD command, GameLoopATD game);

    // постусловие: выполнены действия при входе в состояние
    public abstract void Enter(GameLoopATD game);

    // постусловие: выполнены действия при выходе из состояния
    public abstract void Exit(GameLoopATD game);

    // запросы

    public abstract bool CanHandle(GameCommandATD command);
    public abstract string Name();

    // запросы статусов
    public abstract int GetHandleCommandStatus();
}

public abstract class MarkedCellsATD
{
    protected MarkedCellsATD() { }

    // команды

    // постусловие: позиция отмечена для удаления
    public abstract void Mark(Position position);

    // постусловие: отметка позиции удалена
    public abstract void Unmark(Position position);

    // постусловие: все позиции сняты с отметки
    public abstract void Clear();

    // запросы
    public abstract bool Contains(Position position);
    public abstract int Count();
}

public abstract class EventQueueATD<TEvent>
{
    protected EventQueueATD() { }

    // команды

    // постусловие: событие добавлено в хвост очереди
    public abstract void Enqueue(TEvent gameEvent);

    // предусловие: очередь не пуста
    // постусловие: первый элемент удалён из очереди
    public abstract void Dequeue();

    // постусловие: очередь очищена
    public abstract void Clear();

    // запросы
    public abstract TEvent Peek();
    public abstract int Size();
    public abstract bool IsEmpty();
}

public abstract class GameLoopATD
{
    public const int STEP_NIL = 0;
    public const int STEP_OK = 1;
    public const int STEP_ERR = 2;

    protected GameLoopATD() { }

    // команды

    // постусловие: игровой цикл инициализирован
    public abstract void Initialize();

    // постусловие: выполнен один шаг игрового цикла
    public abstract void Step();

    // постусловие: command передана на обработку текущему состоянию/контексту
    public abstract void SubmitCommand(GameCommandATD command);

    // постусловие: текущее состояние изменено на state
    public abstract void ChangeState(GameStateATD state);

    // постусловие: игра завершена
    public abstract void Stop();

    // запросы
    public abstract bool IsRunning();
    public abstract GameStateATD CurrentState();
    public abstract FieldATD<Cell> CurrentField();

    // запросы статусов
    public abstract int GetStepStatus();
}
