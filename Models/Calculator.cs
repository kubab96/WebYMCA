using System.ComponentModel;

namespace WebYMCA.Models
{
    public class Calculator : INotifyPropertyChanged
    {
        double waist = 75;
        double weight = 178;
        bool isMale = true;

        public double Waist
        {
            get { return waist; }

            set
            {
                waist = value;
                OnPropertyChanged("Waist");
                OnPropertyChanged("Description");
            }
        }

        public double Weight
        {
            get { return weight; }

            set
            {
                weight = value;
                OnPropertyChanged("Weight");
                OnPropertyChanged("Description");
            }
        }

        public bool IsMale
        {
            get { return isMale; }
            set
            {
                isMale = value;
                OnPropertyChanged("IsMale");
                OnPropertyChanged("Description");
            }
        }

        public string Description
        {
            get
            {
                try
                {
                    string description;
                    double YMCA;
                    if (isMale == true)
                    {
                        YMCA = (((1.634 * waist) - (0.1804 * weight) - 98.42) / (2.2 * weight)) * 100;

                        if (YMCA < 5)
                            description = Math.Round(YMCA, 2) + "% - Essential Fat Percent";
                        else if (YMCA < 13)
                            description = Math.Round(YMCA, 2) + "% - Fat Percent for Athletes";
                        else if (YMCA < 17)
                            description = Math.Round(YMCA, 2) + "% - Fitness Level";
                        else if (YMCA < 24)
                            description = Math.Round(YMCA, 2) + "% - Average Level";
                        else 
                            description = Math.Round(YMCA, 2) + "% - Obese Level";

                        return description;
                    }
                    else
                    {
                        YMCA = (((1.634 * waist) - (0.1804 * weight) - 76.76) / (2.2 * weight)) * 100;

                        if (YMCA < 13)
                            description = Math.Round(YMCA, 2) + "% - Essential Fat Percent";
                        else if (YMCA < 20)
                            description = Math.Round(YMCA, 2) + "% - Fat Percent for Athletes";
                        else if (YMCA < 24)
                            description = Math.Round(YMCA, 2) + "% - Fitness Level";
                        else if (YMCA < 31)
                            description = Math.Round(YMCA, 2) + "% - Average Level";
                        else
                            description = Math.Round(YMCA, 2) + "% - Obese Level";

                        return description;
                    }
                }
                catch (FormatException)
                {
                    return "Something went wrong.";
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string property)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;

            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(property);
                handler(this, e);
            }
        }
    }
}
