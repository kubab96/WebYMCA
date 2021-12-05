namespace WebYMCA.Models
{
    public class YMCA
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }

        public double Waist { get; set; }

        public double Weight { get; set; }

        public bool IsMale { get; set; }
        public Calculator CalculateYMCA { get { return new Calculator() { Waist = Waist, Weight = Weight, IsMale = IsMale }; } }
    }
}
