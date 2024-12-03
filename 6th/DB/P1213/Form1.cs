using P1213.movieDB;

namespace P1213
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            bool createMode = false;

            int count = 1;
            for (int i = 1; i <= 5; i++)
            {
                for (int j = 1; j <= 4; j++)
                {
                    Button button = new Button()
                    {
                        Location = new Point(10 + (i - 1) * 110, 10 + (j - 1) * 110),
                        Parent = this,
                        Size = new Size(100, 100),
                    }; 
                    button.Click += (s, e) =>
                    {
                        using (MovieDbContext db = new MovieDbContext())
                        {
                            int k = int.Parse((s as Button)!.Text.Split(' ')[0]);

                            var item = db.Chairs.Where(x => x.Number == k).First();

                            if (item.IsUsed == true)
                            {
                                item.IsUsed = false;
                                button.Text = k.ToString();
                            }
                            else
                            {
                                item.IsUsed = true;
                                button.Text = k.ToString() + " is used";
                            }

                            db.SaveChanges();
                        }
                    };

                    if (createMode == false)
                    {
                        using (MovieDbContext db = new MovieDbContext())
                        {
                            var item = db.Chairs.Where(x => x.Number == count).First();

                            if (item.IsUsed == true)
                            {
                                button.Text = count.ToString() + " is used";
                            }
                            else
                            {
                                button.Text = count.ToString();
                            }
                        }
                    }
                    else
                    {
                        using (MovieDbContext db = new MovieDbContext())
                        {
                            db.Chairs.Add(new Chair()
                            {
                                Number = count,
                                IsUsed = false,
                            });

                            db.SaveChanges();
                        }
                    }

                    count++;
                }
            }
        }
    }
}