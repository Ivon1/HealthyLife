namespace HealthyLife.ViewModels
{
    public class SortViewModel
    {
        public SortState NameSort { get; set; }
        public SortState PriceSort { get; set; }
        public SortState RateSort { get; set; }
        public SortState Current { get; set; }
        public bool Up { get; set; }

        public SortViewModel(SortState sortOrder)
        {
            NameSort = SortState.NameAsc;
            PriceSort = SortState.PriceAsc;
            RateSort = SortState.RateAsc;
            Up = true;

            if (sortOrder == SortState.NameDesc || sortOrder == SortState.PriceDesc || sortOrder == SortState.RateDesc) 
            {
                Up = false;
            }

            switch(sortOrder)
            {
                case SortState.NameDesc:
                    Current = NameSort = SortState.NameAsc;
                    break;
                case SortState.PriceAsc:
                    Current = PriceSort = SortState.PriceDesc;
                    break;
                case SortState.PriceDesc:
                    Current = PriceSort = SortState.PriceAsc;
                    break;
                case SortState.RateAsc:
                    Current = RateSort = SortState.RateDesc;
                    break;
                case SortState.RateDesc:
                    Current = RateSort = SortState.RateAsc;
                    break;
                default:
                    Current = NameSort = SortState.NameDesc;
                    break;
            }
        }
    }

    public enum SortState
    {
        NameAsc,
        NameDesc,
        PriceAsc,
        PriceDesc,
        RateAsc,
        RateDesc
    }
}
