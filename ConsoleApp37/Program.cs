using System.Text.Json;
using System.Text.Json.Nodes;
using ConsoleApp37;

Person person1 = new("John Doe", 25);

string? filePath = "C:\\Users\\user\\source\\repos\\ConsoleApp37\\ConsoleApp37\\Person.json";

using (FileStream fs = new (filePath, FileMode.Create)) {
    JsonSerializer.SerializeAsync(fs, person1).Wait();
}

Console.WriteLine("Data has been written to file successfully.");

using (FileStream fs = new(filePath, FileMode.Open)) {
    Person? person2 = JsonSerializer.DeserializeAsync<Person>(fs).Result;
    Console.WriteLine(person2);
}

List<Person> personList = new ();

string? listFilePath = "C:\\Users\\user\\source\\repos\\ConsoleApp37\\ConsoleApp37\\PersonList.json";


string? option;
do {
    Console.WriteLine("1. Add a person");
    Console.WriteLine("2. View all persons");
    Console.WriteLine("0. Exit");
    Console.Write("Please choose an option: ");
    option = Console.ReadLine();
    using (FileStream fs = new(listFilePath, FileMode.Open)) {
        personList = JsonSerializer.DeserializeAsync<List<Person>>(fs).Result;
    }

    switch (option) {
        case "1":
            Console.Write("Enter fullname: ");
            string? fullname = Console.ReadLine();
            byte age;
            do {
                Console.Write("Enter age: ");
            } while (!byte.TryParse(Console.ReadLine(), out age));
            personList.Add(new Person(fullname, age));
            using (FileStream fs = new(listFilePath, FileMode.Create)) {
                JsonSerializer.SerializeAsync(fs, personList).Wait();
            }
            break;
        case "2":
            foreach (Person person in personList) {
                Console.WriteLine(person);
            }
            break;
        case "0":
            Console.WriteLine("Good Bye!");
            break;
        default:
            Console.WriteLine("Invalid option.");
            break;
    }
} while (option != "0");

using (FileStream fs = new(listFilePath, FileMode.Create)) {
    JsonSerializer.SerializeAsync(fs, personList).Wait();
}
