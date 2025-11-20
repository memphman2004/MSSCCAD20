using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.Text.Json;

// NOTE: BinaryFormatter is obsolete in new .NET versions,
// I used the web to see how this is done in .NET 5+.
namespace SerializationExample
{
    // This attribute is needed for Binary serialization
    [Serializable]
    public class Student
    {
        public int Id { get; set; }        // Property 1
        public string Name { get; set; }   // Property 2
        public double GPA { get; set; }    // Property 3

        // Parameterless constructor (needed for some serializers)
        public Student() { }

        public Student(int id, string name, double gpa)
        {
            Id = id;
            Name = name;
            GPA = gpa;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Create a sample student object
            Student s1 = new Student(1, "Alice", 3.8);

            // ====== BINARY SERIALIZATION ======
            string binaryFile = "student.bin";
            SerializeBinary(s1, binaryFile);
            Student sFromBinary = DeserializeBinary(binaryFile);
            Console.WriteLine("Binary Deserialized: Id={0}, Name={1}, GPA={2}",
                sFromBinary.Id, sFromBinary.Name, sFromBinary.GPA);

            // ====== XML SERIALIZATION ======
            string xmlFile = "student.xml";
            SerializeXml(s1, xmlFile);
            Student sFromXml = DeserializeXml(xmlFile);
            Console.WriteLine("XML Deserialized: Id={0}, Name={1}, GPA={2}",
                sFromXml.Id, sFromXml.Name, sFromXml.GPA);

            // ====== JSON SERIALIZATION ======
            string jsonFile = "student.json";
            SerializeJson(s1, jsonFile);
            Student sFromJson = DeserializeJson(jsonFile);
            Console.WriteLine("JSON Deserialized: Id={0}, Name={1}, GPA={2}",
                sFromJson.Id, sFromJson.Name, sFromJson.GPA);

            Console.WriteLine("Done. Press any key to exit.");
            Console.ReadKey();
        }

        // ---------------- BINARY ----------------
        static void SerializeBinary(Student student, string fileName)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(fileName, FileMode.Create))
            {
                formatter.Serialize(fs, student);
            }
        }

        static Student DeserializeBinary(string fileName)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(fileName, FileMode.Open))
            {
                return (Student)formatter.Deserialize(fs);
            }
        }

        // ---------------- XML ----------------
        static void SerializeXml(Student student, string fileName)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Student));
            using (FileStream fs = new FileStream(fileName, FileMode.Create))
            {
                xmlSerializer.Serialize(fs, student);
            }
        }

        static Student DeserializeXml(string fileName)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Student));
            using (FileStream fs = new FileStream(fileName, FileMode.Open))
            {
                return (Student)xmlSerializer.Deserialize(fs);
            }
        }

        // ---------------- JSON ----------------
        static void SerializeJson(Student student, string fileName)
        {
            string jsonString = JsonSerializer.Serialize(student);
            File.WriteAllText(fileName, jsonString);
        }

        static Student DeserializeJson(string fileName)
        {
            string jsonString = File.ReadAllText(fileName);
            return JsonSerializer.Deserialize<Student>(jsonString);
        }
    }
}
