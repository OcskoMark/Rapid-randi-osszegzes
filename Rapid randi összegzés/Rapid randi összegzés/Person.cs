using System;
using System.Collections.Generic;
using System.IO;
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
		private Boolean isGetSympathics;

		public Person(string iD, string nickName, string name, string phoneNumber, string email, DateTime birthDate, string sex)
		{
			ID1 = iD.ToUpper();
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
		public bool IsGetSympathics { get => isGetSympathics; set => isGetSympathics = value; }
		internal List<Person> Matches { get => matches; set => matches = value; }

		public void Writer(string path)
		{
			StreamWriter writer = new StreamWriter(path + "\\E-mailek\\" + name + ".txt");

			writer.WriteLine("Kedves " + nickName + "!");
			writer.WriteLine();
			writer.WriteLine("Örülünk, hogy részt vettél a Rapid randin. Reméljük, jól érezted magad!");
			writer.WriteLine();
			
			if (matches.Count == 0)
			{
				writer.WriteLine("Sajnos senkivel sem volt közös találatod.");
				writer.WriteLine();
			}
			else
			{
				writer.WriteLine("Gratulálunk, " + matches.Count + " személlyel találtátok kölcsönösen szimpatikusnak egymást.");
				writer.WriteLine("Küldöm a másik elérhetőségeit:");
				writer.WriteLine();
				foreach (Person person in matches)
				{
					writer.WriteLine("Név: " + person.Name);
					writer.WriteLine("E-mail cím: " + person.Email);
					writer.WriteLine("Telefonszám: " + person.PhoneNumber);
					writer.WriteLine();
				}
			}

			if (isGetSympathics)
			{
				if (getSympathics == 0)
				{
					writer.WriteLine("Sajnos 0 beszélgetőpartnered jelölt szimpatikusnak. Ne csüggedj, értékes vagy! A beszélgetőpartnereid csak egy nagyon kicsi halmaza a másik nemnek.");
				}
				else
				{
					writer.WriteLine("Gratulálok, " + getSympathics + " beszélgetőpartnered jelölt szimpatikusnak.");
				}

				writer.WriteLine();
			}

			writer.WriteLine("Fontos számunkra a véleményed, ezért kérlek, töltsd ki teljesen anonim kérdőívünket az eseményről, hogy a jövőbeli hasonló eseményeink szervezésekor a Te tapasztalataidat is figyelembe tudjuk venni!");
			writer.WriteLine("A kérdőívet az alábbi linken érheted el:");
			writer.WriteLine("");
			writer.WriteLine("");
			writer.WriteLine("Sok sikert kívánunk a további ismerkedéshez!");
			writer.WriteLine("");
			writer.WriteLine("Üdvözlettel:");
			writer.WriteLine("a Szervezőcsapat nevében, Ocskó Márk");

			writer.Close();
		}

		public void addSympathics (string ID)
		{
			sympathics.Add(ID);
		}

		public void addMatches (Person person)
		{
			matches.Add(person);
		}
	}
}
