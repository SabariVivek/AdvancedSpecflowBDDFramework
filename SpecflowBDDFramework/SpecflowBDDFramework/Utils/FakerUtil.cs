namespace SpecflowBDDFramework.Utils
{
    public class FakerUtil
    {
        public static String FirstName()
        {
            return Faker.Name.First();
        }

        public static String LastName()
        {
            return Faker.Name.Last();
        }

        public static String Email()
        {
            return Faker.Internet.Email();
        }

        public static String Password()
        {
            return FirstName() + "@123";
        }
    }
}