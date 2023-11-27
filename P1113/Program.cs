public class Program
{
    public static void Main(string[] args)
    {
        List<Contact> contacts = new List<Contact>()

        {

            new Contact()

            {

                FirstName = "Barney",

                LastName = "Gottshall",

                DateOfBirth = DateTime.Parse("19-Oct-1945"),

                Phone = "885 983 8858",

                State = "CA"

            },

            new Contact()

            {

                FirstName = "Armando",

                LastName = "Valdes",

                DateOfBirth = DateTime.Parse("9-Dec-1973 "),

                Phone = "848 553 8487",

                State = "WA"

            },new Contact()

            {

                FirstName = "Adam",

                LastName = "Gauwain",

                DateOfBirth = DateTime.Parse("3-Oct-1959"),

                Phone = "115 999 1154",

                State = "AK"

            },new Contact()

            {

                FirstName = "Jeffery",

                LastName = "Deane",

                DateOfBirth = DateTime.Parse("16-Dec-1950"),

                Phone = "677 602 6774",

                State = "CA"

            },new Contact()

            {

                FirstName = "Collin",

                LastName = "Zeeman",

                DateOfBirth = DateTime.Parse("10-Feb-1935"),

                Phone = "603 303 6030",

                State = "FL"

            },new Contact()

            {

                FirstName = "Stewart",

                LastName = "Kagel",

                DateOfBirth = DateTime.Parse("20-Feb-1950"),

                Phone = "546 607 5462",

                State = "WA"

            },new Contact()

            {

                FirstName = "Chance",

                LastName = "Lard",

                DateOfBirth = DateTime.Parse("21-Oct-1951"),

                Phone = "278 918 2789",

                State = "WA"

            },new Contact()

            {

                FirstName = "Blaine",

                LastName = "Reifsteck",

                DateOfBirth = DateTime.Parse("18-May-1946"),

                Phone = "715 920 7157",

                State = "TX"

            },new Contact()

            {

                FirstName = "Mack",

                LastName = "Kamph",

                DateOfBirth = DateTime.Parse("17-Sep-1977"),

                Phone = "364 202 3644",

                State = "TX"

            },new Contact()

            {

                FirstName = "Ariel",

                LastName = "Hazelgrove",

                DateOfBirth = DateTime.Parse("23-May-1922"),

                Phone = "165 737 1656",

                State = "OR"

            },

        };

        List<CallLog> calls = new List<CallLog>()

        {

            new CallLog() { Number = "885 983 8858", Duration = 2, Incoming = true, When = DateTime.Parse("7-Aug-2006 8:12")},

            new CallLog() { Number = "165 737 1656", Duration = 15, Incoming = true, When = DateTime.Parse("7 - Aug - 2006 9:23")},

            new CallLog() { Number = "364 202 3644", Duration = 1, Incoming = false, When = DateTime.Parse("7 - Aug - 2006 10:5")},

            new CallLog() { Number = "603 303 6030", Duration = 2, Incoming = false, When = DateTime.Parse("7 - Aug - 2006 10:35")},

            new CallLog() { Number = "546 607 5462", Duration = 4, Incoming = true, When = DateTime.Parse("7 - Aug - 2006 11:15")},

            new CallLog() { Number = "885 983 8858", Duration = 15, Incoming = false, When = DateTime.Parse("7 - Aug - 2006 13:12")},

            new CallLog() { Number = "885 983 8858", Duration = 3, Incoming = true, When = DateTime.Parse("7 - Aug - 2006 13:47")},

            new CallLog() { Number = "546 607 5462", Duration = 1, Incoming = false, When = DateTime.Parse("7 - Aug - 2006 20:34")},

            new CallLog() { Number = "546 607 5462", Duration = 3, Incoming = false, When = DateTime.Parse("8 - Aug - 2006 10:10")},

            new CallLog() { Number = "603 303 6030", Duration = 23, Incoming = false, When = DateTime.Parse("8 - Aug - 2006 10:40")},

            new CallLog() { Number = "848 553 8487", Duration = 3, Incoming = false, When = DateTime.Parse("8-Aug-2006 14:0")},

            new CallLog() { Number = "848 553 8487", Duration = 7, Incoming = true, When = DateTime.Parse("8 - Aug - 2006 14:37")},

            new CallLog() { Number = "278 918 2789", Duration = 6, Incoming = true, When = DateTime.Parse("8 - Aug - 2006 15:23")},

            new CallLog() { Number = "364 202 3644", Duration = 20, Incoming = true, When = DateTime.Parse("8 - Aug - 2006 17:12")}

        };

        //var q = from c in contacts
        //        where c.DateOfBirth.AddYears(55) > DateTime.Now
        //        orderby c.DateOfBirth descending
        //        select string.Format("{0} {1} Bir.{2}",
        //            c.FirstName,
        //            c.LastName,
        //            c.DateOfBirth.ToString("dd - MMM - yyyy"));
        //foreach (string s in q)
        //    Console.WriteLine(s);

        //var q = contacts
        //    .Where(x => x.Phone.Length == 12)
        //    .OrderBy(c => c.State)
        //    .ThenBy(c => c.FirstName)
        //    .ToList();

        //foreach (var s in q)
        //{
        //    Console.WriteLine("{0} {1}", s.FirstName, s.LastName);
        //}

        //var q = from c in contacts
        //        where c.State == "WA"
        //        orderby c.LastName, c.FirstName
        //        select c;

        //foreach (var contact in q)
        //{
        //    Console.WriteLine(contact.FirstName + " " + contact.LastName);
        //}

        //var qq = calls
        //    .Join(contacts, 
        //          p1 => p1.Number, 
        //          p2 => p2.Phone, 
        //          (p1, p2) => new 
        //          { 
        //              p2.FirstName, 
        //              p2.LastName, 
        //              p1.When,
        //              p1.Duration
        //          })
        //    .OrderByDescending(p1 => p1.When)
        //    .Skip(0)
        //    .Take(5);

        var qq = (from p1 in calls
                  join p2 in contacts
                  on p1.Number equals p2.Phone
                  where p1.Duration > 10 && p1.Incoming
                  orderby p1.When descending
                  select new
                  {
                      p2.FirstName,
                      p2.LastName,
                      p1.When,
                      p1.Duration,
                  })
                  .Skip(0)
                  .Take(5);

        foreach (var item in qq)
        {
            Console.WriteLine(item.FirstName + " " + item.LastName + " calls since " 
                + item.When + " while " + item.Duration + " min.");
        }
    }
}

