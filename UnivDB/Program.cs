using MySql.Data.MySqlClient;

void Show()
{
    using (MySqlConnection connection = new MySqlConnection("server=localhost;database=univDB;uid=root;pwd=1479"))
    {
        connection.Open();

        MySqlCommand command = new MySqlCommand("select * from student", connection);

        MySqlDataReader r = command.ExecuteReader();

        while (r.Read())
        {
            for (int i = 0; i < r.FieldCount; i++)
            {
                Console.Write(r[i] + "\t");
            }
            Console.WriteLine();
        }

        connection.Close();
    }
}

void Insert()
{
    using (MySqlConnection connection = new MySqlConnection("server=localhost;database=univDB;uid=root;pwd=1479"))
    {
        connection.Open();

        MySqlCommand command = new MySqlCommand("insert into student values (5558001, '김연아', '서울 서초', 4, 23, 'F', '010-1111-2222', '컴퓨터')", connection);

        var r = command.ExecuteNonQuery();
        Console.WriteLine(r);

        connection.Close();
    }
}
