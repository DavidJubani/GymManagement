namespace FinalProjectGym_management.Models
{
    public class Discounts
    {

        public int Id { get; set; }

        public int Code { get; set; }

        public int Value { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public DateTime DeactivationDate { get; set; }

    }
}
