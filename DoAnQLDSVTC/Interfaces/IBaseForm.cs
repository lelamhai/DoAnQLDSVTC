namespace DoAnQLDSVTC
{
    public interface IBaseForm
    {
        void AddData();
        void UpdateData();
        void DeleteData();
        void UndoAction();
    }

    public enum STATE_ACTION
    {
        ADD,
        EDIT,
        DELETE,
        NONE
    }
}