public class Contact
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string State { get; set; }

    public static List<Contact> SampleList()
    {
        return new List<Contact>()

        {

            new Contact()

            {

                FirstName = "Barney",

                LastName = "Gottshall",

                DateOfBirth = DateTime.Parse("19-Oct-1945"),

                Phone = "885 983 8858",

                State = "CA"

            },

            new Contact()

            {

                FirstName = "Armando",

                LastName = "Valdes",

                DateOfBirth = DateTime.Parse("9-Dec-1973 "),

                Phone = "848 553 8487",

                State = "WA"

            },new Contact()

            {

                FirstName = "Adam",

                LastName = "Gauwain",

                DateOfBirth = DateTime.Parse("3-Oct-1959"),

                Phone = "115 999 1154",

                State = "AK"

            },new Contact()

            {

                FirstName = "Jeffery",

                LastName = "Deane",

                DateOfBirth = DateTime.Parse("16-Dec-1950"),

                Phone = "677 602 6774",

                State = "CA"

            },new Contact()

            {

                FirstName = "Collin",

                LastName = "Zeeman",

                DateOfBirth = DateTime.Parse("10-Feb-1935"),

                Phone = "603 303 6030",

                State = "FL"

            },new Contact()

            {

                FirstName = "Stewart",

                LastName = "Kagel",

                DateOfBirth = DateTime.Parse("20-Feb-1950"),

                Phone = "546 607 5462",

                State = "WA"

            },new Contact()

            {

                FirstName = "Chance",

                LastName = "Lard",

                DateOfBirth = DateTime.Parse("21-Oct-1951"),

                Phone = "278 918 2789",

                State = "WA"

            },new Contact()

            {

                FirstName = "Blaine",

                LastName = "Reifsteck",

                DateOfBirth = DateTime.Parse("18-May-1946"),

                Phone = "715 920 7157",

                State = "TX"

            },new Contact()

            {

                FirstName = "Mack",

                LastName = "Kamph",

                DateOfBirth = DateTime.Parse("17-Sep-1977"),

                Phone = "364 202 3644",

                State = "TX"

            },new Contact()

            {

                FirstName = "Ariel",

                LastName = "Hazelgrove",

                DateOfBirth = DateTime.Parse("23-May-1922"),

                Phone = "165 737 1656",

                State = "OR"

            },

        };
    }
}
public class CallLog
{
    public string Number { get; set; }
    public int Duration { get; set; }
    public bool Incoming { get; set; }
    public DateTime When { get; set; }

    public static List<CallLog> SampleList()
    {
        return new List<CallLog>()

        {

            new CallLog() { Number = "885 983 8858", Duration = 2, Incoming = true, When = DateTime.Parse("7-Aug-2006 8:12")},

            new CallLog() { Number = "165 737 1656", Duration = 15, Incoming = true, When = DateTime.Parse("7 - Aug - 2006 9:23")},

            new CallLog() { Number = "364 202 3644", Duration = 1, Incoming = false, When = DateTime.Parse("7 - Aug - 2006 10:5")},

            new CallLog() { Number = "603 303 6030", Duration = 2, Incoming = false, When = DateTime.Parse("7 - Aug - 2006 10:35")},

            new CallLog() { Number = "546 607 5462", Duration = 4, Incoming = true, When = DateTime.Parse("7 - Aug - 2006 11:15")},

            new CallLog() { Number = "885 983 8858", Duration = 15, Incoming = false, When = DateTime.Parse("7 - Aug - 2006 13:12")},

            new CallLog() { Number = "885 983 8858", Duration = 3, Incoming = true, When = DateTime.Parse("7 - Aug - 2006 13:47")},

            new CallLog() { Number = "546 607 5462", Duration = 1, Incoming = false, When = DateTime.Parse("7 - Aug - 2006 20:34")},

            new CallLog() { Number = "546 607 5462", Duration = 3, Incoming = false, When = DateTime.Parse("8 - Aug - 2006 10:10")},

            new CallLog() { Number = "603 303 6030", Duration = 23, Incoming = false, When = DateTime.Parse("8 - Aug - 2006 10:40")},

            new CallLog() { Number = "848 553 8487", Duration = 3, Incoming = false, When = DateTime.Parse("8-Aug-2006 14:0")},

            new CallLog() { Number = "848 553 8487", Duration = 7, Incoming = true, When = DateTime.Parse("8 - Aug - 2006 14:37")},

            new CallLog() { Number = "278 918 2789", Duration = 6, Incoming = true, When = DateTime.Parse("8 - Aug - 2006 15:23")},

            new CallLog() { Number = "364 202 3644", Duration = 20, Incoming = true, When = DateTime.Parse("8 - Aug - 2006 17:12")}

        };
    }
}
