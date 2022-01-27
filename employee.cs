using System;

namespace pppraca
{
    public class employee
    {
        public int ID { get; set; }
        public string name { get; set; }
        public DateTime DOB { get; set; }
        public bool position { get; set; } //true = urzędnik; false = pracownik fizyczny
        public int rateHour { get; set; }
        public int rateMonth { get; set; }



        public void show()
        {
            if (position == true)
            {
                Console.WriteLine(ID + " ~ " + name + " ~ " + DOB.ToShortDateString() + " ~ urzędnik ~ brak ~ " + rateMonth);
            }
            else
            {
                Console.WriteLine(ID + " ~ " + name + " ~ " + DOB.ToShortDateString() + " ~ prac. fizyczny ~ " + rateHour + " ~ brak");
            }
        }
    }
}