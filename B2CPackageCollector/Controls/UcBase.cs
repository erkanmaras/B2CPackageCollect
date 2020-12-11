namespace B2CPackageCollect
{
    public class UcBase : DevExpress.XtraEditors.XtraUserControl
    {
        public UcBase()
        {
        }

        public virtual bool ValidateForNavigation()
        {
            return true;
        }

        public virtual void FocusFirstControl()
        { }

        public virtual void Activated()
        { }

        public virtual void Initialize()
        { }
    }
}
