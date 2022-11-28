using System;
namespace musei.Data
{
	public class Booking
	{
		public string bookedEvent { get; set; }

		public List<Person> people { get; set; }

        public override string ToString()
		{
			return $"bookedEvent: {bookedEvent}\nattending people: {people}";
		}



    }
}

