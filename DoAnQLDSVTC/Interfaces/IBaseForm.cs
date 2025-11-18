namespace DoAnQLDSVTC
{
    public interface IBaseForm
    {
        void AddData(params object[] args);
        void EditData(params object[] args);
        void DeleteData(params object[] args);
        void UndoAction();
    }

    public enum STATE_ACTION
    {
        ADD,
        EDIT,
        DELETE
    }
}