/*
 Name: Antonio Rodrigues
 Email: arodriguez245@cnm.edu
 FileName: RodriguesP7
 */

namespace RodriguesP7
{
	class Customer
    {
        private int id;
        private string state;
        private int zip;
        private string city;
		private string name;

        public int Id{
            get { return id; }
            set { id = value; }
        }
        public string State {
            get { return state; }
            set { state = value; }
        }
        public int Zip {
            get { return zip; }
            set { zip = value; }
        }
        public string City {
            get { return city; }
            set { city = value; }
        }
        public string Name {
            get { return name; }
            set { name = value; }
        }

        public Customer(): this(0,"tbd",87002,"tbd","tbd")  { }

    

        public Customer(int id, string state, int zip, string name, string city) {
            Id = id;
            State = state;
            Zip = zip;
            Name = name;
            City = city;
        }

        public override string ToString()
        {
            return  id + " "+name;
        }
    }
}
