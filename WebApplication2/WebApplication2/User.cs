namespace WebApplication2
{
    public class User
    {
        public string Name { get; set; } = "";
        public string Surname { get; set; } = "";
        public int Age { get; set; } = 0;
        public string PhoneNumber { get; set; } = "";
        public string Email { get; set; } = "";

        public override string ToString()
        {
            return $"My Info:\n       Name: {Name};\n       Surname: {Surname};\n       Age: {Age};\n       PhoneNumber: {PhoneNumber};\n       Email: {Email}.";
        }
    }
}
