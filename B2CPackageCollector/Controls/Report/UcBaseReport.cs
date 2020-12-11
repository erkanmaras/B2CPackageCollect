namespace B2CPackageCollect
{
    public class UcBaseReport : UcBase
    {


        public virtual bool ShouldPrepareReport()
        {
            return false;
        }

        public virtual void PrepareReport()
        {

        }


    }
}
