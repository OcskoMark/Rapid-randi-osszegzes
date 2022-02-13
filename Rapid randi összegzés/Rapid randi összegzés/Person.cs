using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rapid_randi_összegzés
{
	class Person
	{
		private string ID;
		private string nickName;
		private string name;
		private string phoneNumber;
		private string email;
		private DateTime birthDate;
		private int age;
		private Boolean isWoman;
		private List<string> sympathics = new List<string>();
		private int getSympathics = 0;
		private List<Person> matches = new List<Person>();

		public Person(string iD, string nickName, string name, string phoneNumber, string email, DateTime birthDate, string sex)
		{
			ID1 = iD;
			this.NickName = nickName;
			this.Name = name;
			this.PhoneNumber = phoneNumber;
			this.Email = email;
			this.BirthDate = birthDate;
			
			if (sex == "Nő")
			{
				IsWoman = true;
			}
			else
			{
				IsWoman = false;
			}

			DateTime eventDate = new DateTime(2022, 02, 14);
			TimeSpan lifeAge = eventDate - birthDate;

			age = lifeAge.Days / 365;
		}

		public string ID1 { get => ID; set => ID = value; }
		public string NickName { get => nickName; set => nickName = value; }
		public string Name { get => name; set => name = value; }
		public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
		public string Email { get => email; set => email = value; }
		public DateTime BirthDate { get => birthDate; set => birthDate = value; }
		public int Age { get => age; set => age = value; }
		public bool IsWoman { get => isWoman; set => isWoman = value; }
		public List<string> Sympathics { get => sympathics; set => sympathics = value; }
		public int GetSympathics { get => getSympathics; set => getSympathics = value; }
		internal List<Person> Matches { get => matches; set => matches = value; }
	}
}
