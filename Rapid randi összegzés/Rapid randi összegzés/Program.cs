using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rapid_randi_összegzés
{
	class Program
	{
		static Dictionary<string, Person> readPersons(string sourcePath)
		{
			Dictionary<string, Person> persons = new Dictionary<string, Person>();

			StreamReader reader = new StreamReader(sourcePath + "\\Résztvevők.csv");

			while (!reader.EndOfStream)
			{
				string line = reader.ReadLine();
				string[] pieces = line.Split(';');
				string[] birthDatas = pieces[4].Split('.');

				DateTime birthDate = new DateTime(Convert.ToInt32(birthDatas[0]), Convert.ToInt32(birthDatas[1]), Convert.ToInt32(birthDatas[2]));

				Person person = new Person(pieces[0], pieces[1], pieces[2], pieces[6], pieces[5], birthDate, pieces[3]);

				persons.Add(pieces[0], person);
			}

			reader.Close();

			return persons;
		}

		static Dictionary<string, Person> readSympathics (string sourcePath, Dictionary<string, Person> persons)
		{
			StreamReader reader = new StreamReader(sourcePath + "\\Szimpátiák.csv");

			while (!reader.EndOfStream)
			{
				string line = reader.ReadLine();
				string[] pieces = line.Split(';');

				if (pieces[1].ToUpper() == "I")
				{
					persons[pieces[0].ToUpper()].IsGetSympathics = true;
				}
				else
				{
					persons[pieces[0].ToUpper()].IsGetSympathics = false;
				}

				for (int i = 2; i < pieces.Length; i++)
				{
					if (pieces[i] == "")
					{
						break;
					}
					else
					{
						persons[pieces[0].ToUpper()].addSympathics(pieces[i].ToUpper());
						persons[pieces[i].ToUpper()].GetSympathics++;
					}
				}
			}

			reader.Close();

			return persons;
		}
		static Dictionary<string, Person> calculateMatches (Dictionary<string, Person> persons)
		{
			foreach (KeyValuePair<string, Person> item in persons)
			{
				foreach(string ID in item.Value.Sympathics)
				{
					if (persons[ID].Sympathics.Contains(item.Value.ID1))
					{
						persons[item.Value.ID1].addMatches(persons[ID]);
					}
				}
			}

			return persons;
		}

		static void Statistics (Dictionary<string, Person> persons, string destinationPath)
		{
			int sumAge = 0;
			int sumManAge = 0;
			int sumWomanAge = 0;
			int sumSympathics = 0;
			int sumManSympathics = 0;
			int sumWomanSympathics = 0;
			int maxManSympathics = 0;
			int minManSympathics = 100;
			int maxWomanSympathics = 0;
			int minWomanSympathics = 100;
			int numberOfWomans = 0;

			foreach (KeyValuePair<string, Person> item in persons)
			{
				sumAge += item.Value.Age;
				sumSympathics += item.Value.Sympathics.Count;
				numOfWomans++;

				if (item.Value.IsWoman)
				{
					sumWomanAge += item.Value.Age;
					sumWomanSympathics += item.Value.Sympathics.Count;

					if (maxWomanSympathics < item.Value.Sympathics.Count)
					{
						maxWomanSympathics = item.Value.Sympathics.Count;
					}
					else if (minWomanSympathics > item.Value.Sympathics.Count)
					{
						minWomanSympathics = item.Value.Sympathics.Count;
					}
				}
				else
				{
					sumManAge += item.Value.Age;
					sumManSympathics += item.Value.Sympathics.Count;

					if (maxManSympathics < item.Value.Sympathics.Count)
					{
						maxManSympathics = item.Value.Sympathics.Count;
					}
					else if (minManSympathics > item.Value.Sympathics.Count)
					{
						minManSympathics = item.Value.Sympathics.Count;
					}
				}
			}

			int numberOfPersons = persons.Count;
			int numberOfMans = numberOfPersons - numberOfWomans;
			double avgAge = sumAge / numberOfPersons;
			double avgManAge = sumManAge / numberOfMans;
			double avgWomanAge = sumWomanAge / numberOfWomans;
			double avgSympathics = sumSympathics / numberOfPersons;
			double avgManSympathics = sumManSympathics / numberOfMans;
			double avgWomanSympathics = sumWomanSympathics / numberOfWomans;
		}


		static void Main(string[] args)
		{
			string sourcePath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.Parent.FullName;
			string destinationPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.Parent.FullName + "\\Eredmények";

			Dictionary<string, Person> persons = readPersons(sourcePath);
			persons = readSympathics(sourcePath, persons);
			persons = calculateMatches(persons);

			foreach (KeyValuePair<string, Person> item in persons)
			{
				item.Value.Writer(destinationPath);
			}

		}
	}
}
