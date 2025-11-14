using System.Windows.Forms;

namespace DoAnQLDSVTC
{
    public abstract class BaseForm:Form
    {
        protected abstract void AddData(params object[] args);
        protected abstract void EditData(params object[] args);
        protected abstract void DeleteData(params object[] args);
        protected abstract void UndoAction();

    }

    public enum STATE_ACTION
    {
        ADD,
        EDIT,
        DELETE
    }
}
